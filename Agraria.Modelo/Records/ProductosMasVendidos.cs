using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Records
{
	public record ProductosMasVendidos(
		string Cod_Producto,
		string Producto_Desc,
		decimal CantidadVendida,
		decimal TotalVendido
	);
}
