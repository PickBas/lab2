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
            WorkerTask task = new CoderTask("Code block of code", 30);
            taskCounter.addTask(task);
            taskCounter.addTask(task);
            taskCounter.addTask(task);
            Assert.AreEqual(100.00, taskCounter.getProbability()[0].Item1);
            taskCounter.addTask(new CoderTask("Do something", 3));
            Assert.AreEqual(75.00, taskCounter.getProbability()[0].Item1);
            Assert.AreEqual(25.00, taskCounter.getProbability()[1].Item1);
            taskCounter.addTask(new CoderTask("Do something", 3));
            Assert.AreEqual(60.00, taskCounter.getProbability()[0].Item1);
            Assert.AreEqual(40.00, taskCounter.getProbability()[1].Item1);
        }
        
        [TestMethod]
        public void designerTaskCounterProbabilityTest()
        {
            var taskCounter = DesignerTaskCounter.getInstance();
            var studio = new Studio();
            WorkerTask task = new DesignerTask("Come up with an idea", 15);
            taskCounter.addTask(task);
            taskCounter.addTask(task);
            taskCounter.addTask(task);
            Assert.AreEqual(100.00, taskCounter.getProbability()[0].Item1);
            taskCounter.addTask(new DesignerTask("Do something", 3));
            Assert.AreEqual(75.00, taskCounter.getProbability()[0].Item1);
            Assert.AreEqual(25.00, taskCounter.getProbability()[1].Item1);
            taskCounter.addTask(new DesignerTask("Do something", 3));
            Assert.AreEqual(60.00, taskCounter.getProbability()[0].Item1);
            Assert.AreEqual(40.00, taskCounter.getProbability()[1].Item1);
        }
        
        [TestMethod]
        public void projectManagerTaskCounterProbabilityTest()
        {
            var taskCounter = ProjectManagerTaskCounter.getInstance();
            var studio = new Studio();
            WorkerTask task = new ProjectManagerTask("Analyze coder performance", 5);
            taskCounter.addTask(task);
            taskCounter.addTask(task);
            taskCounter.addTask(task);
            Assert.AreEqual(100.00, taskCounter.getProbability()[0].Item1);
            taskCounter.addTask(new ProjectManagerTask("Do something", 3));
            Assert.AreEqual(75.00, taskCounter.getProbability()[0].Item1);
            Assert.AreEqual(25.00, taskCounter.getProbability()[1].Item1);
            taskCounter.addTask(new ProjectManagerTask("Do something", 3));
            Assert.AreEqual(60.00, taskCounter.getProbability()[0].Item1);
            Assert.AreEqual(40.00, taskCounter.getProbability()[1].Item1);
        }
    }
}