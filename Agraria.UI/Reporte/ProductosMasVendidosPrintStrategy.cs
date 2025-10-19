using Agraria.Utilidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
    public class ProductosMasVendidosPrintStrategy : IPrintStrategy
    {
        private readonly List<Agraria.Contrato.Repositorios.ProductosMasVendidos>? _productos;

        public ProductosMasVendidosPrintStrategy(List<Agraria.Contrato.Repositorios.ProductosMasVendidos>? productos)
        {
            _productos = productos;
        }

        public bool CanPrint() => _productos != null && _productos.Any();

        public void Print()
        {
            ImpresionTicket impresion = new();
            impresion.ImprimirProductosMasVendidos(_productos!);
        }

        public string GetEmptyMessage() => "No hay productos más vendidos cargados para imprimir.";
    }
}