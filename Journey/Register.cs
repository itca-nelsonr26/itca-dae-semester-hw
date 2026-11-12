using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using tdsv121_dae_final.Authorization;
using tdsv121_dae_final.Dao;
using tdsv121_dae_final.Model;
using tdsv121_dae_final.Utils;

namespace tdsv121_dae_final.Journey
{
    internal class Register
    {

        private UserDataObject userDataObject = new UserDataObject();
        private CredentialDataObject credentialDataObject = new CredentialDataObject();

        private int RegisterUser(User user)
        {
            try
            {
                int userId = userDataObject.InsertUser(user);


                return userId;
            } 
            catch (Exception ex)
            {
                return -1;
            }
        }

        private int AddCredentials(int userId, Credentials creds)
        {
            return credentialDataObject.InsertCredential(userId, creds);
        }

        private bool IsUsernameTaken(string username)
        {
            DataTable result = userDataObject.GetUserByUsername(username);

            return result.Rows.Count > 0;
        }

        private bool IsValidEmail(string email)
        {
            DataTable result = userDataObject.GetUserByEmail(email);

            if (result.Rows.Count > 0)
            {
                return false;
            }

            return Validators.IsValidEmail(email);
        }

        private bool isValidDocument(string document)
        {
            DataTable result = userDataObject.GetUserByDocument(document);

            if (result.Rows.Count > 0)
            {
                return false;
            }

            return Validators.IsValidDocument(document);
        }

        private bool isValidPhone(string phone)
        {
            DataTable result = userDataObject.GetUserByPhone(phone);

            if (result.Rows.Count > 0)
            {
                return false;
            }

            return Validators.IsValidPhone(phone);

        }

        private bool IsValidPassword(MaskedTextBox password)
        {
            bool isLongEnough = false;
            bool isShortEnough = false;

            if (password.Text.Length > EnvironmentManager.GetMinPasswordLength())
            {
                isLongEnough = true;
            }

            if (password.Text.Length < EnvironmentManager.GetMaxPasswordLength())
            {
                isShortEnough = true;
            }

            return isShortEnough && isLongEnough;
        }

        // User(int id, string userName, string, string firstName, string lastName, string dui, string email, string phone, Credentials creds, IRole rol)

        public string RegisterUser(
            string userName,
            MaskedTextBox secret,
            MaskedTextBox registrationPin,
            string firstName,
            string lastName,
            string dui,
            string email,
            string phone,
            string rol)
        {

            AuthManager authManager = new AuthManager();

            if (authManager.validateRegistrationSecret(registrationPin.Text) == false )
            {
                return "Error al crear usuario | Pin Invalido";
            }

            if (Enum.TryParse<UserRoles>(rol, out UserRoles validRol))
            {
                Debug.WriteLine(validRol.ToString());
                IRole role = User.CreateRol(validRol);

                userName = userName.ToLower();

                if (IsUsernameTaken(userName))
                {
                    return "Error al Crear Usuario | Nombre de usuario ya existe";
                }

                if (!IsValidPassword(secret))
                {
                    return "Error al Crear Usuario | Password no cumple los requisitos";
                }

                if (!isValidDocument(dui))
                {
                    return "Error al Crear Usuario | DUI no cumple los requisitos";
                }

                if (!isValidPhone(phone))
                {
                    return "Error al Crear Usuario | Telefono no cumple los requisitos";
                }

                if (!IsValidEmail(email))
                {
                    return "Error al Crear Usuario | Email no cumple los requisitos";
                }


                User newUser = new User(
                    userName,
                    secret.Text,
                    firstName,
                    lastName,
                    dui,
                    email,
                    phone,
                    role
                );

                try
                {
                    int idCreated = userDataObject.RegisterUser(newUser);

                    if (idCreated > 0)
                    {
                        return "Usuario Creado";
                    }

                    return "Error al crear usuario";
                } 
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return "Error al crear usuario";
                }

            }
            else
            {
                return "Error al crear usuario - rol no valido";
            }
            
        }

    }
}
