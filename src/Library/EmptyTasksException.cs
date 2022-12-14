namespace System;

public class EmptyTasksException : Exception
{
    public EmptyTasksException(string mensaje) : base (mensaje)
    {
        
    }
}