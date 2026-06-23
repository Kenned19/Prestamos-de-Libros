using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PrestamoDeLibros
{
    public class Conexion
    {        
        private string cadena = @"Data Source=.\SQL2025;Initial Catalog=PrestamosDeLibros;Integrated Security=True;TrustServerCertificate=True;";

        public SqlConnection Conectar()
        {
            return new SqlConnection(cadena);
        }
    }
}
