using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Records;
using Agraria.Utilidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agraria.Servicio.Implementaciones
{
    public class EntornoFormativoService(IEntornoFormativoRepository repo) : IEntornoFormativoService
    {
        private readonly IEntornoFormativoRepository _repo = repo;

        public Result<EntornoFormativo> Add(EntornoFormativo entornoFormativo)
        {
            return _repo.Add(entornoFormativo);
        }

        public Result<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<Result<List<EntornoFormativo>>> GetAll()
        {
            return await _repo.GetAll();
        }

        public Result<EntornoFormativo> GetById(int id)
        {
            return _repo.GetById(id);
        }

        public async Task<Result<EntornoFormativo>> Update(EntornoFormativo entornoFormativo)
        {
            return await _repo.Update(entornoFormativo);
        }

        public async Task<Result<List<EntornoFormativo>>> GetAllByIdEntorno(int idEntorno)
        {
            return await _repo.GetAllByIdEntorno(idEntorno);
        }

        public async Task<Result<List<EntornoFormativoConNombres>>> GetAllConNombres()
        {
            return await _repo.GetAllConNombres();
        }
    }
}
