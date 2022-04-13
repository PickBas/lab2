using System;
using lab2.Designer.Tasks;
using lab2.ProjectManager.Tasks;
using lab2.Studio;
using System.Collections.Generic;

namespace lab2.Designer
{

    public class DesignerEntity : EntityManagement
    {
        public List<WorkerTask> designerTasks { get; set; }
        private Random _random;

        public DesignerEntity()
        {
            designerTasks = new List<WorkerTask>();
            designerTasks.Add(new DesignerTask());
            designerTasks.Add(new DesignerTask("Create sketch", 50));
            designerTasks.Add(new DesignerTask("Draw", 60));
            _random = new Random();
        }

        public void addTask(string description, int timeRequired)
        {
            designerTasks.Add(new DesignerTask(description, timeRequired));
        }

        public WorkerTask getRandomTask()
        {
            return designerTasks[_random.Next(designerTasks.Count)];

        }

        public override bool Equals(object obj)
        {
            DesignerEntity designerEntity = (DesignerEntity) obj;
            return designerEntity.designerTasks.Equals(designerTasks);
        }
    }
}