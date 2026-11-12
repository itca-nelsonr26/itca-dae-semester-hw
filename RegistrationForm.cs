using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tdsv121_dae_final.Controller;
using tdsv121_dae_final.Journey;



namespace tdsv121_dae_final
{
    public partial class RegistrationForm : Form
    {

        private LoginForm previousLoginForm;

        private Ctrl controller = new Ctrl();

        public RegistrationForm(LoginForm loginForm)
        {
            InitializeComponent();
            previousLoginForm = loginForm;
            LoadData();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            previousLoginForm.Show();
            this.Close();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string userName = txt_username.Text;
            string role = cb_rol.SelectedValue.ToString();
            string firstName = txt_firstname.Text;
            string lastName = txt_lastname.Text;
            string dui = txt_dui.Text;
            string email = txt_email.Text;
            string phoneNumber = txt_phone.Text;

            Register registration = new Register();

            string registrationResult = registration.RegisterUser(
                userName,
                msk_txt_password,
                msk_txt_pin,
                firstName,
                lastName,
                dui,
                email,
                phoneNumber,
                role
            );

            MessageBox.Show(registrationResult);

            if (registrationResult == "Usuario Creado")
            {
                previousLoginForm.Show();
                this.Close();
            } 
            else
            {
                ClearUserDetails();
            }


        }

        private void LoadData()
        {
            cb_rol.DataSource = controller.ListRoles();

            cb_rol.DisplayMember = controller.GetRolesComboField().getDescription();
            cb_rol.ValueMember = controller.GetRolesComboField().getValue();

        }


        private void ClearUserDetails()
        {
            txt_username.Clear();
            msk_txt_password.Clear();
            txt_firstname.Clear();
            txt_lastname.Clear();
            txt_dui.Clear();
            txt_email.Clear();
            txt_phone.Clear();
        }


        private void ShowPinField(bool shoudShow)
        {
            lbl_pin.Visible = shoudShow;
            msk_txt_pin.Visible = shoudShow;
        }


    }
}
