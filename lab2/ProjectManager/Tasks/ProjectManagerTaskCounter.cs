namespace lab2.ProjectManager.Tasks;

public sealed class ProjectManagerTaskCounter
{
    public List<ProjectManagerTask> ProjectManagerTasks { get; set; }
    private static ProjectManagerTaskCounter _instance;

    private ProjectManagerTaskCounter()
    {
        ProjectManagerTasks = new List<ProjectManagerTask>();
    }

    public ProjectManagerTaskCounter getInstance()
    {
        if (_instance == null)
        {
            _instance = new ProjectManagerTaskCounter();
        }

        return _instance;
    }

    public void addTask(ProjectManagerTask ProjectManagerTask)
    { 
        ProjectManagerTasks.Add(ProjectManagerTask);
    }

    public List<Tuple<double, ProjectManagerTask>> getPropability()
    {
        List<ProjectManagerTask> ProjectManagerTasksSorted = ProjectManagerTasks
            .OrderBy(o => o.description)
            .ToList();
        List<Tuple<int, ProjectManagerTask>> amounts = new List<Tuple<int, ProjectManagerTask>>();
        ProjectManagerTask currentTask = ProjectManagerTasksSorted.ElementAt(0);
        int counter = 1;
        for (int i = 1; i < ProjectManagerTasksSorted.Count; ++i)
        {
            if (ProjectManagerTasksSorted.ElementAt(i).@equals(ProjectManagerTasksSorted.ElementAt(i - 1)))
            {
                ++counter;
            }
            else
            {
                amounts.Add(new Tuple<int, ProjectManagerTask>(counter, currentTask));
                counter = 1;
                currentTask = ProjectManagerTasksSorted.ElementAt(i);
            }
        }

        List<Tuple<double, ProjectManagerTask>> result = new List<Tuple<double, ProjectManagerTask>>();
        foreach (var entity in amounts)
        {
            var propability = (double)entity.Item1 / (double)ProjectManagerTasks.Count * 100;
            result.Add(new Tuple<double, ProjectManagerTask>(propability, entity.Item2));
        }
        return result;
    }
}