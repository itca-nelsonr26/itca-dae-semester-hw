using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using tdsv121_dae_final.Model;
using tdsv121_dae_final.Utils;

namespace tdsv121_dae_final.Authorization
{
    internal class AuthManager
    {
        private PasswordHasher<string> hasher  = new PasswordHasher<string>();
       public string hashCredentials(string userName, string secret)
        {
            return hasher.HashPassword(userName, secret);
        }

       public bool validateCredentials(string userName, Credentials creds, string value)
        {
            var result = hasher.VerifyHashedPassword(userName, creds.GetHashedSecret(), value);

            if (result != PasswordVerificationResult.Failed)
            {
                return true;
            }

            return false;
        }

       public bool validateRegistrationSecret(string secret)
        {
            return secret == EnvironmentManager.GetRegistrationSecret();
        }
    }
}
