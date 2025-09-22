using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;

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
            cadenaConexion = "Server=NICOS\\SQLEXPRESS;Database=Agraria;Trusted_Connection=True;TrustServerCertificate=True;";


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