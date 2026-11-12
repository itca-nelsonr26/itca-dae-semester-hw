using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using tdsv121_dae_final.Components;

namespace tdsv121_dae_final.Connection
{
    internal class DataAccess
    {

        private DataBaseConnection connection = new DataBaseConnection();


        public enum Tables
        {
            USERS,
            ROLES,
            CREDS
        }
        public DataTable LoadData(Tables table)
        {
            switch (table)
            {
                case Tables.USERS:
                    return GetDataFromTable(GetTableName(table));
                case Tables.ROLES:
                    return GetDataFromTable(GetTableName(table));
                default:
                    Console.WriteLine("Data Table not mapped");
                    return new DataTable();

            }
        }

        private string GetTableName(Tables table)
        {
            switch (table)
            {
                case Tables.USERS:
                    return "users";
                case Tables.ROLES:
                    return "roles";
                case Tables.CREDS:
                    return "credentials";
                default:
                    Console.WriteLine("Data Table not mapped - name not found");
                    return "invalid_table";

            }
        }

       
        public ComboField GetRoleFields()
        {
            return new ComboField("name", "id");

        }

        private DataTable GetDataFromTable(string tableName)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection con = connection.GetConnection())
                {
                    con.Open();
                    string query = $"SELECT * FROM {tableName}";


                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@table", tableName);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {

                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to connect to database" + e.ToString());
            }

            return dataTable;
        }


        public DataTable ExecuteQuery(string query, Tables table, params SqlParameter[] parameters)
        {
            string tableName = GetTableName(table);

            if (tableName == "invalid_table")
            {
                throw new ArgumentException("Invalid table specified.", nameof(table));
            }

            query = query.Replace("{TableName}", $"[{tableName}]");

            try
            {
                using (SqlConnection con = connection.GetConnection())
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddRange(parameters);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            } 
            catch (SqlException ex)
            {
                Console.WriteLine($"Failed to execute NonQuery {ex.Message}");
                return new DataTable();
            }
        }

        public int ExecuteNonQuery(string query, Tables table, params SqlParameter[] parameters)
        {

            string tableName = GetTableName(table); 

            if (tableName == "invalid_table")
            {
                throw new ArgumentException("Invalid table specified.", nameof(table));
            }

            query = query.Replace("{TableName}", $"[{tableName}]");

            try
            {
                using (SqlConnection con = connection.GetConnection())
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddRange(parameters);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine($"Failed to execute NonQuery {ex.Message}");
                return 0;
            }

        }

        public int ExecuteNonQuery(
            string query,
            Tables table,
            SqlConnection con,
            SqlTransaction transaction,
            params SqlParameter[] parameters)
        {
            string tableName = GetTableName(table);

            if (tableName == "invalid_table")
                throw new ArgumentException("Invalid table.");

            query = query.Replace("{TableName}", $"[{tableName}]");

            using (SqlCommand command =
                new SqlCommand(query, con, transaction))
            {
                command.Parameters.AddRange(parameters);

                return command.ExecuteNonQuery();
            }
        }


        public void ExecuteTransaction(Action<SqlConnection, SqlTransaction> operations)
        {
            using (SqlConnection con = connection.GetConnection())
            {
                con.Open();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        operations(con, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (SqlException rollbackException)
                        {
                            Console.WriteLine(
                                $"Rollback failed: {rollbackException.Message}"
                            );
                        }

                        throw;
                    }
                }
            }
        }



        public int ExecuteScalar(string query, Tables table, params SqlParameter[] parameters)
        {
            string tableName = GetTableName(table);

            if (tableName == "invalid_table")
            {
                throw new ArgumentException("Invalid table specified.", nameof(table));
            }

            query = query.Replace("{TableName}", $"[{tableName}]");

            try
            {
                using (SqlConnection con = connection.GetConnection())
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddRange(parameters);

                        object result = command.ExecuteScalar();

                        return Convert.ToInt32(result);
                    }
                }
            } 
            catch (SqlException ex)
            {
                Console.WriteLine($"Failed to execute scalar {ex.Message}");
                return 0;
            }

        }

        public int ExecuteScalar(
            string query,
            Tables table,
            SqlConnection con,
            SqlTransaction transaction,
            params SqlParameter[] parameters)
        {
            string tableName = GetTableName(table);

            if (tableName == "invalid_table")
                throw new ArgumentException("Invalid table.");

            query = query.Replace("{TableName}", $"[{tableName}]");

            using (SqlCommand command =
                new SqlCommand(query, con, transaction))
            {
                command.Parameters.AddRange(parameters);

                object result = command.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    throw new InvalidOperationException(
                        "The query did not return a valid result."
                    );
                }

                return Convert.ToInt32(result);
            }
        }
    }

}
