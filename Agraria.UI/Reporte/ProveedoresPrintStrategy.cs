using Agraria.Utilidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
    public class ProveedoresPrintStrategy : IPrintStrategy
    {
        private readonly List<Agraria.Modelo.Entidades.Proveedores>? _proveedores;

        public ProveedoresPrintStrategy(List<Agraria.Modelo.Entidades.Proveedores>? proveedores)
        {
            _proveedores = proveedores;
        }

        public bool CanPrint() => _proveedores != null && _proveedores.Any();

        public void Print()
        {
            ImpresionTicket impresion = new();
            impresion.ImprimirProveedores(_proveedores!);
        }

        public string GetEmptyMessage() => "No hay proveedores cargados para imprimir.";
    }
}