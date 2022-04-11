﻿namespace lab2.ProjectManager.Tasks;

public class ProjectManagerTask : WorkerTask
{
    public string description { get; set; }
    public int timeRequired { get; set; }

    public ProjectManagerTask()
    {
        description = "Analyze coder performance";
        timeRequired = 5;
    }

    public ProjectManagerTask(string description, int timeRequired)
    {
        this.description = description;
        this.timeRequired = timeRequired;
    }

    public bool @equals(WorkerTask workerTask)
    {
        var task = (ProjectManagerTask) workerTask;
        return description == task.description;
    }

    public string ToString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
}