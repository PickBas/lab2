namespace lab2.ProjectManager.Tasks { 
    public interface WorkerTask
    {
        string getDescription();
        int getTimeRequired();
        string ToString();
    }
}