namespace lab2.ProjectManager.Tasks;

public interface TaskManagement
{
    void appendActivity(string activity, int timeRequired);
    double getPorpability();
    string getLogString();
}