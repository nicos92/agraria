using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Modelo;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Contrato.Servicios
{
    public interface IVentaService
    {
        Task<Result<bool>> Add(HVentas hVentas, List<ProductoResumen> productoResumen);
        Task<Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>> GetAll();
    }
}
