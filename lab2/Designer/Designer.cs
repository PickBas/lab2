using lab2.Designer.Tasks;

namespace lab2.Designer;

public class Designer
{
    public DesignerTask currentTask { get; set; }

    public Designer()
    {
        Random random = new Random();
        int activity = random.Next(1, 4);
        chooseActivity(activity);
    }
    
    public Designer(int activity)
    {
        chooseActivity(activity);
    }

    private void chooseActivity(int activity)
    {
        switch (activity)
        {
            case 1:
                currentTask = new ComeUpWithIdeaTask();
                break;
            case 2:
                currentTask = new CreateDesign();
                break;
            case 3:
                currentTask = new SendDesign();
                break;
        }
    }
}