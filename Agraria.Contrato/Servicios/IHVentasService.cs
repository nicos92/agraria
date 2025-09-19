using System;
using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Servicios
{
    public interface IHVentasService
    {
        Result<List<HVentas>> GetAll();
        Result<HVentas> GetById(int id);
        Result<HVentas> Add(HVentas venta);
        Result<HVentas> Update(HVentas venta);
        Result<bool> Delete(int id);
        Result<List<HVentas>> GetFiltered(DateTime fechaDesde, DateTime fechaHasta, string cliente, int? idRemito);
    }
}
