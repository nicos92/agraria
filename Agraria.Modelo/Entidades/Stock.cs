using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class Stock
    {
        public string? Cod_Articulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Ganancia { get; set; }
        public Stock()
        {
            
        }

        public override string ToString()
        {
            return $"Codigo: {Cod_Articulo}, Cantidad: {Cantidad}, Costo: {Costo}, Ganancia: {Ganancia}.";
        }

    }
}
