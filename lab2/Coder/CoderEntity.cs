using System;
using lab2.Coder.Tasks;
using lab2.ProjectManager.Tasks;
using lab2.Studio;
using System.Collections.Generic;

namespace lab2.Coder
{

    public class CoderEntity : EntityManagement
    {
        public List<WorkerTask> coderTasks { get; set; }
        private Random _random;

        public CoderEntity()
        {
            coderTasks = new List<WorkerTask>();
            _random = new Random();
            coderTasks.Add(new CoderTask());
            coderTasks.Add(new CoderTask("Review code", 15));
            coderTasks.Add(new CoderTask("Merge block of code", 40));
        }

        public int getAmountOfActivities()
        {
            return coderTasks.Count;
        }

        public WorkerTask getRandomTask()
        {
            return coderTasks[_random.Next(coderTasks.Count)];
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