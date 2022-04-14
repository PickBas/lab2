using System;
using System.Collections.Generic;
using lab2.ProjectManager.Tasks;

namespace lab2.Studio
{
    public interface CounterManagement
    {
        void addTask(WorkerTask task);
        List<Tuple<DateTime, WorkerTask>> getTasksWithDateTime();
        List<Tuple<double, WorkerTask>> getProbability();
    }
}