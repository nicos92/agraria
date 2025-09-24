using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class EntornoFormativo
    {
        public int Id_Entorno_Formativo { get; set; }
        public int Id_Entorno { get; set; }
        public int Id_Usuario { get; set; }
        public string? Curso_anio { get; set; }
        public string? Curso_Division {  get; set; }
        public string? Curso_Grupo { get; set; }
        public string? Observaciones { get; set; }
        public bool Activo { get; set; }
        public string? Entorno_Nombre { get; set; }
        public string? Usuario_Nombre {  get; set; }
        public string? Usuario_Apellido { get; set; }

        public string? Curso_Completo
        {
            get
            {
                return $"{Curso_anio} {Curso_Division} {Curso_Grupo}";
            }
        }
    }
}
