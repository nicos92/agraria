using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;

namespace Agraria.Servicio.Implementaciones
{
    public class HVentasDetalleService(IHVentasDetalleRepository repo) : IHVentasDetalleService
    {
        private readonly IHVentasDetalleRepository _repo = repo;

        public async Task<Result<List<HVentasDetalle>>> GetAll() => await _repo.GetAll();
        public Result<HVentasDetalle> GetById(int id) => _repo.GetById(id);
        public Result<HVentasDetalle> Add(HVentasDetalle detalle) => _repo.Add(detalle);
        public Result<HVentasDetalle> Update(HVentasDetalle detalle) => _repo.Update(detalle);
        public Result<bool> Delete(int id) => _repo.Delete(id);
        public async Task<Result<List<HVentasDetalle>>> GetByRemitoId(int idRemito) => await _repo.GetByRemitoId(idRemito);
    }
}
