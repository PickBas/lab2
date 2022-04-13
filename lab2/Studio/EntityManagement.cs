using lab2.ProjectManager.Tasks;

namespace lab2.Studio { 
    public interface EntityManagement
    {
        void addTask(string description, int timeRequired);
        WorkerTask getRandomTask();
    }
}