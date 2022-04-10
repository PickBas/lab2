using lab2.Coder.Tasks;

namespace lab2.Coder;

public class Coder
{
    public CoderTask currentTask { get; set; }

    public Coder()
    {
        Random random = new Random();
        int activity = random.Next(1, 4);
        chooseActivity(activity);
    }
    
    public Coder(int activity)
    {
        chooseActivity(activity);
    }

    private void chooseActivity(int activity)
    {
        switch (activity)
        {
            case 1:
                currentTask = new CodeBlockOfCodeTask();
                break;
            case 2:
                currentTask = new WriteDocsTask();
                break;
            case 3:
                currentTask = new MergePullRequest();
                break;
        }
    }

}