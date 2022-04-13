using System;
using System.Collections.Generic;
using System.Linq;
using lab2.Studio;

namespace lab2.ProjectManager.Tasks
{

    public sealed class ProjectManagerTaskCounter : CounterManagement
    {
        public List<Tuple<DateTime, ProjectManagerTask>> projectManagerTasks { get; set; }
        private static ProjectManagerTaskCounter _instance;

        private ProjectManagerTaskCounter()
        {
            projectManagerTasks = new List<Tuple<DateTime, ProjectManagerTask>>();
        }

        public static ProjectManagerTaskCounter getInstance()
        {
            if (_instance == null)
            {
                _instance = new ProjectManagerTaskCounter();
            }

            return _instance;
        }

        public void addTask(WorkerTask projectManagerTask)
        {
            projectManagerTasks.Add(new Tuple<DateTime, ProjectManagerTask>(DateTime.Now, (ProjectManagerTask)projectManagerTask));
        }

        public List<Tuple<double, WorkerTask>> getProbability()
        {
            var projectManagerTasksOrdered = projectManagerTasks
                .OrderBy(o => o.Item2.description)
                .ToList()
                .Select(o => o.Item2)
                .ToList()
                .GroupBy(o => new {o.description, o.timeRequired})
                .Where(x => x.Count() > 1)
                .Select(y => new { projectManagerTask = y.Key, amount = y.Count() })
                .ToList();
            List<Tuple<double, WorkerTask>> result = new List<Tuple<double, WorkerTask>>();
            foreach (var entity in projectManagerTasksOrdered)
            {
                var probability = (double)entity.amount / (double)projectManagerTasks.Count * 100;
                result.Add(new Tuple<double, WorkerTask>(
                    probability,
                    new ProjectManagerTask(
                        entity.projectManagerTask.description,
                        entity.projectManagerTask.timeRequired)));
            }
            return result;
        }
    }
}