using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab2.Coder;
using lab2.Coder.Tasks;
using lab2.Designer;
using lab2.ProjectManager;
using lab2.ProjectManager.Tasks;

namespace lab2.Studio
{
    public sealed class EventTaskManagement
    {
        private readonly CoderEntity _coder;
        private readonly DesignerEntity _designer;
        private readonly ProjectManagerEntity _projectManager;
        private bool _isRunning;
        private Thread _thread;
        private CancellationTokenSource _tokenSource;
        private static EventTaskManagement _instance;

        private EventTaskManagement(CoderEntity coder,
            DesignerEntity designer,
            ProjectManagerEntity projectManager)
        {
            _coder = coder;
            _designer = designer;
            _projectManager = projectManager;
            _isRunning = false;
            _tokenSource = new CancellationTokenSource();
        }

        public static EventTaskManagement getInstance(
            CoderEntity coder,
            DesignerEntity designer,
            ProjectManagerEntity projectManager)
        {
            if (_instance == null)
            {
                _instance = new EventTaskManagement(coder, designer, projectManager);
            }

            return _instance;
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
                runRandomTask(logBox);
                _tokenSource.Cancel();
                _thread.Abort();
            }
            return false;
        }

        private async void logDelay(WorkerTask task, TextBox logBox)
        {
            logBox.AppendText(task.ToString() + Environment.NewLine);
            await Task.Delay(task.getTimeRequired() * 1000, _tokenSource.Token)
                .ContinueWith(t=> executeFinishTask(logBox, task));
        }
        
        public async void runRandomTask(TextBox logBox)
        {
            WorkerTask task = new CoderTask();
            while (_isRunning)
            {
                await Task.Delay(new Random().Next(1, 10) * 1000, _tokenSource.Token)
                    .ContinueWith(t => executeRandomTask(logBox, task));
            }
        }

        private void executeRandomTask(TextBox logBox, WorkerTask task)
        {
            int entityChoice = new Random().Next(0, 3);
            if (_tokenSource.IsCancellationRequested)
            {
                return;
            }
            switch (entityChoice)
            {
                case 0:
                    task = _coder.getRandomTask();
                    logDelay(task, logBox);
                    break;
                case 1:
                    task = _designer.getRandomTask();
                    logDelay(task, logBox);
                    break;
                case 2:
                    task = _projectManager.getRandomTask();
                    logDelay(task, logBox);
                    break;
            }
        }

        private void executeFinishTask(TextBox logBox, WorkerTask task)
        {
            if (_tokenSource.IsCancellationRequested)
            {
                return;
            }
            logBox.AppendText(
                "Finished: " + task.getDescription() + Environment.NewLine);
        }
    }
}