using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab2.Coder;
using lab2.Coder.Tasks;
using lab2.Designer;
using lab2.Designer.Tasks;
using lab2.ProjectManager;
using lab2.ProjectManager.Tasks;

namespace lab2.Studio
{
    public sealed class EventTaskManagement
    {
        private readonly Studio _studio;
        private bool _isRunning;
        private Thread _thread;
        private delegate void logDelegate(WorkerTask task, TextBox logBox);
        private event logDelegate _logStartEvent;
        private event logDelegate _logFinishEvent;
        private CancellationTokenSource _tokenSource;
        private static EventTaskManagement _instance;

        private EventTaskManagement()
        {
            _studio = new Studio();
            _isRunning = false;
            _logStartEvent += logDelay;
            _logFinishEvent += executeFinishTask;
            _tokenSource = new CancellationTokenSource();
        }

        public static EventTaskManagement getInstance()
        {
            if (_instance == null)
            {
                _instance = new EventTaskManagement();
            }
            return _instance;
        }

        public Studio getStudio()
        {
            return _studio;
        }

        public bool runEventHendler(TextBox textBox)
        {
            _isRunning = true;
            _thread = new Thread(() => 
            {
                Thread.CurrentThread.IsBackground = true;
                _tokenSource = new CancellationTokenSource();
                runRandomTask(textBox);
            });
            _thread.Start();
            return true;
        }

        public bool stopEventHendler(TextBox logBox)
        {
            _isRunning = false;
            if (_thread != null)
            {
                _tokenSource.Cancel();
                _thread.Abort();
            }
            return false;
        }

        private async void logDelay(WorkerTask task, TextBox logBox)
        {
            logBox.AppendText(task.ToString() + Environment.NewLine);
            await Task.Delay(task.getTimeRequired() * 1000, _tokenSource.Token)
                .ContinueWith(t=> _logFinishEvent?.Invoke(task, logBox));
        }
        
        public async void runRandomTask(TextBox logBox)
        {
            WorkerTask task = new CoderTask();
            Random random = new Random();
            while (_isRunning)
            {
                await Task.Delay(random.Next(1, 10) * 1000, _tokenSource.Token)
                    .ContinueWith(t => executeRandomTask(task, logBox));
            }
        }

        private void executeRandomTask(WorkerTask task, TextBox logBox)
        {
            if (_tokenSource.IsCancellationRequested)
            {
                return;
            }
            task = _studio.getRandomTask();
            _logStartEvent?.Invoke(task, logBox);
        }

        private void executeFinishTask(WorkerTask task, TextBox logBox)
        {
            if (_tokenSource.IsCancellationRequested)
            {
                return;
            }
            logBox.AppendText(task.ToStringFinishTask() + Environment.NewLine);
        }
    }
}