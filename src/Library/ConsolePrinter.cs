using System;
namespace Full_GRASP_And_SOLID.Library;
//Se agrega una clase ConsolePrinter que obtiene el texto a imprimir y lo imprime en consola.
// Se utiliza el principio SRP, ya que la clase ConsolePrinter tiene como única responsabilidad imprimir en consola el texto.
public class ConsolePrinter : IPrinter
{
    public void Print(IStringBuilder text)
    {
        Console.WriteLine(text.GetTextToPrint());
    }
}