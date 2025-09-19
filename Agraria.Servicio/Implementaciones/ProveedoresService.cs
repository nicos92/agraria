using System.Collections.Generic;
using System.Threading.Tasks;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class ProveedoresService : IProveedoresService
    {
        private readonly IProveedoresRepository _repo;

        public ProveedoresService(IProveedoresRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<List<Proveedores>>> GetAll() => await _repo.GetAll();
        public Result<Proveedores> GetById(int id) => _repo.GetById(id);
        public Result<Proveedores> Add(Proveedores proveedor) => _repo.Add(proveedor);
        public Result<Proveedores> Update(Proveedores proveedor) => _repo.Update(proveedor);
        public Result<bool> Delete(int id) => _repo.Delete(id);
        public async Task<Result<List<Proveedores>>> GetByName(string name) => await _repo.GetByName(name);
    }
}
