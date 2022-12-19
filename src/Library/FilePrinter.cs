using System.IO;
namespace Full_GRASP_And_SOLID.Library;
/// <summary>
/// Clase que imprime en un archivo
/// </summary>
public class FilePrinter : IPrinter
{
    /// <summary>
    /// Constructor que se le pasa como parametro una string con la que se guarda el nombre del archivo.
    /// </summary>
    /// <param name="filename"></param>
    public FilePrinter(string filename)
    {
        this.FileName = filename;
    }
    /// <summary>
    /// Variable de nombre del archivo
    /// </summary>
    /// <value></value>
    private string FileName { get; set; }
    /// <summary>
    /// Escribe el texto en un archivo el string (IStringBuilder) pasado como parámetro
    /// </summary>
    /// <param name="text"></param>
    public void Print(IStringBuilder text)
    {
        File.WriteAllText($"{this.FileName}.txt", text.GetTextToPrint());
    }
}