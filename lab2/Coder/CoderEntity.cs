using lab2.Coder.Tasks;
using lab2.ProjectManager.Tasks;
using lab2.Studio;
using System.Collections.Generic;

namespace lab2.Coder
{

    public class CoderEntity : EntityManagement
    {
        public List<CoderTask> coderTasks { get; set; }

        public CoderEntity()
        {
            coderTasks = new List<CoderTask>();
            coderTasks.Add(new CoderTask());
            coderTasks.Add(new CoderTask("Review code", 15));
            coderTasks.Add(new CoderTask("Merge block of code", 40));
        }

        public void addTask(WorkerTask task)
        {
            coderTasks.Add((CoderTask)task);
        }

        public void addTask(string description, int timeRequired)
        {
            coderTasks.Add(new CoderTask(description, timeRequired));
        }

        public override bool Equals(object obj)
        {
            CoderEntity obj2 = (CoderEntity) obj;
            return coderTasks == obj2.coderTasks;
        }
    }
}