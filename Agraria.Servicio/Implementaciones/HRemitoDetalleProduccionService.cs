using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using System.Threading.Tasks;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class HRemitoDetalleProduccionService(IHRemitoDetalleProduccionRepository repo) : IHRemitoDetalleProduccionService
    {
        private readonly IHRemitoDetalleProduccionRepository _repo = repo;

        public async Task<Result<List<HRemitoDetalleProduccion>>> GetAll() => await _repo.GetAll();
        public async Task<Result<HRemitoDetalleProduccion>> GetById(int id) => await _repo.GetById(id);
        public async Task<Result<List<HRemitoDetalleProduccion>>> GetByRemitoId(int remitoId) => await _repo.GetByRemitoId(remitoId);
        public Result<HRemitoDetalleProduccion> Add(HRemitoDetalleProduccion detalle) => _repo.Add(detalle);
        public Result<HRemitoDetalleProduccion> Update(HRemitoDetalleProduccion detalle) => _repo.Update(detalle);
        public Result<bool> Delete(int id) => _repo.Delete(id);
        public Result<bool> DeleteByRemitoId(int remitoId) => _repo.DeleteByRemitoId(remitoId);
    }
}