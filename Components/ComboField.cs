using System;
using System.Collections.Generic;
using System.Text;

namespace tdsv121_dae_final.Components
{
    internal class ComboField
    {
        private string valueMember;
        private string memberDescription;

        public ComboField(string description, string value)
        {
            valueMember = value;
            memberDescription = description;
        }

        public string getValue()
        {
            return valueMember;
        }

        public string getDescription()
        {
            return memberDescription;
        }
    }
}
