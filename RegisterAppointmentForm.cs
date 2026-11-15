using System;
using System.Drawing;
using System.Windows.Forms;
using tdsv121_dae_final.Authorization;
using tdsv121_dae_final.Dao;

namespace tdsv121_dae_final
{
    public class RegisterAppointmentForm : Form
    {
        private readonly Session session;
        private readonly AppointmentRegistrationDataObject appointmentData = new AppointmentRegistrationDataObject();

        private readonly TextBox txtDocument = new TextBox();
        private readonly TextBox txtFirstName = new TextBox();
        private readonly TextBox txtLastName = new TextBox();
        private readonly TextBox txtPhone = new TextBox();
        private readonly TextBox txtEmail = new TextBox();
        private readonly TextBox txtPlate = new TextBox();
        private readonly TextBox txtMaker = new TextBox();
        private readonly TextBox txtCarModel = new TextBox();
        private readonly DateTimePicker dtpAppointment = new DateTimePicker();
        private readonly Button btnSave = new Button();
        private readonly Button btnCancel = new Button();

        public RegisterAppointmentForm(Session session)
        {
            this.session = session;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "Registrar cita";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(620, 650);
            MinimumSize = new Size(620, 650);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Font = new Font("Segoe UI", 10);

            Label title = new Label
            {
                Text = "REGISTRO DE CITA",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 20)
            };
            Controls.Add(title);

            int labelX = 35;
            int inputX = 190;
            int y = 80;
            int spacing = 48;
            int inputWidth = 370;

            AddField("DUI / Documento", txtDocument, labelX, inputX, y, inputWidth);
            y += spacing;
            AddField("Nombre", txtFirstName, labelX, inputX, y, inputWidth);
            y += spacing;
            AddField("Apellido", txtLastName, labelX, inputX, y, inputWidth);
            y += spacing;
            AddField("Teléfono", txtPhone, labelX, inputX, y, inputWidth);
            txtPhone.MaxLength = 8;
            y += spacing;
            AddField("Correo electrónico", txtEmail, labelX, inputX, y, inputWidth);
            y += spacing;
            AddField("Placa", txtPlate, labelX, inputX, y, inputWidth);
            y += spacing;
            AddField("Marca", txtMaker, labelX, inputX, y, inputWidth);
            y += spacing;
            AddField("Modelo", txtCarModel, labelX, inputX, y, inputWidth);
            y += spacing;

            Label dateLabel = new Label
            {
                Text = "Fecha y hora",
                AutoSize = true,
                Location = new Point(labelX, y + 5)
            };
            Controls.Add(dateLabel);

            dtpAppointment.Location = new Point(inputX, y);
            dtpAppointment.Size = new Size(inputWidth, 30);
            dtpAppointment.Format = DateTimePickerFormat.Custom;
            dtpAppointment.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpAppointment.ShowUpDown = true;
            dtpAppointment.Value = DateTime.Now.AddHours(1);
            Controls.Add(dtpAppointment);

            btnSave.Text = "Registrar cita";
            btnSave.Location = new Point(inputX, y + 65);
            btnSave.Size = new Size(160, 40);
            btnSave.Click += BtnSave_Click;
            Controls.Add(btnSave);

            btnCancel.Text = "Cancelar";
            btnCancel.Location = new Point(inputX + 175, y + 65);
            btnCancel.Size = new Size(120, 40);
            btnCancel.Click += (sender, args) => Close();
            Controls.Add(btnCancel);
        }

        private void AddField(string labelText, TextBox textBox, int labelX, int inputX, int y, int inputWidth)
        {
            Label label = new Label
            {
                Text = labelText,
                AutoSize = true,
                Location = new Point(labelX, y + 5)
            };

            textBox.Location = new Point(inputX, y);
            textBox.Size = new Size(inputWidth, 30);

            Controls.Add(label);
            Controls.Add(textBox);
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                int appointmentId = appointmentData.RegisterAppointment(
                    txtDocument.Text.Trim(),
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPlate.Text.Trim().ToUpperInvariant(),
                    txtMaker.Text.Trim(),
                    txtCarModel.Text.Trim(),
                    dtpAppointment.Value,
                    session.GetUserId());

                MessageBox.Show(
                    $"La cita se registró correctamente. Número de cita: {appointmentId}",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo registrar la cita",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
