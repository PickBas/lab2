namespace lab2.ProjectManager.Tasks;

public sealed class AnalyzePerformance : TaskManagement
{
    public string description { get; set; }
    public Dictionary<int, string> possibleActivities { get; set; }
    public int timeRequired { get; set; }

    private static AnalyzePerformance _instance;
    
    
    private AnalyzePerformance()
    {
        possibleActivities = new Dictionary<int, string>();
        var timeReq = new[] {5, 10, 15};
        possibleActivities.Add(timeReq[0], "Analyze coder performance");
        possibleActivities.Add(timeReq[1], "Analyze designer performance");
        possibleActivities.Add(timeReq[2], "Analyze group performance");
        
        timeRequired = timeReq[new Random().Next(timeReq.Length)];
        description = possibleActivities[timeRequired];
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