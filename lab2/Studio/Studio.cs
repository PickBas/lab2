namespace lab2.Studio;

public sealed class Studio
{
    private List<Coder.Coder> _coders;
    private List<Designer.Designer> _designers;

    private static Studio _instance;

    private Studio()
    {
        
    }

    public Studio getInstance()
    {
        if (_instance == null)
        {
            _instance = new Studio();
        }

        return _instance;
    }

}