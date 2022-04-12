namespace lab2.ProjectManager.Tasks { 
    public interface WorkerTask
    {
        bool equals(WorkerTask workerTask);
        string ToString();
    }
}