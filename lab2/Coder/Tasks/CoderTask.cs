﻿using lab2.ProjectManager.Tasks;

namespace lab2.Coder.Tasks;

public sealed class CoderTask : TaskManagement
{
    public string description { get; set; }
    public Dictionary<int, string> possibleActivities { get; set; }
    public int timeRequired { get; set; }

    private static CoderTask _instance;
    
    
    public CoderTask()
    {
        possibleActivities = new Dictionary<int, string>();
        var timeReq = new[] {40, 45, 50};
        possibleActivities.Add(40, "Review code");
        possibleActivities.Add(45, "Write block of code");
        possibleActivities.Add(50, "Merge pull request");

        timeRequired = timeReq[new Random().Next(timeReq.Length)];
        description = possibleActivities[timeRequired];
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