using lab2.Coder.Tasks;
using lab2.ProjectManager.Tasks;

namespace lab2.Coder;

public class CoderEntity
{
    public TaskManagement currentTask { get; set; }

    public CoderEntity()
    {
        currentTask = CoderTask.getInstance();
    }

}