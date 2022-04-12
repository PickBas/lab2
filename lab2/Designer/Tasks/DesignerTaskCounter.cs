using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2.Designer.Tasks
{

    public sealed class DesignerTaskCounter
    {
        public List<Tuple<DateTime, DesignerTask>> designerTasks { get; set; }
        private static DesignerTaskCounter _instance;

        private DesignerTaskCounter()
        {
            designerTasks = new List<Tuple<DateTime, DesignerTask>>();
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
            designerTasks.Add(new Tuple<DateTime, DesignerTask>(DateTime.Now, designerTask));
        }

        public List<Tuple<double, DesignerTask>> getProbability()
        {
            var designerTasksSorted = designerTasks
                .OrderBy(o => o.Item2.description)
                .ToList()
                .Select(o => o.Item2)
                .ToList()
                .GroupBy(o => new {o.description, o.timeRequired})
                .Where(x => x.Count() > 1)
                .Select(y => new { designerTask = y.Key, amount = y.Count() })
                .ToList();
            List<Tuple<double, DesignerTask>> result = new List<Tuple<double, DesignerTask>>();
            foreach (var entity in designerTasksSorted)
            {
                var probability = (double)entity.amount / (double)designerTasks.Count * 100;
                result.Add(new Tuple<double, DesignerTask>(
                    probability,
                    new DesignerTask(entity.designerTask.description,
                        entity.designerTask.timeRequired)));
            }
            return result;
        }
    }
}