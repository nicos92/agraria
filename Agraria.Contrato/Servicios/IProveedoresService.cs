using System.Collections.Generic;
using System.Threading.Tasks;
using Agraria.Modelo.Entidades;
using Agraria.Util;


namespace Agraria.Contrato.Servicios
{
    public interface IProveedoresService
    {
        Task<Result<List<Proveedores>>> GetAll();
        Result<Proveedores> GetById(int id);
        Result<Proveedores> Add(Proveedores proveedor);
        Result<Proveedores> Update(Proveedores proveedor);
        Result<bool> Delete(int id);
        Task<Result<List<Proveedores>>> GetByName(string name);
    }
}
