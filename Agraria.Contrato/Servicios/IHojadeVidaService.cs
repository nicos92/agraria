using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using System.Threading.Tasks;
using Agraria.Utilidades;

namespace Agraria.Contrato.Servicios
{
    public interface IHojadeVidaService
    {
        Task<Result<List<HojadeVida>>> GetAll();
        Task<Result<HojadeVida>> GetById(int id);
        Task<Result<HojadeVida>> Add(HojadeVida hojaDeVida);
        Task<Result<HojadeVida>> Update(HojadeVida hojaDeVida);
        Task<Result<bool>> Delete(int id);
    }
}