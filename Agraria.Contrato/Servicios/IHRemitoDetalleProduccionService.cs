using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using System.Threading.Tasks;
using Agraria.Utilidades;

namespace Agraria.Contrato.Servicios
{
    public interface IHRemitoDetalleProduccionService
    {
        Task<Result<List<HRemitoDetalleProduccion>>> GetAll();
        Task<Result<HRemitoDetalleProduccion>> GetById(int id);
        Task<Result<List<HRemitoDetalleProduccion>>> GetByRemitoId(int remitoId);
        Result<HRemitoDetalleProduccion> Add(HRemitoDetalleProduccion detalle);
        Result<HRemitoDetalleProduccion> Update(HRemitoDetalleProduccion detalle);
        Result<bool> Delete(int id);
        Result<bool> DeleteByRemitoId(int remitoId);
    }
}