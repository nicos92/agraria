using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class Actividad
    {
        public int Id_Actividad { get; set; }
        public int Id_TipoEntorno { get; set; }
        public int Id_Entorno { get; set; }
        public int id_EntornoFormativo { get; set; }
        public DateTime Fecha_Actividad { get; set; }
        public string? Descripcion_Actividad { get; set; }


    }
}
