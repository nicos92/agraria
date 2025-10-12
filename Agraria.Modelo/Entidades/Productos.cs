using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class Productos
    {
        public int Id_Producto { get; set; }
        public string? Cod_Producto { get; set; }
        public string? Producto_Desc { get; set; }
        public int Id_Area { get; set; }
        public int Id_Entorno { get; set; }
        public int Id_Proveedor { get; set; }
        public string? Unidad_Medida { get; set; }
        public bool En_Venta { get; set; }

        public Productos() { }
    }

}
