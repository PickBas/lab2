﻿using lab2.Coder.Tasks;
using lab2.ProjectManager.Tasks;
using lab2.Studio;

namespace lab2.Coder;

public class CoderEntity : EntityManagement
{
    public List <WorkerTask> coderTasks { get; set; }

    public CoderEntity()
    {
        coderTasks = new List<WorkerTask>();
        coderTasks.Add(new CoderTask());
        coderTasks.Add(new CoderTask("Review code", 15));
        coderTasks.Add(new CoderTask("Merge block of code", 40));
    }

    public void addTask(WorkerTask task)
    {
        coderTasks.Add(task);
    }

    public void addTask(string description, int timeRequired)
    {
        coderTasks.Add(new CoderTask(description, timeRequired));
    }
}