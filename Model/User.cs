using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;

namespace tdsv121_dae_final.Model
{
    public enum UserRoles
    {
        ADMIN = 1,
        REGULAR = 2
    }
    internal class User
    {
        private int id;

        private string userName;

        private Credentials credentials;

        private string firstName;

        private string lastName;

        private string dui;

        private string email;

        private string phone;

        private IRole rol;

        /*
        public enum UserRoles
        {
            ADMIN = 1,
            REGULAR = 2
        }*/

        public User(
            int id,
            string userName,
            string firstName,
            string lastName,
            string dui,
            string email,
            string phone,
            Credentials creds,
            IRole rol)
        {
            this.id = id;
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dui = dui;
            this.email = email;
            this.phone = phone;
            this.credentials = creds;
            this.rol = rol;
        }

        public User(
            string userName,
            string secret,
            string firstName,
            string lastName,
            string dui,
            string email,
            string phone,
            IRole rol)
        {
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dui = dui;
            this.email = email;
            this.phone = phone;
            this.rol = rol;

            this.credentials = new Credentials(userName, secret);
        }

        public string GetUserName()
        {
            return userName;
        }

        public int GetUserId()
        {
            return id;
        }

        public string GetPhoneNumber()
        {
            return phone;
        }

        public string GetEmail()
        {
            return email;
        }

        public int GetRoleId()
        {
            return rol.GetId();
        }

        public Credentials GetCredentials() 
        {
            return credentials;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public string GetDui()
        {
            return dui;
        }

        public static IRole CreateRol(UserRoles role)
        {
            Debug.WriteLine(role.ToString());
            switch (role)
            {
                case UserRoles.ADMIN:
                    return new Admin(1);
                case UserRoles.REGULAR:
                    return new Regular(2);
                default:
                    throw new ArgumentOutOfRangeException(nameof(role));
            }
        }

        
    }
}
