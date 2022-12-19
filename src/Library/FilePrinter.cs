using System.IO;
namespace Full_GRASP_And_SOLID.Library;

public class FilePrinter : IPrinter
{
    public void PrintBuilding(IStringConverter text)
    {
        File.WriteAllText("Building.txt", text.GetTextToPrint());
    }
}