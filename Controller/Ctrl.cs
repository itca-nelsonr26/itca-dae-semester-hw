
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using tdsv121_dae_final.Components;
using tdsv121_dae_final.Connection;
using tdsv121_dae_final.Model;


namespace tdsv121_dae_final.Controller
{
    internal class Ctrl
    {
        private DataAccess dt = new DataAccess();

        public DataTable ListRoles()
        {
            return dt.LoadData(DataAccess.Tables.ROLES);
        }

        public Array ListAvailableRoles()
        {
            return Enum.GetValues(typeof(UserRoles));
        }


        public ComboField GetRolesComboField()
        {
            return dt.GetRoleFields();
        }
    }
}
