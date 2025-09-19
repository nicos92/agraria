using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using System.Threading.Tasks;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class UsuariosService(IUsuariosRepository repo) : IUsuariosService
    {
        private readonly IUsuariosRepository _repo = repo;

        public async Task<Result<List<Usuarios>>> GetAll() => await _repo.GetAll();
        public async Task<Result<Usuarios>> GetById(int id) => await _repo.GetById(id);
        public async Task<Result<Usuarios>> GetByDniAndPassword(string dni, string password) => await _repo.GetByDniAndPassword(dni, password);
        public async Task<Result<Usuarios>> GetByDniAndQuestionAndAnswer(string dni, int preguntaId, string respuesta) => await _repo.GetByDniAndQuestionAndAnswer(dni, preguntaId, respuesta);
        public Result<Usuarios> Add(Usuarios usuario) => _repo.Add(usuario);
        public Result<Usuarios> Update(Usuarios usuario) => _repo.Update(usuario);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
