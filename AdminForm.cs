
using System;
using System.Drawing;
using System.Windows.Forms;
using tdsv121_dae_final.Authorization;

namespace tdsv121_dae_final
{
    public partial class AdminForm : Form
    {
        private readonly Session session;

        public AdminForm(Session session)
        {
            this.session = session;
            InitializeComponent();

            Text = "Panel de administrador";

            Button registerAppointmentButton = new Button
            {
                Text = "Registrar cita",
                Size = new Size(180, 45),
                Location = new Point(30, 40)
            };

            registerAppointmentButton.Click += RegisterAppointmentButton_Click;
            Controls.Add(registerAppointmentButton);
        }

        private void RegisterAppointmentButton_Click(object? sender, EventArgs e)
        {
            using RegisterAppointmentForm form = new RegisterAppointmentForm(session);
            form.ShowDialog(this);
        }
    }
}
