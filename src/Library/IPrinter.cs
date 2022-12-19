namespace Full_GRASP_And_SOLID.Library;
//Se utiliza el patrón Polimorfismo ya que en vez de tener un bloque de código para escribir en consola y 
//otro para escribir en un archivo, tiene dos clases distintas para cada acción
/// <summary>
/// Interfaz de todas las clases que imprimen en algún destino
/// </summary>
public interface IPrinter
{
    /// <summary>
    /// Método que imprime.
    /// Recibe como parámetro un IStringBuilder que contiene una string
    /// </summary>
    /// <param name="text"></param>
    public void Print(IStringBuilder text);
}