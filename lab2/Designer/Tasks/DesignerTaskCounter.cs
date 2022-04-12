using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2.Designer.Tasks
{

    public sealed class DesignerTaskCounter
    {
        public List<Tuple<DateTime, DesignerTask>> DesignerTasks { get; set; }
        private static DesignerTaskCounter _instance;

        private DesignerTaskCounter()
        {
            DesignerTasks = new List<Tuple<DateTime, DesignerTask>>();
        }

        public static DesignerTaskCounter getInstance()
        {
            if (_instance == null)
            {
                _instance = new DesignerTaskCounter();
            }

            return _instance;
        }

        public void addTask(DesignerTask designerTask)
        {
            DesignerTasks.Add(new Tuple<DateTime, DesignerTask>(DateTime.Now, designerTask));
        }

        public List<Tuple<double, DesignerTask>> getProbability()
        {
            List<DesignerTask> DesignerTasksSorted = DesignerTasks
                .OrderBy(o => o.Item2.description)
                .ToList()
                .Select(o => o.Item2).ToList();
            List<Tuple<int, DesignerTask>> amounts = new List<Tuple<int, DesignerTask>>();
            DesignerTask currentTask = DesignerTasksSorted[0];
            int counter = 1;
            for (int i = 1; i < DesignerTasksSorted.Count; ++i)
            {
                if (DesignerTasksSorted[i].Equals(DesignerTasksSorted[i - 1]))
                {
                    ++counter;
                }
                else
                {
                    amounts.Add(new Tuple<int, DesignerTask>(counter, currentTask));
                    counter = 0;
                    currentTask = DesignerTasksSorted[i];
                }
            }
            if (amounts.Count != 0)
            {
                ++counter;
            }
            amounts.Add(new Tuple<int, DesignerTask>(counter, currentTask));
            List<Tuple<double, DesignerTask>> result = new List<Tuple<double, DesignerTask>>();
            foreach (var entity in amounts)
            {
                var probability = (double)entity.Item1 / (double)DesignerTasks.Count * 100;
                result.Add(new Tuple<double, DesignerTask>(probability, entity.Item2));
            }
            return result;
        }
    }
}