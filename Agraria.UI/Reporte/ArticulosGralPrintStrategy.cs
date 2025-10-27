using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades.Impresion;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
	public class ArticulosGralPrintStrategy : IPrintStrategy
	{
		private readonly List<ArticulosGral>? _articulosGrals;

		public ArticulosGralPrintStrategy(List<ArticulosGral>? actividades)
		{
			_articulosGrals = actividades;
		}

		public bool CanPrint() => _articulosGrals != null && _articulosGrals.Any();

		public void Print()
		{
			ImpresionTicket impresion = new();
			impresion.ImprimirArticulos(_articulosGrals!);
		}

		public string GetEmptyMessage() => "No hay actividades cargadas para imprimir.";
	}
}
