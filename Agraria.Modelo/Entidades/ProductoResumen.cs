using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades;

public class ProductoResumen
{
    public string? Cod_Articulo { get; set; }
    public string? Producto_Nombre { get; set; }
    public decimal Producto_Precio { get; set; }
    public decimal Producto_Cantidad { get; set; }
    public decimal Producto_PrecioxCantidad { get; set; }
}