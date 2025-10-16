using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ej1.Models.Exportadores;
public class CSVExportador : IExportador
{
    public bool Importar(string data, Multa m)
    {
        Regex regex = new Regex(@"^([A-Z]{3}\d{3});(\d{2}/\d{2}/\d{4});(\d+,\d+)$");
        Match match = regex.Match(data);
        if (match.Success)
        {
            string[] datos = match.Groups[0].Value.Split(';');
            string patente = datos[0];
            DateTime fecha = Convert.ToDateTime(datos[1]);
            DateOnly vencimiento = new DateOnly(fecha.Year, fecha.Month, fecha.Day);
            double importe = Convert.ToDouble(datos[2]);
            m.Patente = patente; m.Importe = importe; m.Vencimiento = vencimiento;
            return true;
        }
        return false;
    }
    public string Exportar(Multa m)
    {
        return $"{m.Patente};{m.Vencimiento};{m.Importe:f2}";
}
}
