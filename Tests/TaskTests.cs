using System.Collections.Generic;
using lab2.Coder.Tasks;
using lab2.Studio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void coderTasksCheck()
        {
            Studio studio = new Studio();
            var coderTasks = new List<CoderTask>();
            coderTasks.Add(new CoderTask());
            coderTasks.Add(new CoderTask("Review code", 15));
            coderTasks.Add(new CoderTask("Merge block of code", 40));
            CollectionAssert.AreEqual(coderTasks, studio.coder.coderTasks);
        }
    }
}