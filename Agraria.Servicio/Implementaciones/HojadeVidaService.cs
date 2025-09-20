using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using System.Threading.Tasks;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class HojadeVidaService(IHojadeVidaRepository repo) : IHojadeVidaService
    {
        public async Task<Result<List<HojadeVida>>> GetAll() => await repo.GetAll();
        public async Task<Result<HojadeVida>> GetById(int id) => await repo.GetById(id);
        public async Task<Result<HojadeVida>> Add(HojadeVida hojaDeVida) => await repo.Add(hojaDeVida);
        public async Task<Result<HojadeVida>> Update(HojadeVida hojaDeVida) => await repo.Update(hojaDeVida);
        public async Task<Result<bool>> Delete(int id) => await  repo.Delete(id);
    }
}