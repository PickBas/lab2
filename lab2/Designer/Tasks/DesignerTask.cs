using lab2.ProjectManager.Tasks;

namespace lab2.Designer.Tasks
{

    public class DesignerTask : WorkerTask
    {
        public string description { get; set; }
        public int timeRequired { get; set; }

        public DesignerTask()
        {
            description = "Come up with an idea";
            timeRequired = 15;
        }

        public DesignerTask(WorkerTask workerTask)
        {
            DesignerTask designerTask = (DesignerTask) workerTask;
            description = designerTask.description;
            timeRequired = designerTask.timeRequired;
        }

        public DesignerTask(string description, int timeRequired)
        {
            this.description = description;
            this.timeRequired = timeRequired;
        }

        public bool @equals(WorkerTask workerTask)
        {
            var task = (DesignerTask)workerTask;
            return description == task.description;
        }

        public string getDescription()
        {
            return description;
        }

        public int getTimeRequired()
        {
            return timeRequired;
        }

        public override string ToString()
        {
            return "Designer: " + description + " Estimated time: " + timeRequired + " seconds.";
        }

        public override bool Equals(object obj)
        {
            DesignerTask task = (DesignerTask) obj;
            return description == task.description;
        }
    }
}