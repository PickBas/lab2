using lab2.ProjectManager.Tasks;

namespace lab2.ProjectManager;

public class ProjectManagerEntity
{
    public WorkerTask CurrentWorkerTask { get; set; }

    public ProjectManagerEntity()
    {
        CurrentWorkerTask = AnalyzePerformance.getInstance();
    }

}