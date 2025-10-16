using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ej1.Models.Exportadores;

namespace ej1.Models;
    [Serializable]
public class Multa : IComparable, IExportable
{
    string patente;
    public string Patente
    {
        get { return patente; }
        set
        {
            Regex regex = new Regex(@"^[a-z]{3}\d{3}$", RegexOptions.IgnoreCase);
            Match match = regex.Match(value);
            if (match.Success)
            {
                this.patente = value;
            }
            else { throw new FormatoPatenteNoValidaException(); }
        }
    }
    public DateOnly Vencimiento { get; set;} 
    public double Importe { get; set; }
    public Multa() { }
    public Multa(string patente, DateOnly vencimiento, double importe)
    {
            this.Patente = patente; this.Importe = importe; this.Vencimiento = vencimiento;
    }
    public bool Importar(string data, IExportador exportador)
    {
        return exportador.Importar(data, this);
    }
    public string Exportar(IExportador exportador)
    {
        return exportador.Exportar(this);
    }
    public override string ToString()
    {
        return $"Patente: {this.Patente.ToUpper()} - Vencimiento: {this.Vencimiento} - Importe: ${this.Importe:f2}";
    }
    public int CompareTo(object? obj)
    {
        Multa multa = obj as Multa;
        if(obj != null)
        {
            return this.Patente.CompareTo(multa.Patente);
        }
        return -1;
    }
}
