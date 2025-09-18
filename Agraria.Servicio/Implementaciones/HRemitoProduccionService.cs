using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using System.Threading.Tasks;
using System;

namespace Agraria.Servicio.Implementaciones
{
    public class HRemitoProduccionService(IHRemitoProduccionRepository repo) : IHRemitoProduccionService
    {
        private readonly IHRemitoProduccionRepository _repo = repo;

        public async Task<Result<List<HRemitoProduccion>>> GetAll() => await _repo.GetAll();
        public async Task<Result<HRemitoProduccion>> GetById(int id) => await _repo.GetById(id);
        public Result<HRemitoProduccion> Add(HRemitoProduccion remito) => _repo.Add(remito);
        public Result<HRemitoProduccion> Update(HRemitoProduccion remito) => _repo.Update(remito);
        public Result<bool> Delete(int id) => _repo.Delete(id);
        public Result<List<HRemitoProduccion>> GetFiltered(DateTime fechaDesde, DateTime fechaHasta, string cliente, int? idRemito) => _repo.GetFiltered(fechaDesde, fechaHasta, cliente, idRemito);
    }
}