namespace lab2.Designer.Tasks;

public class ComeUpWithIdeaTask : DesignerTask
{
    public string description { get; set; }
    public Dictionary<int, string> possibleActivities { get; set; }
    public int timeRequired { get; set; }
    
    
    public ComeUpWithIdeaTask()
    {
        possibleActivities = new Dictionary<int, string>();
        possibleActivities.Add(10, "Ask a friend for help.");
        possibleActivities.Add(60, "Come up with an idea.");

        timeRequired = 10;
        description = possibleActivities[timeRequired];
    }

    public string getLogString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
}