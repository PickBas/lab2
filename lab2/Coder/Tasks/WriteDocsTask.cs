namespace lab2.Coder.Tasks;

public class WriteDocsTask : CoderTask
{
    public string description { get; set; }
    public Dictionary<int, string> possibleActivities { get; set; }
    public int timeRequired { get; set; }
    
    
    public WriteDocsTask()
    {
        possibleActivities = new Dictionary<int, string>();
        possibleActivities.Add(15, "Document character logic.");
        possibleActivities.Add(20, "Document environment logic.");
        possibleActivities.Add(25, "Document NPC logic.");

        timeRequired = 15;
        description = possibleActivities[timeRequired];
    }

    public string getLogString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
}