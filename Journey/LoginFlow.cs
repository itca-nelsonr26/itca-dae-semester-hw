using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Text;
using tdsv121_dae_final.Authorization;
using tdsv121_dae_final.Dao;
using tdsv121_dae_final.Model;

namespace tdsv121_dae_final.Journey
{
    internal class LoginFlow
    {

        private UserDataObject userDataObject = new UserDataObject();
        private CredentialDataObject credentialDataObject = new CredentialDataObject();

        private string invalidCredentials = "Invalid Username or Password";
        public Session LoginUser(string username, MaskedTextBox secret)
        {
            if (username.Length == 0 || secret.Text.Length == 0)
            {
                return null;
            }

            try 
            { 
                Session session = ValidateCredentials(username, secret.Text);

 

                return session;
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }

        }

        private string ValidateCredentials2(string userName, string secretToValidate)
        {

            DataTable user = GetUserByUserName(userName);

            if (user.Rows.Count == 0)
            {
                return invalidCredentials;
            }

            string result = user.Rows[0]["id"].ToString();

            int userId = Int32.Parse(result);

            string userHash = GetUserHashByUserId(userId);

            Debug.WriteLine($"{userId}, {userHash}");

            Credentials creds = new Credentials(userHash);

            string validationResult = creds.ValidatePassword(userName, secretToValidate);

            return validationResult;
        }

        private Session ValidateCredentials(string userName, string secretToValidate)
        {

            DataTable user = GetUserByUserName(userName);

            if (user.Rows.Count == 0)
            {
                throw new ArgumentException("invalid credentials");
            }

            string result = user.Rows[0]["id"].ToString();

            int userId = Int32.Parse(result);

            string userHash = GetUserHashByUserId(userId);

            Debug.WriteLine($"{userId}, {userHash}");

            Credentials creds = new Credentials(userHash);

            string validationResult = creds.ValidatePassword(userName, secretToValidate);

            if (validationResult == "success")
            {
                string role = userDataObject.GetRoleByUserId(userId);

                if (role == null)
                {
                    throw new ArgumentException("Data issues, user doesn't have a role");
                }


               Session session = new Session(userName, userId, role);
                return session;
            }

            throw new ArgumentException("invalid credentials");
        }

        private string GetUserHashByUserId(int id)
        {
            string hash = credentialDataObject.GetHashByUserId(id);

            if (hash == "not_found" || hash == "forbidden")
            {
                return "not_found";
            }

            return hash;
        }

        
        private DataTable GetUserByUserName(string userName)
        {
            return userDataObject.GetUserByUsername(userName);
        }
       
    }
}
