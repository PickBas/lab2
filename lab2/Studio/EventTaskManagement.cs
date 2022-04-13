using System;
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
        private static EventTaskManagement _instance;

        private EventTaskManagement(CoderEntity coder,
            DesignerEntity designer,
            ProjectManagerEntity projectManager)
        {
            this.coder = coder;
            this.designer = designer;
            this.projectManager = projectManager;
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

        public void runRandomTask()
        {
            Random random = new Random();
            int entityChoice = random.Next(0, 3);
            WorkerTask task = new CoderTask();
            switch (entityChoice)
            {
                case 0:
                    task = new CoderTask(coder.getRandomTask());
                    break;
                case 1:
                    task = new DesignerTask(designer.getRandomTask());
                    break;
                case 2:
                    task = new ProjectManagerTask(projectManager.getRandomTask());
                    break;
            }
        }
    }
}