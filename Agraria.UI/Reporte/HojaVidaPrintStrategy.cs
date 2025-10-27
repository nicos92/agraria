using Agraria.Modelo.Records;
using Agraria.Utilidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
    public class HojaVidaPrintStrategy : IPrintStrategy
    {
        private readonly List<HojaDeVidaReporte> _hojasDeVida;

        public HojaVidaPrintStrategy(List<HojaDeVidaReporte> hojasDeVida)
        {
            _hojasDeVida = hojasDeVida;
        }

        public bool CanPrint() => _hojasDeVida?.Count > 0;

        public void Print()
        {
            var impresion = new ImpresionTicket();
            impresion.ImprimirHojaVida(_hojasDeVida);
        }

        public string GetEmptyMessage() => "No hay hojas de vida cargadas para imprimir.";
    }
}
