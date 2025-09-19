using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class Herramientas
    {
        public int Id_Herramienta { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }

        public Herramientas() { }
    }
}