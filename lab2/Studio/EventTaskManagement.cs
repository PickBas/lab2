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
        private readonly CoderEntity _coder;
        private readonly DesignerEntity _designer;
        private readonly ProjectManagerEntity _projectManager;
        public CoderTaskCounter coderTaskCounter { get; }
        public DesignerTaskCounter designerTaskCounter { get; }
        public ProjectManagerTaskCounter projectManagerTaskCounter { get; }
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
            coderTaskCounter = CoderTaskCounter.getInstance();
            designerTaskCounter = DesignerTaskCounter.getInstance();
            projectManagerTaskCounter = ProjectManagerTaskCounter.getInstance();
            _isRunning = false;
            _tokenSource = new CancellationTokenSource();
        }

        public EntityManagement getEntity(string type)
        {
            switch (type)
            {
                case "coder":
                    return _coder;
                case "designer":
                    return _designer;
                case "projectManager":
                    return _projectManager;
            }

            return null;
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
            Random random = new Random();
            while (_isRunning)
            {
                await Task.Delay(random.Next(1, 10) * 1000, _tokenSource.Token)
                    .ContinueWith(t => executeRandomTask(logBox, task));
            }
        }

        private void executeRandomTask(TextBox logBox, WorkerTask task)
        {
            Random random = new Random();
            int entityChoice = random.Next(0, 3);
            if (_tokenSource.IsCancellationRequested)
            {
                return;
            }
            switch (entityChoice)
            {
                case 0:
                    task = _coder.getRandomTask();
                    coderTaskCounter.addTask((CoderTask)task);
                    logDelay(task, logBox);
                    break;
                case 1:
                    task = _designer.getRandomTask();
                    designerTaskCounter.addTask((DesignerTask)task);
                    logDelay(task, logBox);
                    break;
                case 2:
                    task = _projectManager.getRandomTask();
                    projectManagerTaskCounter.addTask((ProjectManagerTask)task);
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