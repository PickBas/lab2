namespace lab2.Coder.Tasks;

public class MergePullRequest : CoderTask
{
    public string description { get; set; }
    public Dictionary<int, string> possibleActivities { get; set; }
    public int timeRequired { get; set; }
    
    
    public MergePullRequest()
    {
        possibleActivities = new Dictionary<int, string>();
        possibleActivities.Add(40, "Review character logic.");
        possibleActivities.Add(45, "Review environment logic.");
        possibleActivities.Add(50, "Review NPC logic.");

        timeRequired = 40;
        description = possibleActivities[timeRequired];
    }

    public string getLogString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
}