using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class Usuarios
    {
        public int Id_Usuario { get; set; }
        public string? DNI { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Tel { get; set; }
        public string? Mail { get; set; }
        public int Id_Tipo { get; set; }
        public string? Contra { get; set; }
        public string? Respues { get; set; }
        public int Id_Pregunta { get; set; }
        public string? Descripcion { get; set; }

        public Usuarios() { }
        public override string ToString()
        {
            return $"DNI: {DNI}, Apellido: {Apellido}, Nombre:{Nombre}";
        }
    }

}
