using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2.Designer.Tasks
{

    public sealed class DesignerTaskCounter
    {
        public List<DesignerTask> DesignerTasks { get; set; }
        private static DesignerTaskCounter _instance;

        private DesignerTaskCounter()
        {
            DesignerTasks = new List<DesignerTask>();
        }

        public DesignerTaskCounter getInstance()
        {
            if (_instance == null)
            {
                _instance = new DesignerTaskCounter();
            }

            return _instance;
        }

        public void addTask(DesignerTask DesignerTask)
        {
            DesignerTasks.Add(DesignerTask);
        }

        public List<Tuple<double, DesignerTask>> getPropability()
        {
            List<DesignerTask> DesignerTasksSorted = DesignerTasks.OrderBy(o => o.description).ToList();
            List<Tuple<int, DesignerTask>> amounts = new List<Tuple<int, DesignerTask>>();
            DesignerTask currentTask = DesignerTasksSorted.ElementAt(0);
            int counter = 1;
            for (int i = 1; i < DesignerTasksSorted.Count; ++i)
            {
                if (DesignerTasksSorted.ElementAt(i).@equals(DesignerTasksSorted.ElementAt(i - 1)))
                {
                    ++counter;
                }
                else
                {
                    amounts.Add(new Tuple<int, DesignerTask>(counter, currentTask));
                    counter = 1;
                    currentTask = DesignerTasksSorted.ElementAt(i);
                }
            }

            List<Tuple<double, DesignerTask>> result = new List<Tuple<double, DesignerTask>>();
            foreach (var entity in amounts)
            {
                var propability = (double)entity.Item1 / (double)DesignerTasks.Count * 100;
                result.Add(new Tuple<double, DesignerTask>(propability, entity.Item2));
            }
            return result;
        }
    }
}