using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2.Coder.Tasks
{

    public sealed class CoderTaskCounter
    {
        public List<Tuple<DateTime, CoderTask>> coderTasks { get; set; }
        private static CoderTaskCounter _instance;

        private CoderTaskCounter()
        {
            coderTasks = new List<Tuple<DateTime, CoderTask>>();
        }

        public static CoderTaskCounter getInstance()
        {
            if (_instance == null)
            {
                _instance = new CoderTaskCounter();
            }

            return _instance;
        }

        public void addTask(CoderTask coderTask)
        {
            coderTasks.Add(new Tuple<DateTime, CoderTask>(DateTime.Now, coderTask));
        }

        public List<Tuple<double, CoderTask>> getProbability()
        {
            var coderTasksSorted = coderTasks
                .OrderBy(o => o.Item2.description)
                .ToList()
                .Select(o => o.Item2)
                .ToList()
                .GroupBy(o => new {o.description, o.timeRequired})
                .Where(x => x.Count() > 1)
                .Select(y => new { coderTask = y.Key, amount = y.Count() })
                .ToList();
            List<Tuple<double, CoderTask>> result = new List<Tuple<double, CoderTask>>();
            foreach (var entity in coderTasksSorted)
            {
                var probability = (double)entity.amount / (double)coderTasks.Count * 100;
                result.Add(new Tuple<double, CoderTask>(probability, 
                    new CoderTask(entity.coderTask.description, entity.coderTask.timeRequired)));
            }
            return result;
        }
    }
}