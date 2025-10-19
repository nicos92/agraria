using Agraria.Utilidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
    public class EntornoFormativoPrintStrategy : IPrintStrategy
    {
        private readonly List<Agraria.Modelo.Records.EntornoFormativoConNombres>? _entornosFormativos;

        public EntornoFormativoPrintStrategy(List<Agraria.Modelo.Records.EntornoFormativoConNombres>? entornosFormativos)
        {
            _entornosFormativos = entornosFormativos;
        }

        public bool CanPrint() => _entornosFormativos != null && _entornosFormativos.Any();

        public void Print()
        {
            ImpresionTicket impresion = new();
            impresion.ImprimirEntornoFormativo(_entornosFormativos!);
        }

        public string GetEmptyMessage() => "No hay entornos formativos cargados para imprimir.";
    }
}
