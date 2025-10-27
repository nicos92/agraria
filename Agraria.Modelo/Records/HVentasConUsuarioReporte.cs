using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Records
{
    public record HVentasConUsuarioReporte
    (
		int Id_Remito,
		String Usuario,
		DateTime Fecha,
		decimal Total,
		string? Descripcion
		);
}
