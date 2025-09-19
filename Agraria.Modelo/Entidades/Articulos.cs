using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class Articulos
    {
        public int Id_Articulo { get; set; }
        public string? Cod_Articulo { get; set; }
        public string? Art_Desc { get; set; }
        public int Cod_Categoria { get; set; }
        public int Cod_Subcat { get; set; }
        public int Id_Proveedor { get; set; }
        public string? Unidad_Medida { get; set; }
        public bool En_Venta { get; set; }

        public Articulos() { }
    }

}
