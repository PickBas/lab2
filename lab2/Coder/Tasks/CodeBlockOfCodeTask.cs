namespace lab2.Coder.Tasks;

public class CodeBlockOfCodeTask : CoderTask
{
    public string description { get; set; }
    public Dictionary<int, string> possibleActivities { get; set; }
    public int timeRequired { get; set; }
    
    
    public CodeBlockOfCodeTask()
    {
        possibleActivities = new Dictionary<int, string>();
        possibleActivities.Add(30, "Code character logic.");
        possibleActivities.Add(60, "Code environment logic.");
        possibleActivities.Add(45, "Code NPC logic.");

        timeRequired = 30;
        description = possibleActivities[timeRequired];
    }

    public string getLogString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
    
    
}