using System;
using lab2.ProjectManager.Tasks;
using lab2.Studio;
using System.Collections.Generic;

namespace lab2.ProjectManager { 

    public class ProjectManagerEntity : EntityManagement
    {
        public List<WorkerTask> projectManagerTasks { get; set; }
        private Random _random;

        public ProjectManagerEntity()
        {
            projectManagerTasks = new List<WorkerTask>();
            projectManagerTasks.Add(new ProjectManagerTask());
            projectManagerTasks.Add(new ProjectManagerTask("Analyze designer performance", 20));
            projectManagerTasks.Add(new ProjectManagerTask("Analyze group performance", 25));
            _random = new Random();
        }

        public void addTask(string description, int timeRequired)
        {
            projectManagerTasks.Add(new ProjectManagerTask(description, timeRequired));
        }

        public int getAmountOfActivities()
        {
            return projectManagerTasks.Count;
        }

        public WorkerTask getRandomTask()
        {
            return projectManagerTasks[_random.Next(projectManagerTasks.Count)];

        }

        public override bool Equals(object obj)
        {
            var projectManager2 = (ProjectManagerEntity) obj;
            return projectManagerTasks == projectManager2.projectManagerTasks;
        }
    }
}