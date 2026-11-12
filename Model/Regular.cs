using System;
using System.Collections.Generic;
using System.Text;

namespace tdsv121_dae_final.Model
{
    internal class Regular : IRole
    {


        private int id;

        public Regular(int id)
        {
            this.id = id;
        }
        
        public UserRoles GetRole()
        {
            return UserRoles.REGULAR;
        }

        public int GetId()
        {
            return id;
        }
    }
}
