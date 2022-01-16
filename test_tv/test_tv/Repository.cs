using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_tv
{
    class Repository
    {
        // properties
        //const string _connectionString = @"Data source=DATWS203\NETX_SERVER_SQL; Initial Catalog=TvRemote; User ID=sa; Password=sa";
        const string _connectionString = @"Data source=localhost; Initial Catalog=TvRemote; User ID=sa; Password=123456789";

        // read command from table
        public string ReadCommand()
        {
            string sql = "SELECT TOP(1) ButtonName,Timeclicked FROM REGISTRY ORDER BY TimeClicked DESC";
            string sCommando="No command";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            { 
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    sCommando = reader["ButtonName"].ToString();
                }

            }

            return sCommando;
        }

        public void DeleteCommand()
        {
            string sql = "DELETE FROM REGISTRY";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteNonQuery();
            }

        }
    }
}
