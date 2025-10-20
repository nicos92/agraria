using Agraria.Utilidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
    public class ActividadesPrintStrategy : IPrintStrategy
    {
        private readonly List<Agraria.Modelo.Records.ActividadConNombres>? _actividades;

        public ActividadesPrintStrategy(List<Agraria.Modelo.Records.ActividadConNombres>? actividades)
        {
            _actividades = actividades;
        }

        public bool CanPrint() => _actividades != null && _actividades.Any();

        public void Print()
        {
            ImpresionTicket impresion = new();
            impresion.ImprimirActividades(_actividades!);
        }

        public string GetEmptyMessage() => "No hay actividades cargadas para imprimir.";
    }
}