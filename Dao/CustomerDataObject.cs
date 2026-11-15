using Microsoft.Data.SqlClient;
using System;
using System.Data;
using tdsv121_dae_final.Connection;

namespace tdsv121_dae_final.Dao
{
    internal class CustomerDataObject : DataObject
    {
        public DataTable GetAllCustomers()
        {
            string query = "SELECT id, document AS DUI, firstname AS Nombre, lastname AS Apellido, phone AS Telefono, email AS Correo FROM {TableName}";
            return dataAccess.ExecuteQuery(query, DataAccess.Tables.CUSTOMERS);
        }

        public int InsertCustomer(string document, string firstname, string lastname, string phone, string email)
        {
            string query = @"
                INSERT INTO {TableName} (document, firstname, lastname, phone, email)
                VALUES (@document, @firstname, @lastname, @phone, @email)";

            return dataAccess.ExecuteNonQuery(
                query,
                DataAccess.Tables.CUSTOMERS,
                new SqlParameter("@document", document),
                new SqlParameter("@firstname", firstname),
                new SqlParameter("@lastname", lastname),
                new SqlParameter("@phone", phone),
                new SqlParameter("@email", email)
            );
        }


        public int UpdateCustomer(int id, string document, string firstname, string lastname, string phone, string email)
        {
            string query = @"
        UPDATE {TableName} 
        SET document = @document, 
            firstname = @firstname, 
            lastname = @lastname, 
            phone = @phone, 
            email = @email 
        WHERE id = @id";

            return dataAccess.ExecuteNonQuery(
                query,
                DataAccess.Tables.CUSTOMERS,
                new SqlParameter("@id", id),
                new SqlParameter("@document", document),
                new SqlParameter("@firstname", firstname),
                new SqlParameter("@lastname", lastname),
                new SqlParameter("@phone", phone),
                new SqlParameter("@email", email)
            );
        }
    }


}