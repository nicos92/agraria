using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Repositorios
{
    public interface IArticulosRepository
    {
        Task<Result<List<Articulos>>> GetAll();
        Result<Articulos> GetById(int id);
        Result<Articulos> Add(Articulos articulo);
        Task<Result<Articulos>> Update(Articulos articulo);
        Result<bool> Delete(int id);
        Task<Result<int>> GetMaxCodArt();
    }
}
