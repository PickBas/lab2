using lab2.Designer.Tasks;
using lab2.ProjectManager.Tasks;

namespace lab2.Designer;

public class DesignerEntity
{
    public TaskManagement currentTask { get; set; }

    public DesignerEntity()
    {
        currentTask = DesignerTask.getInstance();
    }
}