using lab2.ProjectManager.Tasks;

namespace lab2.Designer.Tasks;

public sealed class DesignerTask : TaskManagement
{
    public string description { get; set; }
    public List<Tuple<int, string>> possibleActivities { get; set; }
    public int timeRequired { get; set; }
    private static DesignerTask _instance;

    
    
    private DesignerTask()
    {
        possibleActivities = new List<Tuple<int, string>>();
        var timeReq = new[] {15, 30, 40};
        possibleActivities.Add(new Tuple<int, string>(timeReq[0], "Come up with an idea."));
        possibleActivities.Add(new Tuple<int, string>(timeReq[1], "Create sketch."));
        possibleActivities.Add(new Tuple<int, string>(timeReq[2], "Draw."));
        timeRequired = timeReq[new Random().Next(timeReq.Length)];
        description = possibleActivities[timeRequired].Item2;
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
        possibleActivities.Add(new Tuple<int, string>(timeRequired, activity));
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