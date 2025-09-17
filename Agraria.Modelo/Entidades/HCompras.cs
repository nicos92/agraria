using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class HCompras
    {
        public int Id_Remito { get; set; }
        public int Cod_Usuario { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public int Id_Proveedor { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descu { get; set; }
        public decimal Total { get; set; }

        public HCompras() { }
    }
}