using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class HMovimientos
    {
        public int Id_Historico { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public int Id_Usuario { get; set; }
        public int Tipo_Movimiento { get; set; }
        public string? Reg_Antes { get; set; }
        public string? Reg_Despues { get; set; }

        public HMovimientos() { }
    }
}