using lab2.ProjectManager.Tasks;

namespace lab2.Coder.Tasks;

public sealed class CoderTask : TaskManagement
{
    public string description { get; set; }
    public List<Tuple<int, string>> possibleActivities { get; set; }
    public int timeRequired { get; set; }

    private static CoderTask _instance;
    
    
    public CoderTask()
    {
        possibleActivities = new List<Tuple<int, string>>();
        var timeReq = new[] {40, 45, 50};
        possibleActivities.Add(new Tuple<int, string>(timeReq[0], "Review code"));
        possibleActivities.Add(new Tuple<int, string>(timeReq[1], "Write block of code"));
        possibleActivities.Add(new Tuple<int, string>(timeReq[2], "Merge pull request"));

        timeRequired = timeReq[new Random().Next(timeReq.Length)];
        description = possibleActivities[timeRequired].Item2;
    }

    public static CoderTask getInstance()
    {
        if (_instance == null)
        {
            _instance = new CoderTask();
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