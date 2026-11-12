using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace tdsv121_dae_final.Connection
{
    internal class DataBaseConnection
    {
        private string sqlConnectionStr = @"Server=.\SQLEXPRESS;Database=dae_final;Integrated Security=True;TrustServerCertificate=True";

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStr);
            return connection;
        }
    }
}
