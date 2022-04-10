using lab2.Coder;
using lab2.Designer;
using lab2.ProjectManager;

namespace lab2.Studio;

public class Studio
{
    public CoderEntity coder { get; set; }
    private DesignerEntity designer { get; set; }
    private ProjectManagerEntity projectManager { get; set; }


    public Studio()
    {
        coder = new CoderEntity();
        designer = new DesignerEntity();
        projectManager = new ProjectManagerEntity();
    }
    
}