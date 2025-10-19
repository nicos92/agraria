using System;

namespace Agraria.Modelo.Entidades
{
    public class HVentasConUsuario : HVentas
    {
        public string? NombreUsuario { get; set; }
        public string? ApellidoUsuario { get; set; }

        public HVentasConUsuario() { }
    }
}
