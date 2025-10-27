using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Records
{
	public record HojaDeVidaReporte(
			string Numero,
			string TipoAnimal,
			string Sexo,
			DateTime FechaNacimiento,
			decimal Peso,
			string EstadoSalud,
			string Activo
			);
}
