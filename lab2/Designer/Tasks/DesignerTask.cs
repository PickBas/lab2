using lab2.ProjectManager.Tasks;

namespace lab2.Designer.Tasks;

public class DesignerTask : WorkerTask
{
    public string description { get; set; }
    public int timeRequired { get; set; }

    public DesignerTask()
    {
        description = "Come up with an idea";
        timeRequired = 15;
    }

    public DesignerTask(string description, int timeRequired)
    {
        this.description = description;
        this.timeRequired = timeRequired;
    }

    public bool @equals(WorkerTask workerTask)
    {
        var task = (DesignerTask) workerTask;
        return description == task.description;
    }

    public string ToString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
}