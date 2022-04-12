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
            List<Tuple<DateTime, CoderTask>> coderTasksSorted = coderTasks
                .OrderBy(o => o.Item2.description)
                .ToList();
            List<Tuple<int, CoderTask>> amounts = new List<Tuple<int, CoderTask>>();
            CoderTask currentTask = coderTasksSorted[0].Item2;
            int counter = 1;
            for (int i = 0; i < coderTasksSorted.Count - 1; ++i)
            {
                if (coderTasksSorted[i].Item2.Equals(coderTasksSorted[i + 1].Item2))
                {
                    ++counter;
                }
                else
                {
                    amounts.Add(new Tuple<int, CoderTask>(counter, currentTask));
                    counter = 0;
                    currentTask = coderTasksSorted[i].Item2;
                }
            }
            if (amounts.Count != 0)
            {
                ++counter;
            }
            amounts.Add(new Tuple<int, CoderTask>(counter, currentTask));
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