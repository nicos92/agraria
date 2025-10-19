using Agraria.Utilidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
    public class ProductosStockPrintStrategy : IPrintStrategy
    {
        private readonly List<Agraria.Modelo.Entidades.ProductoStockConNombres>? _productos;

        public ProductosStockPrintStrategy(List<Agraria.Modelo.Entidades.ProductoStockConNombres>? productos)
        {
            _productos = productos;
        }

        public bool CanPrint() => _productos != null && _productos.Any();

        public void Print()
        {
            ImpresionTicket impresion = new();
            impresion.ImprimirProductosStock(_productos!);
        }

        public string GetEmptyMessage() => "No hay productos con stock cargados para imprimir.";
    }
}