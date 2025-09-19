using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Repositorios
{
    public interface IHVentasDetalleRepository
    {
        Task<Result<List<HVentasDetalle>>> GetAll();
        Result<HVentasDetalle> GetById(int id);
        Result<HVentasDetalle> Add(HVentasDetalle detalle);
        Result<HVentasDetalle> Update(HVentasDetalle detalle);
        Result<bool> Delete(int id);
        Task<Result<List<HVentasDetalle>>> GetByRemitoId(int idRemito);
    }
}
