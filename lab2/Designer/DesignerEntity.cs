using lab2.Designer.Tasks;
using lab2.ProjectManager.Tasks;
using lab2.Studio;
using System.Collections.Generic;

namespace lab2.Designer
{

    public class DesignerEntity : EntityManagement
    {
        public List<WorkerTask> designerTasks { get; set; }

        public DesignerEntity()
        {
            designerTasks = new List<WorkerTask>();
            designerTasks.Add(new DesignerTask());
            designerTasks.Add(new DesignerTask("Create sketch", 50));
            designerTasks.Add(new DesignerTask("Draw", 60));
        }

        public void addTask(WorkerTask task)
        {
            designerTasks.Add(task);
        }

        public void addTask(string description, int timeRequired)
        {
            designerTasks.Add(new DesignerTask(description, timeRequired));
        }

        public override bool Equals(object obj)
        {
            DesignerEntity designerEntity = (DesignerEntity) obj;
            return designerEntity.designerTasks.Equals(designerTasks);
        }
    }
}