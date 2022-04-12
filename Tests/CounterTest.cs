using lab2.Coder.Tasks;
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
    }
}