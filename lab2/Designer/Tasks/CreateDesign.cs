namespace lab2.Designer.Tasks;

public class CreateDesign : DesignerTask
{
    public string description { get; set; }
    public Dictionary<int, string> possibleActivities { get; set; }
    public int timeRequired { get; set; }
    
    
    public CreateDesign()
    {
        possibleActivities = new Dictionary<int, string>();
        possibleActivities.Add(30, "Create sketch");
        possibleActivities.Add(40, "Draw");

        timeRequired = 30;
        description = possibleActivities[timeRequired];
    }

    public string getLogString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
}