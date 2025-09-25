namespace Ejercicio1.Models;

public class Vehiculo : IExportable
{
    public string Patente { get; set; }
    public double Importe { get; set; }

    public Vehiculo()
    {

    }

    public Vehiculo (string patente, double importe)
    {
        if (patente.Length == 6 || patente.Length == 7)
        {
            this.Patente = patente;
            this.Importe = importe;
        }
        else
        {
            throw new PatenteException ("patente con formato incorrecto");
        }
    }

    public override string ToString()
    {
        return $"patente: {Patente}, importe: {Importe}";
    }

    public void Importar(string cadena)
    {
        throw new NotImplementedException();
    }

    public string Exportar()
    {
        throw new NotImplementedException();
    }
}
