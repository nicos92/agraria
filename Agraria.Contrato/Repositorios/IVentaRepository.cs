using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Modelo;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Repositorios
{
    public interface IVentaRepository
    {
        Task<Result<bool>> Add(HVentas hVentas, List<ProductoResumen> productoResumen);
        Task<Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>> GetAll();

        // Report methods

        Task<Result<List<HVentas>>> GetVentasGrandes(int top = 10);
    }
    
    
   
}
