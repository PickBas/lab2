namespace lab2.Designer.Tasks;

public class SendDesign : DesignerTask
{
    public string description { get; set; }
    public Dictionary<int, string> possibleActivities { get; set; }
    public int timeRequired { get; set; }
    
    
    public SendDesign()
    {
        possibleActivities = new Dictionary<int, string>();
        possibleActivities.Add(5, "Send with Telegram");
        possibleActivities.Add(10, "Send with email");

        timeRequired = 5;
        description = possibleActivities[timeRequired];
    }

    public string getLogString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
}