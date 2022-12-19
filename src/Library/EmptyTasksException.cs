namespace System;
/// <summary>
/// Nueva excepción para tasks.
/// </summary>
public class EmptyTasksException : Exception
{
    /// <summary>
    /// Excepción lanzada si la lista de tareas está vacía
    /// </summary>
    /// <param name="mensaje"></param>
    /// <returns></returns>
    public EmptyTasksException(string mensaje) : base (mensaje)
    {
        
    }
}