namespace lab2.ProjectManager.Tasks;

public class AnalyzePerformance : WorkerTask
{
    public string description { get; set; }
    public int timeRequired { get; set; }

    public AnalyzePerformance()
    {
        description = "Analyze coder performance";
        timeRequired = 5;
    }

    public AnalyzePerformance(string description, int timeRequired)
    {
        this.description = description;
        this.timeRequired = timeRequired;
    }
    
    public string ToString()
    {
        return description + " Estimated time: " + timeRequired + " seconds.";
    }
}