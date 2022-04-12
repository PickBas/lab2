using lab2.Coder.Tasks;
using lab2.Designer.Tasks;
using lab2.ProjectManager.Tasks;
using lab2.Studio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CounterTest
    {
        [TestMethod]
        public void coderTaskCounterProbabilityTest()
        {
            var taskCounter = CoderTaskCounter.getInstance();
            var studio = new Studio();
            taskCounter.addTask((CoderTask)studio.coder.coderTasks[0]);
            taskCounter.addTask((CoderTask)studio.coder.coderTasks[0]);
            taskCounter.addTask((CoderTask)studio.coder.coderTasks[0]);
            Assert.AreEqual(100.00, taskCounter.getProbability()[0].Item1);
            taskCounter.addTask(new CoderTask("Do something", 3));
            taskCounter.addTask(new CoderTask("Do something", 3));
            Assert.AreEqual(60.00, taskCounter.getProbability()[0].Item1);
            Assert.AreEqual(40.00, taskCounter.getProbability()[1].Item1);
        }
        
        [TestMethod]
        public void designerTaskCounterProbabilityTest()
        {
            var taskCounter = DesignerTaskCounter.getInstance();
            var studio = new Studio();
            taskCounter.addTask((DesignerTask)studio.designer.designerTasks[0]);
            taskCounter.addTask((DesignerTask)studio.designer.designerTasks[0]);
            taskCounter.addTask((DesignerTask)studio.designer.designerTasks[0]);
            Assert.AreEqual(100.00, taskCounter.getProbability()[0].Item1);
            taskCounter.addTask(new DesignerTask("Do something", 3));
            taskCounter.addTask(new DesignerTask("Do something", 3));
            Assert.AreEqual(60.00, taskCounter.getProbability()[0].Item1);
            Assert.AreEqual(40.00, taskCounter.getProbability()[1].Item1);
        }
        
        [TestMethod]
        public void projectManagerTaskCounterProbabilityTest()
        {
            var taskCounter = ProjectManagerTaskCounter.getInstance();
            var studio = new Studio();
            taskCounter.addTask((ProjectManagerTask)studio.projectManager.projectManagerTasks[0]);
            taskCounter.addTask((ProjectManagerTask)studio.projectManager.projectManagerTasks[0]);
            taskCounter.addTask((ProjectManagerTask)studio.projectManager.projectManagerTasks[0]);
            Assert.AreEqual(100.00, taskCounter.getProbability()[0].Item1);
            taskCounter.addTask(new ProjectManagerTask("Do something", 3));
            taskCounter.addTask(new ProjectManagerTask("Do something", 3));
            Assert.AreEqual(60.00, taskCounter.getProbability()[0].Item1);
            Assert.AreEqual(40.00, taskCounter.getProbability()[1].Item1);
        }
    }
}