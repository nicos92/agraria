using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;
using Agraria.Modelo;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class VentaService(IVentaRepository _repo) : IVentaService
    {
        public async Task<Result<bool>> Add(HVentas hVentas, List<ProductoResumen> productoResumen)
        {
            return await _repo.Add(hVentas, productoResumen);
        }

        public async Task<Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>> GetAll()
        {
            return await _repo.GetAll();
        }





        public async Task<Result<List<HVentasConUsuario>>> GetVentasGrandes(int top)
        {
            return await _repo.GetVentasGrandes(top);
        }
    }
}
