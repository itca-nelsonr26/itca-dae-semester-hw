
namespace tdsv121_dae_final
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lbl_userName = new Label();
            lbl_password = new Label();
            txt_username = new TextBox();
            msk_txt_password = new MaskedTextBox();
            btn_back = new Button();
            btn_register = new Button();
            label1 = new Label();
            cb_rol = new ComboBox();
            lbl_pin = new Label();
            msk_txt_pin = new MaskedTextBox();
            label2 = new Label();
            txt_firstname = new TextBox();
            label3 = new Label();
            txt_lastname = new TextBox();
            Email = new Label();
            txt_email = new TextBox();
            label4 = new Label();
            txt_dui = new TextBox();
            label5 = new Label();
            txt_phone = new TextBox();

            SuspendLayout();

            // FORM
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(480, 570);
            ControlBox = true;
            MaximizeBox = false;
            MinimizeBox = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TDSV121 - Registro";
            Name = "RegistrationForm";

            // LABEL STYLING
            Font labelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Color labelColor = Color.FromArgb(203, 213, 225);

            // USERNAME LABEL
            lbl_userName.Text = "Nombre de Usuario";
            lbl_userName.Font = labelFont;
            lbl_userName.ForeColor = labelColor;
            lbl_userName.Location = new Point(45, 105);
            lbl_userName.Size = new Size(165, 25);
            lbl_userName.TextAlign = ContentAlignment.MiddleRight;

            // USERNAME FIELD
            txt_username.BackColor = Color.FromArgb(40, 52, 72);
            txt_username.ForeColor = Color.White;
            txt_username.BorderStyle = BorderStyle.FixedSingle;
            txt_username.CharacterCasing = CharacterCasing.Lower;
            txt_username.Font = new Font("Segoe UI", 11F);
            txt_username.Location = new Point(220, 105);
            txt_username.Size = new Size(210, 30);
            txt_username.TabIndex = 2;
            txt_username.TextAlign = HorizontalAlignment.Center;

            // PASSWORD LABEL
            lbl_password.Text = "Contraseña";
            lbl_password.Font = labelFont;
            lbl_password.ForeColor = labelColor;
            lbl_password.Location = new Point(45, 150);
            lbl_password.Size = new Size(165, 25);
            lbl_password.TextAlign = ContentAlignment.MiddleRight;

            // PASSWORD FIELD
            msk_txt_password.BackColor = Color.FromArgb(40, 52, 72);
            msk_txt_password.ForeColor = Color.White;
            msk_txt_password.BorderStyle = BorderStyle.FixedSingle;
            msk_txt_password.Font = new Font("Segoe UI", 11F);
            msk_txt_password.Location = new Point(220, 150);
            msk_txt_password.Size = new Size(210, 30);
            msk_txt_password.PasswordChar = '*';
            msk_txt_password.TabIndex = 3;
            msk_txt_password.TextAlign = HorizontalAlignment.Center;

            // FIRST NAME LABEL
            label2.Text = "Nombre";
            label2.Font = labelFont;
            label2.ForeColor = labelColor;
            label2.Location = new Point(45, 195);
            label2.Size = new Size(165, 25);
            label2.TextAlign = ContentAlignment.MiddleRight;

            // FIRST NAME FIELD
            txt_firstname.BackColor = Color.FromArgb(40, 52, 72);
            txt_firstname.ForeColor = Color.White;
            txt_firstname.BorderStyle = BorderStyle.FixedSingle;
            txt_firstname.Font = new Font("Segoe UI", 11F);
            txt_firstname.Location = new Point(220, 195);
            txt_firstname.Size = new Size(210, 30);
            txt_firstname.TabIndex = 11;
            txt_firstname.TextAlign = HorizontalAlignment.Center;

            // LAST NAME LABEL
            label3.Text = "Apellido";
            label3.Font = labelFont;
            label3.ForeColor = labelColor;
            label3.Location = new Point(45, 240);
            label3.Size = new Size(165, 25);
            label3.TextAlign = ContentAlignment.MiddleRight;

            // LAST NAME FIELD
            txt_lastname.BackColor = Color.FromArgb(40, 52, 72);
            txt_lastname.ForeColor = Color.White;
            txt_lastname.BorderStyle = BorderStyle.FixedSingle;
            txt_lastname.Font = new Font("Segoe UI", 11F);
            txt_lastname.Location = new Point(220, 240);
            txt_lastname.Size = new Size(210, 30);
            txt_lastname.TabIndex = 13;
            txt_lastname.TextAlign = HorizontalAlignment.Center;

            // EMAIL LABEL
            Email.Text = "Email";
            Email.Font = labelFont;
            Email.ForeColor = labelColor;
            Email.Location = new Point(45, 285);
            Email.Size = new Size(165, 25);
            Email.TextAlign = ContentAlignment.MiddleRight;

            // EMAIL FIELD
            txt_email.BackColor = Color.FromArgb(40, 52, 72);
            txt_email.ForeColor = Color.White;
            txt_email.BorderStyle = BorderStyle.FixedSingle;
            txt_email.CharacterCasing = CharacterCasing.Lower;
            txt_email.Font = new Font("Segoe UI", 11F);
            txt_email.Location = new Point(220, 285);
            txt_email.Size = new Size(210, 30);
            txt_email.TabIndex = 15;
            txt_email.TextAlign = HorizontalAlignment.Center;

            // DUI LABEL
            label4.Text = "Documento";
            label4.Font = labelFont;
            label4.ForeColor = labelColor;
            label4.Location = new Point(45, 330);
            label4.Size = new Size(165, 25);
            label4.TextAlign = ContentAlignment.MiddleRight;

            // DUI FIELD
            txt_dui.BackColor = Color.FromArgb(40, 52, 72);
            txt_dui.ForeColor = Color.White;
            txt_dui.BorderStyle = BorderStyle.FixedSingle;
            txt_dui.Font = new Font("Segoe UI", 11F);
            txt_dui.Location = new Point(220, 330);
            txt_dui.Size = new Size(210, 30);
            txt_dui.TabIndex = 17;
            txt_dui.TextAlign = HorizontalAlignment.Center;

            // PHONE LABEL
            label5.Text = "Teléfono";
            label5.Font = labelFont;
            label5.ForeColor = labelColor;
            label5.Location = new Point(45, 375);
            label5.Size = new Size(165, 25);
            label5.TextAlign = ContentAlignment.MiddleRight;

            // PHONE FIELD
            txt_phone.BackColor = Color.FromArgb(40, 52, 72);
            txt_phone.ForeColor = Color.White;
            txt_phone.BorderStyle = BorderStyle.FixedSingle;
            txt_phone.Font = new Font("Segoe UI", 11F);
            txt_phone.Location = new Point(220, 375);
            txt_phone.Size = new Size(210, 30);
            txt_phone.TabIndex = 19;
            txt_phone.TextAlign = HorizontalAlignment.Center;

            // ROLE LABEL
            label1.Text = "Rol";
            label1.Font = labelFont;
            label1.ForeColor = labelColor;
            label1.Location = new Point(45, 420);
            label1.Size = new Size(165, 25);
            label1.TextAlign = ContentAlignment.MiddleRight;

            // ROLE COMBOBOX
            cb_rol.BackColor = Color.FromArgb(40, 52, 72);
            cb_rol.ForeColor = Color.White;
            cb_rol.FlatStyle = FlatStyle.Flat;
            cb_rol.Font = new Font("Segoe UI", 11F);
            cb_rol.Location = new Point(220, 420);
            cb_rol.Size = new Size(210, 30);
            cb_rol.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_rol.FormattingEnabled = true;
            cb_rol.TabIndex = 7;

            // REGISTRATION PIN LABEL
            lbl_pin.Text = "PIN de Registro";
            lbl_pin.Font = labelFont;
            lbl_pin.ForeColor = labelColor;
            lbl_pin.Location = new Point(45, 55);
            lbl_pin.Size = new Size(165, 25);
            lbl_pin.TextAlign = ContentAlignment.MiddleRight;

            // REGISTRATION PIN FIELD
            msk_txt_pin.BackColor = Color.FromArgb(40, 52, 72);
            msk_txt_pin.ForeColor = Color.White;
            msk_txt_pin.BorderStyle = BorderStyle.FixedSingle;
            msk_txt_pin.Font = new Font("Segoe UI", 11F);
            msk_txt_pin.Location = new Point(220, 55);
            msk_txt_pin.Size = new Size(210, 30);
            msk_txt_pin.PasswordChar = '*';
            msk_txt_pin.TabIndex = 9;
            msk_txt_pin.TextAlign = HorizontalAlignment.Center;

            // BACK BUTTON
            btn_back.Text = "Volver";
            btn_back.BackColor = Color.FromArgb(51, 65, 85);
            btn_back.ForeColor = Color.White;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.FlatAppearance.BorderSize = 0;
            btn_back.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_back.Location = new Point(100, 490);
            btn_back.Size = new Size(120, 40);
            btn_back.TabIndex = 4;
            btn_back.Cursor = Cursors.Hand;
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;

            // REGISTER BUTTON
            btn_register.Text = "Registrar";
            btn_register.BackColor = Color.FromArgb(59, 130, 246);
            btn_register.ForeColor = Color.White;
            btn_register.FlatStyle = FlatStyle.Flat;
            btn_register.FlatAppearance.BorderSize = 0;
            btn_register.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_register.Location = new Point(260, 490);
            btn_register.Size = new Size(120, 40);
            btn_register.TabIndex = 5;
            btn_register.Cursor = Cursors.Hand;
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += btn_register_Click;

            // ADD CONTROLS
            Controls.Add(lbl_userName);
            Controls.Add(lbl_password);
            Controls.Add(txt_username);
            Controls.Add(msk_txt_password);
            Controls.Add(btn_back);
            Controls.Add(btn_register);
            Controls.Add(label1);
            Controls.Add(cb_rol);
            Controls.Add(lbl_pin);
            Controls.Add(msk_txt_pin);
            Controls.Add(label2);
            Controls.Add(txt_firstname);
            Controls.Add(label3);
            Controls.Add(txt_lastname);
            Controls.Add(Email);
            Controls.Add(txt_email);
            Controls.Add(label4);
            Controls.Add(txt_dui);
            Controls.Add(label5);
            Controls.Add(txt_phone);

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_userName;
        private Label lbl_password;
        private TextBox txt_username;
        private MaskedTextBox msk_txt_password;
        private Button btn_back;
        private Button btn_register;
        private Label label1;
        private ComboBox cb_rol;
        private Label lbl_pin;
        private MaskedTextBox msk_txt_pin;
        private Label label2;
        private TextBox txt_firstname;
        private Label label3;
        private TextBox txt_lastname;
        private Label Email;
        private TextBox txt_email;
        private Label label4;
        private TextBox txt_dui;
        private Label label5;
        private TextBox txt_phone;
    }
}
