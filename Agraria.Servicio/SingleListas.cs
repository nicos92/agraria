using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Modelo;
using Agraria.Modelo.Entidades;

namespace Agraria.Servicio
{
    public sealed class SingleListas
    {
        private static readonly Lazy<SingleListas> instance = new(() => new SingleListas());
        public static SingleListas Instance => instance.Value;
        private SingleListas()
        {
            // Inicializar las listas aquí si es necesario
            Proveedores = [];
            Productos = [];
            Ventas = [];
            ProductosSeleccionados = [];
            ProductoResumen = [];
        }
        public List<Proveedores> Proveedores { get; set; }
        public List<Articulos> Productos { get; set; }
        public List<HVentas> Ventas { get; set; }
        public List<ArticuloStock> ProductosSeleccionados { get; set; }
        public List<ProductoResumen> ProductoResumen { get; set; }
    }


}
