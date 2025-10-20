using Agraria.Utilidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agraria.UI.Reporte.FormReporte;

namespace Agraria.UI.Reporte
{
    public class UsuariosPrintStrategy : IPrintStrategy
    {
        private readonly List<Agraria.Modelo.Records.UsuarioConTipo>? _usuarios;

        public UsuariosPrintStrategy(List<Agraria.Modelo.Records.UsuarioConTipo>? usuarios)
        {
            _usuarios = usuarios;
        }

        public bool CanPrint() => _usuarios != null && _usuarios.Any();

        public void Print()
        {
            ImpresionTicket impresion = new();
            impresion.ImprimirUsuarios(_usuarios!);
        }

        public string GetEmptyMessage() => "No hay usuarios cargados para imprimir.";
    }
}