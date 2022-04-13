using System;
using System.Linq;
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
        public CoderEntity coder { get; set; }
        public DesignerEntity designer { get; set; }
        public ProjectManagerEntity projectManager { get; set; }
        private bool isRunning;
        private Thread _thread;
        private CancellationTokenSource _tokenSource;
        private static EventTaskManagement _instance;

        private EventTaskManagement(CoderEntity coder,
            DesignerEntity designer,
            ProjectManagerEntity projectManager)
        {
            this.coder = coder;
            this.designer = designer;
            this.projectManager = projectManager;
            isRunning = false;
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
            isRunning = true;
            if (_thread == null)
            {
                return false;
            }
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
            isRunning = false;
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
            while (isRunning)
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
                    task = coder.getRandomTask();
                    logDelay(task, logBox);
                    break;
                case 1:
                    task = designer.getRandomTask();
                    logDelay(task, logBox);
                    break;
                case 2:
                    task = projectManager.getRandomTask();
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