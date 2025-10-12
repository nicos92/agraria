using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public record ProductoStockConNombres(
        int Id_Producto,
        string Cod_Producto,
        string Producto_Desc,
        string? Nombre_TipoEntorno,
        string? Nombre_Entorno,
        string? Nombre_Proveedor,
        decimal Cantidad,
        decimal Costo,
        decimal Ganancia
    );
}