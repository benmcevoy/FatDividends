using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;

namespace Fat.Import.Data
{
    public class ImportRepository
    {
        private readonly string _connectionString;

        public ImportRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Entites"].ConnectionString;
        }

        public void Execute(string insertCommand)
        {
            using (var conn = new SqlCeConnection(_connectionString))
            using(var cmd = new SqlCeCommand(insertCommand, conn))
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
