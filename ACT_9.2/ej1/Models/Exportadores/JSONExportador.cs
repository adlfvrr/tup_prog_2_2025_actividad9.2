using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ej1.Models.Exportadores;
public class JSONExportador : IExportador
{
    public bool Importar(string data, Multa m)
    {
      Regex regex = new Regex(@"""Patente""\s*:\s*""([A-Z]{3}[0-9]{3})""\s*,\s*""Vencimiento""\s*:\s*""(\d{2}/\d{2}/\d{4})""\s*,\s*""Importe""\s*:\s*(\d+\.\d+)", RegexOptions.IgnoreCase);
      Match match = regex.Match(data);
        if(match.Success)
        {
            string patente = match.Groups[1].Value.ToUpper();
            DateTime fecha = Convert.ToDateTime(match.Groups[2].Value);
            DateOnly vencimiento = new DateOnly(fecha.Year, fecha.Month, fecha.Day);
            double importe = Convert.ToDouble(match.Groups[3].Value);
            m.Importe = importe; m.Patente = patente; m.Vencimiento = vencimiento;
            return true;
        }
        return false;
    }
    public string Exportar(Multa m)
    {
        return @$"[
{{ ""Patente"": ""{m.Patente}"", ""Vencimiento"": ""{m.Vencimiento}"", ""Importe"": {m.Importe:f2} }}
]";
    }
}
