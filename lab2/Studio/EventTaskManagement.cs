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
        private static EventTaskManagement _instance;

        private EventTaskManagement(CoderEntity coder,
            DesignerEntity designer,
            ProjectManagerEntity projectManager)
        {
            this.coder = coder;
            this.designer = designer;
            this.projectManager = projectManager;
            isRunning = false;
            
        }

        public static EventTaskManagement getInstance(CoderEntity coder,
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
            _thread = new Thread(() => 
            {
                Thread.CurrentThread.IsBackground = true; 
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
                _thread.Abort();
            }

            logBox.AppendText("Stopped simulation" + Environment.NewLine);
            return false;
        }

        private void logDelay(WorkerTask task, TextBox logBox)
        {
            logBox.AppendText(task.ToString() + Environment.NewLine);
            Task.Delay(task.getTimeRequired() * 1000)
                .ContinueWith(t=> logBox.AppendText(
                    "Finished: " + task.getDescription() + Environment.NewLine));
        }
        
        public async void runRandomTask(TextBox logBox)
        {
            Random random = new Random();
            WorkerTask task = new CoderTask();
            while (isRunning)
            {
                await Task.Delay(new Random().Next(1, 10) * 1000)
                    .ContinueWith(t => executeRandomTask(logBox, task));
            }
        }

        private void executeRandomTask(TextBox logBox, WorkerTask task)
        {
            int entityChoice = new Random().Next(0, 3);
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
    }
}