using System;
using System.Collections.Generic;
using System.Text;
using tdsv121_dae_final.Model;
using static tdsv121_dae_final.Model.User;

namespace tdsv121_dae_final.Authorization
{
    public class Session
    {

        private string userName;
        private int userId;

        private UserRoles role;


        public Session( string userName, int userId,  string role)
        {
            this.userName = userName;


            if (Enum.TryParse<UserRoles>(role, true, out UserRoles userRole))
            {
                this.role = userRole;
            }
            else
            {
                throw new ArgumentException("invalid rol");
            }

            this.userId = userId;
        }

        public string GetUserName()
        {
            return userName;
        }

        public UserRoles GetRole()
        {
            return role;
        }

        public int GetUserId()
        {
            return userId;
        }
    }
}
