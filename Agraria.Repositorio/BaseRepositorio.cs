using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Agraria.Repositorio
{
    [SupportedOSPlatform("windows")]
    public abstract class BaseRepositorio
    {
        private readonly string cadenaConexion;

        protected BaseRepositorio()
        {
            //cadenaConexion = ConfigurationManager.ConnectionStrings["msaccess"].ConnectionString;
            //cadenaConexion = ConfigurationManager.ConnectionStrings["SqlServerAgraria"].ConnectionString;

            // CONEXION PARA ESCRITORIO
            //cadenaConexion = "Server=NICOS\\SQLEXPRESS;Database=Agraria;Trusted_Connection=True;TrustServerCertificate=True;";

            // CONEXION PARA T440
            cadenaConexion = "Server=NicoS92T440;Database=Agraria;Trusted_Connection=True;TrustServerCertificate=True;";
            // CONEXION PARA i9
            //cadenaConexion = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = True; Persist Security Info = False; Pooling = False; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = True; Application Name = 'SQL Server Management Studio'; Command Timeout = 30; Initial Catalog = Agraria";
            //cadenaConexion = ConfigurationManager.ConnectionStrings["SqlServerAgrariaLocal"].ConnectionString;
            // CONEXION PARA DOCKER CASA
            //cadenaConexion = @"Server=127.0.0.1,14333;Database=Agraria;User Id=sa;Password=Pass2025@;TrustServerCertificate=True;";


        }

        //protected SqlConnection Conexion()
        //{
        //    return new SqlConnection(cadenaConexion);
        //}

        protected SqlConnection Conexion()
        {
            return new SqlConnection(cadenaConexion);
        }

    }
}
