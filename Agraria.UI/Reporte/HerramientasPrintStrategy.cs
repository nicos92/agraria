using Agraria.Utilidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
    public class HerramientasPrintStrategy : IPrintStrategy
    {
        private readonly List<Agraria.Modelo.Entidades.Herramientas>? _herramientas;

        public HerramientasPrintStrategy(List<Agraria.Modelo.Entidades.Herramientas>? herramientas)
        {
            _herramientas = herramientas;
        }

        public bool CanPrint() => _herramientas != null && _herramientas.Any();

        public void Print()
        {
            ImpresionTicket impresion = new();
            impresion.ImprimirHerramientas(_herramientas!);
        }

        public string GetEmptyMessage() => "No hay herramientas cargadas para imprimir.";
    }
}