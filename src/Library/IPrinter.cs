namespace Full_GRASP_And_SOLID.Library;
//Se utiliza el patrón Polimorfismo ya que en vez de tener un bloque de código para escribir en consola y 
//otro para escribir en un archivo, tiene dos clases distintas para cada acción
public interface IPrinter
{
    public void Print(IStringBuilder text);
}