using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2.Coder.Tasks
{

    public sealed class CoderTaskCounter
    {
        public List<CoderTask> coderTasks { get; set; }
        private static CoderTaskCounter _instance;

        private CoderTaskCounter()
        {
            coderTasks = new List<CoderTask>();
        }

        public CoderTaskCounter getInstance()
        {
            if (_instance == null)
            {
                _instance = new CoderTaskCounter();
            }

            return _instance;
        }

        public void addTask(CoderTask coderTask)
        {
            coderTasks.Add(coderTask);
        }

        public List<Tuple<double, CoderTask>> getPropability()
        {
            List<CoderTask> coderTasksSorted = coderTasks.OrderBy(o => o.description).ToList();
            List<Tuple<int, CoderTask>> amounts = new List<Tuple<int, CoderTask>>();
            CoderTask currentTask = coderTasksSorted.ElementAt(0);
            int counter = 1;
            for (int i = 1; i < coderTasksSorted.Count; ++i)
            {
                if (coderTasksSorted.ElementAt(i).Equals(coderTasksSorted.ElementAt(i - 1)))
                {
                    ++counter;
                }
                else
                {
                    amounts.Add(new Tuple<int, CoderTask>(counter, currentTask));
                    counter = 1;
                    currentTask = coderTasksSorted.ElementAt(i);
                }
            }

            List<Tuple<double, CoderTask>> result = new List<Tuple<double, CoderTask>>();
            foreach (var entity in amounts)
            {
                var propability = (double)entity.Item1 / (double)coderTasks.Count * 100;
                result.Add(new Tuple<double, CoderTask>(propability, entity.Item2));
            }
            return result;
        }
    }
}