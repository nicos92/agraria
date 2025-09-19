using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using System.Threading.Tasks;
using System;
using Agraria.Utilidades;

namespace Agraria.Contrato.Repositorios
{
    public interface IHRemitoProduccionRepository
    {
        Task<Result<List<HRemitoProduccion>>> GetAll();
        Task<Result<HRemitoProduccion>> GetById(int id);
        Result<HRemitoProduccion> Add(HRemitoProduccion remito);
        Result<HRemitoProduccion> Update(HRemitoProduccion remito);
        Result<bool> Delete(int id);
        Result<List<HRemitoProduccion>> GetFiltered(DateTime fechaDesde, DateTime fechaHasta, string cliente, int? idRemito);
    }
}