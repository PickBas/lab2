namespace lab2.ProjectManager.Tasks;

public sealed class AnalyzePerformance : TaskManagement
{
    public string description { get; set; }
    public List<Tuple<int, string>> possibleActivities { get; set; }
    public int timeRequired { get; set; }

    private static AnalyzePerformance _instance;
    
    
    private AnalyzePerformance()
    {
        possibleActivities = new List<Tuple<int, string>>();
        var timeReq = new[] {5, 10, 15};
        possibleActivities.Add(new Tuple<int, string>(timeReq[0], "Analyze coder performance"));
        possibleActivities.Add(new Tuple<int, string>(timeReq[1], "Analyze designer performance"));
        possibleActivities.Add(new Tuple<int, string>(timeReq[2], "Analyze group performance"));
        
        timeRequired = timeReq[new Random().Next(timeReq.Length)];
        description = possibleActivities[timeRequired].Item2;
    }

    public static AnalyzePerformance getInstance()
    {
        if (_instance == null)
        {
            _instance = new AnalyzePerformance();
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