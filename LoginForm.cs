using System.Diagnostics;
using tdsv121_dae_final.Authorization;
using tdsv121_dae_final.Journey;
using tdsv121_dae_final.Model;
using tdsv121_dae_final.Utils;

namespace tdsv121_dae_final
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Debug.WriteLine(EnvironmentManager.GetRegistrationSecret());
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm(this);

            registrationForm.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            LoginFlow flow = new LoginFlow();

            Session result = flow.LoginUser(txtUsernameField.Text, msk_password);


            if (result == null)
            {
                MessageBox.Show("Credenciales invalidas");
            } 
            else
            {
                if (result.GetRole() == UserRoles.ADMIN)
                {
                    AdminForm adminForm = new AdminForm(result);
                    adminForm.Show();
                    this.Hide();
                } 
                else
                {
                    ClientForm clientForm = new ClientForm(result);
                    clientForm.Show();
                    this.Hide();
                }
            } 
            
        }
    }
}
