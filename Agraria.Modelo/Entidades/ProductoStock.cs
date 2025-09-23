using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public record ProductoStock(
     int Id_Producto,
     string Cod_Producto,
     string Art_Desc,
     int Cod_TipoEntorno,
     int Cod_Entorno,
     int Id_Proveedor,
     decimal Cantidad,
     decimal Costo,
     decimal Ganancia
 );
}
