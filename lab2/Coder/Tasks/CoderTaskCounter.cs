using System;
using System.Collections.Generic;
using System.Linq;
using lab2.ProjectManager.Tasks;
using lab2.Studio;

namespace lab2.Coder.Tasks
{

    public sealed class CoderTaskCounter : CounterManagement
    {
        private List<Tuple<DateTime, CoderTask>> _coderTasks;
        private static CoderTaskCounter _instance;
        
        private CoderTaskCounter()
        {
            _coderTasks = new List<Tuple<DateTime, CoderTask>>();
        }

        public static CoderTaskCounter getInstance()
        {
            if (_instance == null)
            {
                _instance = new CoderTaskCounter();
            }

            return _instance;
        }

        public void addTask(WorkerTask coderTask)
        {
            _coderTasks.Add(new Tuple<DateTime, CoderTask>(DateTime.Now, (CoderTask)coderTask));
        }

        public List<Tuple<DateTime, WorkerTask>> getTasksWithDateTime()
        {
            List<Tuple<DateTime, WorkerTask>> tasks = new List<Tuple<DateTime, WorkerTask>>();
            foreach (var task in _coderTasks)
            {
                tasks.Add(new Tuple<DateTime, WorkerTask>(task.Item1, task.Item2));
            }
            return tasks;
        }

        public List<Tuple<double, WorkerTask>> getProbability()
        {
            var coderTasksSorted = _coderTasks
                .OrderBy(o => o.Item2.description)
                .ToList()
                .Select(o => o.Item2)
                .ToList()
                .GroupBy(o => new {o.description, o.timeRequired})
                .Where(x => x.Any())
                .Select(y => new { coderTask = y.Key, amount = y.Count() })
                .ToList();
            List<Tuple<double, WorkerTask>> result = new List<Tuple<double, WorkerTask>>();
            foreach (var entity in coderTasksSorted)
            {
                var probability = (double)entity.amount / (double)_coderTasks.Count * 100;
                result.Add(new Tuple<double, WorkerTask>(probability, 
                    new CoderTask(entity.coderTask.description, entity.coderTask.timeRequired)));
            }
            return result;
        }
    }
}