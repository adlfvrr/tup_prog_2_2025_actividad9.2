using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ej1.Models.Exportadores;
public class CampoFijoExportador : IExportador
{
    public bool Importar(string data, Multa m)
    {
        string lineaTrimeada = data.Replace(" ","");
        Regex regex = new Regex(@"^([a-z]{3}\d{3})(\d{2}/\d{2}/\d{4})(\d+,\d+)$",RegexOptions.IgnoreCase);
        Match match = regex.Match(lineaTrimeada);
        if (match.Success)
        {
            string patente = match.Groups[1].Value;
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
        return $@"{m.Patente}   {m.Vencimiento}   {m.Importe:f2}";
    }
}
