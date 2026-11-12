using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using tdsv121_dae_final.Connection;
using tdsv121_dae_final.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace tdsv121_dae_final.Dao
{
    internal class UserDataObject : DataObject
    {


        public int InsertUser(User user)
        {
            try
            {
                string query = @"
                             INSERT INTO {TableName}
                            (
                              username,
                              roleId  
                            )
                            OUTPUT INSERTED.id
                             VALUES
                            (
                             @userName,
                             @roleId
                            )";

                int userId = dataAccess.ExecuteScalar(query, DataAccess.Tables.USERS,
                        new SqlParameter("@userName", user.GetUserName()),
                        new SqlParameter("@roleId", user.GetRoleId())
                    );

                return userId;

            } catch (SqlException ex)
            {
                throw new Exception("Error al Insertar");
            }

        }

        public int RegisterUser(User user)
        {
            int userId = 0;
            int credsInserted = 0;

            CredentialDataObject credentialDataObject = new CredentialDataObject();

            dataAccess.ExecuteTransaction((con, transaction) =>
            {
                userId = InsertUser(user, con, transaction);

              credsInserted =  credentialDataObject.InsertCredential(
                    userId,
                    user.GetCredentials(),
                    con,
                    transaction
                    );
            });

            if (credsInserted != 1)
            {
                throw new Exception("Credential creation failed.");
            }

            return userId;
        }



        public int InsertUser(User user, SqlConnection con, SqlTransaction transaction)
        {
            string query = @"
                    INSERT INTO {TableName}
                    (
                        username,
                        firstName,
                        lastName,
                        dui,
                        email,
                        phone,
                        roleId
                    )
                    OUTPUT INSERTED.id
                    VALUES
                    (
                        @userName,
                        @firstName,
                        @lastName,
                        @dui,
                        @email,
                        @phone,
                        @roleId
                    )";

            return dataAccess.ExecuteScalar(
                query,
                DataAccess.Tables.USERS,
                con,
                transaction,
                new SqlParameter("@userName", user.GetUserName()),
                new SqlParameter("@firstName", user.GetFirstName()),
                new SqlParameter("@lastName", user.GetLastName()),
                new SqlParameter("@dui", user.GetDui()),
                new SqlParameter("@email", user.GetEmail()),
                new SqlParameter("@phone", user.GetPhoneNumber()),
                new SqlParameter("@roleId", user.GetRoleId())
            );
        }

        public int UpdateUser(User user)
        {
            string query = @"
                             UPDATE {TableName}
                             SET username = @userName
                             WHERE id = @id";

            int rowsAffected = dataAccess.ExecuteNonQuery(query, DataAccess.Tables.USERS,
                    new SqlParameter("@userName", user.GetUserName()),
                    new SqlParameter("id", user.GetUserId())
                );

            return rowsAffected;
        }

        public DataTable GetUserById(int id)
        {
            string query = @"
                              SELECT * FROM {TableName}
                              WHERE id = @id";

            DataTable user = dataAccess.ExecuteQuery(query, DataAccess.Tables.USERS, 
                new SqlParameter("@id", id));

            return user;
        }

        public DataTable GetUserByUsername(string userName)
        {
            string query = @"
                              SELECT * FROM {TableName}
                              WHERE username = @username";

            DataTable user = dataAccess.ExecuteQuery(query, DataAccess.Tables.USERS,
                new SqlParameter("@username", userName));

            return user;
        }

        public DataTable GetUserByEmail(string email)
        {
            string query = @"
                              SELECT * FROM {TableName}
                              WHERE email = @email";

            DataTable user = dataAccess.ExecuteQuery(query, DataAccess.Tables.USERS,
                new SqlParameter("@email", email));

            return user;
        }

        public DataTable GetUserByDocument(string document)
        {
            string query = @"
                              SELECT * FROM {TableName}
                              WHERE dui = @document";

            DataTable user = dataAccess.ExecuteQuery(query, DataAccess.Tables.USERS,
                new SqlParameter("@document", document));

            return user;
        }


        public DataTable GetUserByPhone(string phone)
        {
            string query = @"
                              SELECT * FROM {TableName}
                              WHERE phone = @phone";

            DataTable user = dataAccess.ExecuteQuery(query, DataAccess.Tables.USERS,
                new SqlParameter("@phone", phone));

            return user;
        }

        public string GetRoleByUserId(int userId)
        {
            string query = @"
            SELECT r.name
            FROM {TableName} u
            INNER JOIN roles r ON u.roleId = r.id
            WHERE u.id = @userId";

            DataTable result = dataAccess.ExecuteQuery(
                query,
                DataAccess.Tables.USERS,
                new SqlParameter("@userId", userId)
            );

            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["name"].ToString();
            }

            return null;
        }




    }
}
