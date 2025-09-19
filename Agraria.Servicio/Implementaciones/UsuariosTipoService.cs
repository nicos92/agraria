using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class UsuariosTipoService : IUsuariosTipoService
    {
        private readonly IUsuariosTipoRepository _repo;

        public UsuariosTipoService(IUsuariosTipoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<List<UsuariosTipo>>> GetAll() => await _repo.GetAll();
        public Result<UsuariosTipo> GetById(int id) => _repo.GetById(id);
        public Result<UsuariosTipo> Add(UsuariosTipo tipo) => _repo.Add(tipo);
        public Result<UsuariosTipo> Update(UsuariosTipo tipo) => _repo.Update(tipo);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
