using System.IO;
namespace Full_GRASP_And_SOLID.Library;

public class FilePrinter : IPrinter
{
    public void PrintBuilding(Building building)
    {
        File.WriteAllText("Building.txt", building.GetTextToPrint());
    }
}