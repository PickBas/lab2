using lab2.ProjectManager.Tasks;

namespace lab2.Designer.Tasks;

public sealed class DesignerTask : TaskManagement
{
    public string description { get; set; }
    public Dictionary<int, string> possibleActivities { get; set; }
    public int timeRequired { get; set; }
    private static DesignerTask _instance;

    
    
    private DesignerTask()
    {
        possibleActivities = new Dictionary<int, string>();
        var timeReq = new[] {15, 30, 40};
        possibleActivities.Add(timeReq[0], "Come up with an idea.");
        possibleActivities.Add(timeReq[1], "Create sketch.");
        possibleActivities.Add(timeReq[2], "Draw.");
        timeRequired = timeReq[new Random().Next(timeReq.Length)];
        description = possibleActivities[timeRequired];
    }
    
    public static DesignerTask getInstance()
    {
        if (_instance == null)
        {
            _instance = new DesignerTask();
        }

        return _instance;
    }

    public void appendActivity(string activity, int timeRequired)
    {
        possibleActivities.Add(timeRequired, activity);
        this.timeRequired = timeRequired;
        description = activity;
    }

    public double getPorpability()
    {
        return 1 / possibleActivities.Count * 100;
    }

    public string getLogString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
}