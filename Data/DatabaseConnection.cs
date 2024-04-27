using System.Data;
using Npgsql;

namespace poc_dapper.Data
{
    public class DatabaseConnection : IDisposable
    {
        public IDbConnection Connection { get; set; }

        public DatabaseConnection(IConfiguration configuration)
        {
            Connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));

            Connection.Open();
        }


        public void Dispose()
        {
            Connection.Close();
        }
    }
}
