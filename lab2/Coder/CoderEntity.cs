using lab2.Coder.Tasks;
using lab2.ProjectManager.Tasks;

namespace lab2.Coder;

public class CoderEntity
{
    public List <CoderTask> coderTasks { get; set; }

    public CoderEntity(string description, int timeRequired)
    {
        coderTasks = new List<CoderTask>();
        coderTasks.Add(new CoderTask(description, timeRequired));
    }

    public CoderEntity(CoderTask coderTask)
    {
        coderTasks = new List<CoderTask>();
        coderTasks.Add(coderTask);
    }

}