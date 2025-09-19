using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Contrato.Servicios
{
    public interface IHerramientasService
    {
        Task<Result<List<Herramientas>>> GetAll();
        Result<Herramientas> GetById(int id);
        Result<Herramientas> Add(Herramientas herramienta);
        Task<Result<Herramientas>> Update(Herramientas herramienta);
        Result<bool> Delete(int id);
    }
}