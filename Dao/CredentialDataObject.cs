using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using tdsv121_dae_final.Connection;
using tdsv121_dae_final.Model;

namespace tdsv121_dae_final.Dao
{
    internal class CredentialDataObject : DataObject
    {

        public int InsertCredential(int uid, Credentials creds)
        {
            string query = @"
                             INSERT INTO {TableName}
                            (
                              userId,
                              hash
                            )
                             VALUES
                            (
                             @userId,
                             @hash
                            )";

            int rowsAffected = dataAccess.ExecuteNonQuery(query, DataAccess.Tables.CREDS,
                    new SqlParameter("@userId", uid),
                    new SqlParameter("@hash", creds.GetHashedSecret())
                );

            return rowsAffected;
        }



        public int InsertCredential(int uid, Credentials creds, SqlConnection con, SqlTransaction transaction)
        {
            string query = @"
                             INSERT INTO {TableName}
                            (
                              userId,
                              hash
                            )
                             VALUES
                            (
                             @userId,
                             @hash
                            )";

            return dataAccess.ExecuteNonQuery(
                    query,
                    DataAccess.Tables.CREDS,
                    con,
                    transaction,
                    new SqlParameter("@userId", uid),
                    new SqlParameter("@hash", creds.GetHashedSecret())
                );

        }

        public string GetHashByUserId(int id)
        {
            string query = @"
                              SELECT hash FROM {TableName}
                              WHERE userId = @id";

            DataTable creds = dataAccess.ExecuteQuery(query, DataAccess.Tables.CREDS,
                new SqlParameter("@id", id));

            Debug.WriteLine(creds.Rows.Count);
            Debug.WriteLine(id);
            if (creds.Rows.Count > 1)
            {
                return "forbidden";
            } 
            else if (creds.Rows.Count > 0)
            {
                return creds.Rows[0]["hash"].ToString();
            } 


            return "not_found";
        }



    }
}
