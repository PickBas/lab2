using lab2.ProjectManager.Tasks;

namespace lab2.Studio;

public interface EntityManagement
{
    void addTask(WorkerTask task);
    void addTask(string description, int timeRequired);
}