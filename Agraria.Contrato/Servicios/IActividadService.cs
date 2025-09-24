using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System.Threading.Tasks;

namespace Agraria.Contrato.Servicios
{
    public interface IActividadService
    {
        Task<Result<List<Actividad>>> GetAll();
        Result<Actividad> GetById(int id);
        Result<Actividad> Add(Actividad actividad);
        Task<Result<Actividad>> Update(Actividad actividad);
        Result<bool> Delete(int id);
        Task<Result<List<Actividad>>> GetAllByEntorno(int idEntorno);
        Task<Result<List<Actividad>>> GetAllByTipoEntorno(int idTipoEntorno);
        Task<Result<List<Actividad>>> GetByFechaRango(DateTime fechaInicio, DateTime fechaFin);
    }
}