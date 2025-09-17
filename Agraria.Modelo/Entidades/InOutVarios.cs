using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class InOutVarios
    {
        public int Id_Movimiento { get; set; }
        public int Cod_Usuario { get; set; }
        public string? Fecha { get; set; }
        public string? Tipo { get; set; }
        public string? Detalle { get; set; }
        public string? Monto { get; set; }

        public InOutVarios() { }
    }
}