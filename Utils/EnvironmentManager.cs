using System;
using System.Collections.Generic;
using System.Text;
using DotNetEnv;

namespace tdsv121_dae_final.Utils
{
    public static class EnvironmentManager
    {
            
        static EnvironmentManager()
        {
            string projectRoot = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\")
            );
            string envPath = Path.Combine(projectRoot, ".env");
            Env.Load(envPath);
        }

        public static string GetRegistrationSecret()
        {
            
            return Env.GetString("USER_REGISTER_KEY", "NOT FOUND");
        }

        public static int GetMinPasswordLength()
        {
            return Env.GetInt("PASS_MIN_LENGTH", 2);
        }

        public static int GetMaxPasswordLength()
        {
            return Env.GetInt("PASS_MAX_LENGTH", 2);
        }

        public static int GetPhoneNumberLength()
        {
            return Env.GetInt("PHONE_LENGTH");
        }

        public static int GetDocumentNumberLength()
        {
            return Env.GetInt("DOC_LENGTH");
        }
    }
}
