using lab2.ProjectManager.Tasks;

namespace lab2.Coder.Tasks
{

    public class CoderTask : WorkerTask
    {
        public string description { get; set; }
        public int timeRequired { get; set; }

        public CoderTask()
        {
            description = "Code block of code";
            timeRequired = 30;
        }

        public CoderTask(string description, int timeRequired)
        {
            this.description = description;
            this.timeRequired = timeRequired;
        }

        public override bool Equals(object obj)
        {
            CoderTask coderTask2 = (CoderTask) obj;
            return coderTask2.description == description;
        }

        public override string ToString()
        {
            return description + " Estimated time: " + timeRequired + " seconds.";
        }
    }
}