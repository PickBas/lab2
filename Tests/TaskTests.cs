using System.Collections.Generic;
using lab2.Coder.Tasks;
using lab2.Designer.Tasks;
using lab2.ProjectManager.Tasks;
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
        
        [TestMethod]
        public void designerTasksCheck()
        {
            Studio studio = new Studio();
            var designerTasks = new List<DesignerTask>();
            designerTasks.Add(new DesignerTask());
            designerTasks.Add(new DesignerTask("Create sketch", 50));
            designerTasks.Add(new DesignerTask("Draw", 60));
            CollectionAssert.AreEqual(designerTasks, studio.designer.designerTasks);
        }
        
        [TestMethod]
        public void projectManagerTasksCheck()
        {
            Studio studio = new Studio();
            var projectManagerTasks = new List<ProjectManagerTask>();
            projectManagerTasks.Add(new ProjectManagerTask());
            projectManagerTasks.Add(new ProjectManagerTask("Analyze designer performance", 20));
            projectManagerTasks.Add(new ProjectManagerTask("Analyze group performance", 25));
            CollectionAssert.AreEqual(projectManagerTasks, studio.projectManager.projectManagerTasks);
        }
    }
}