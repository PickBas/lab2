using lab2.ProjectManager.Tasks;
using lab2.Studio;

namespace lab2.ProjectManager;

public class ProjectManagerEntity : EntityManagement
{
    public List<WorkerTask> projectManagerTasks { get; set; }

    public ProjectManagerEntity()
    {
        projectManagerTasks = new List<WorkerTask>();
        projectManagerTasks.Add(new AnalyzePerformance());
        projectManagerTasks.Add(new AnalyzePerformance("Analyze designer performance", 20));
        projectManagerTasks.Add(new AnalyzePerformance("Analyze group performance", 25));
    }

    public void addTask(WorkerTask task)
    {
        projectManagerTasks.Add(task);
    }

    public void addTask(string description, int timeRequired)
    {
        projectManagerTasks.Add(new AnalyzePerformance(description, timeRequired));
    }
}