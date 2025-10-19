using Agraria.Utilidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
    public class VentasGrandesPrintStrategy : IPrintStrategy
    {
        private readonly List<Modelo.Entidades.HVentasConUsuario> _ventasGrandes;

        public VentasGrandesPrintStrategy(List<Modelo.Entidades.HVentasConUsuario> ventasGrandes)
        {
            _ventasGrandes = ventasGrandes;
        }

        public bool CanPrint() => _ventasGrandes?.Any() == true;

        public void Print()
        {
            var impresion = new ImpresionTicket();
            impresion.ImprimirVentasGrandes(_ventasGrandes);
        }

        public string GetEmptyMessage() => "No hay ventas grandes cargadas para imprimir.";
    }
}
