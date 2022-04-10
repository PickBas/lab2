using lab2.ProjectManager.Tasks;

namespace lab2.ProjectManager;

public class ProjectManagerEntity
{
    public TaskManagement CurrentTaskManagement { get; set; }

    public ProjectManagerEntity()
    {
        CurrentTaskManagement = AnalyzePerformance.getInstance();
    }

}