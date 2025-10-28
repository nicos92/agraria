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
			UsuariosTipos = [];
			ArticulosResumen = [];
		}
        public List<Proveedores> Proveedores { get; set; }
        public List<Productos> Productos { get; set; }
        public List<HVentas> Ventas { get; set; }
        public List<ProductoStock> ProductosSeleccionados { get; set; }
        public List<ProductoResumen> ProductoResumen { get; set; }
		public List<ProductoResumen> ArticulosResumen { get; set; }
		public List<UsuariosTipo> UsuariosTipos { get; set; }
	}


}
