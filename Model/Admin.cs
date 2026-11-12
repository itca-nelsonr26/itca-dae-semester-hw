using System;
using System.Collections.Generic;
using System.Text;

namespace tdsv121_dae_final.Model
{
    internal class Admin : IRole
    {

        private int id;
        public Admin(int id)
        {
            this.id = id;

        }

        public UserRoles GetRole()
        {
            return UserRoles.ADMIN;
        }


        public int GetId()
        {
            return id;
        }
    }
}
