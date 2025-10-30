using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        //Regex R = new Regex(@"([a-z]{3}\d{3});([^<]+)}", RegexOptions.IgnoreCase);
        string[] separator = cadena.Split(';');

        string patente = separator[0];
        double importer = Convert.ToDouble(separator[1]);
        Vehiculo auto = new Vehiculo(patente, importer);
    }

    public string Exportar()
    {
        throw new NotImplementedException();
    }
}
