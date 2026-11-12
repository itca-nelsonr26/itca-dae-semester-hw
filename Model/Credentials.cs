using System;
using System.Collections.Generic;
using System.Text;
using tdsv121_dae_final.Authorization;

namespace tdsv121_dae_final.Model
{
    internal class Credentials
    {

        private string password;

        private AuthManager authManager = new AuthManager();


        public Credentials(string userName, string secret)
        {
            password = authManager.hashCredentials(userName, secret);
        }

        public Credentials(string hashed)
        {
            this.password = hashed;
        }

        public string ValidatePassword(string userName, string value)
        {
            bool result = authManager.validateCredentials(userName, this, value);

            if (result)
            {
                return "success";
            }

            return "failure";
        }

        public string GetHashedSecret()
        {
            return password;
        }


        
    }
}
