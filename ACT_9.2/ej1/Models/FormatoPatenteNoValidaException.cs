using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej1.Models;
public class FormatoPatenteNoValidaException : ApplicationException
{
    public FormatoPatenteNoValidaException() : base("Formato de patente no válida") { }
}
