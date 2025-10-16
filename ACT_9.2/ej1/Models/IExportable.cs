﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ej1.Models.Exportadores;

namespace ej1.Models;
public interface IExportable
{
    public bool Importar(string data, IExportador exportador);
    public string Exportar(IExportador exportador);
}
