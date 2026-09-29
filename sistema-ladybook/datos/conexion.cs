dotnet new wusing Microsoft.Data.SqlClient;
 
namespace sistema-ladybook.Datos
{
    public static class Conexion
    {
        // Se agrega '@' antes de la cadena para que acepte la barra invertida '\' sin dar error de escape
        private static readonly string _connectionString = @"Server=SJAPLA3040071\SQLEXPRESS;Database=Peluqueria;User Id=SA;Password=User.sede;TrustServerCertificate=True;";
 
        //version notebbok CORFO
        //private static readonly string _connectionString = 
          //          @"Server=SJAPLA3040071\SQLEXPRESS;Database=Peluqueria;Integrated Security=True;TrustServerCertificate=True;";
 
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}informs -o MiAppWinForms
tiene menú contextual
