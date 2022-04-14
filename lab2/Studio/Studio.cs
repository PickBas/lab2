using System;
using lab2.Coder;
using lab2.Coder.Tasks;
using lab2.Designer;
using lab2.Designer.Tasks;
using lab2.ProjectManager;
using lab2.ProjectManager.Tasks;

namespace lab2.Studio
{
    public class Studio
    {
        private readonly EntityManagement _coder;
        private readonly EntityManagement _designer;
        private readonly EntityManagement _projectManager;
        public CounterManagement coderTaskCounter { get; }
        public CounterManagement designerTaskCounter { get; }
        public CounterManagement projectManagerTaskCounter { get; }
        
        public Studio()
        {
            _coder = new CoderEntity();
            _designer = new DesignerEntity();
            _projectManager = new ProjectManagerEntity();
            coderTaskCounter = CoderTaskCounter.getInstance();
            designerTaskCounter = DesignerTaskCounter.getInstance();
            projectManagerTaskCounter = ProjectManagerTaskCounter.getInstance();
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

        public WorkerTask getRandomTask()
        {
            Random random = new Random();
            int entityChoice = random.Next(0, 3);
            WorkerTask task;
            switch (entityChoice)
            {
                case 0:
                    task = _coder.getRandomTask();
                    coderTaskCounter.addTask(task);
                    break;
                case 1:
                    task = _designer.getRandomTask();
                    designerTaskCounter.addTask(task);
                    break;
                case 2:
                    task = _projectManager.getRandomTask();
                    projectManagerTaskCounter.addTask(task);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return task;
        }


    }
}