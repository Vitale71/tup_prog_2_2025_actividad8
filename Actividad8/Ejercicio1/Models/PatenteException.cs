namespace Ejercicio1.Models;

internal class PatenteException : ApplicationException
{
    public PatenteException() : base("patente invalida") { }
    public PatenteException(string message) : base(message) { }
    public PatenteException(string msg, Exception inner) : base(msg, inner) { }

}
