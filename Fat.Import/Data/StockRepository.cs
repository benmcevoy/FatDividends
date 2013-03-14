using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat.Data
{
    public class StockRepository
    {
        private const string ConnectionString = "Data Source=D:\\Dev\\git\\FatDividends\\Fat\\App_Data\\fattyd.database.sdf;Persist Security Info=False;";

        public void Execute(string insertCommand)
        {
            using (var conn = new SqlCeConnection(ConnectionString))
            using(var cmd = new SqlCeCommand(insertCommand, conn))
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
