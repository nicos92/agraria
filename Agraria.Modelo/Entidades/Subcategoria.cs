using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class Subcategoria
    {
        public int Id_Subcategoria { get; set; }
        public int Id_Categoria { get; set; }
        public string? Sub_Categoria { get; set; }

        public Subcategoria() { }
    }
}