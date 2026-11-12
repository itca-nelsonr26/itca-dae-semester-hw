
namespace tdsv121_dae_final
{
    partial class LoginForm
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
            txtUsernameField = new TextBox();
            btn_register = new Button();
            btn_login = new Button();
            msk_password = new MaskedTextBox();
            SuspendLayout();
            // 
            // txtUsernameField
            // 
            txtUsernameField.BackColor = Color.FromArgb(40, 52, 72);
            txtUsernameField.BorderStyle = BorderStyle.FixedSingle;
            txtUsernameField.CharacterCasing = CharacterCasing.Lower;
            txtUsernameField.Font = new Font("Segoe UI", 12F);
            txtUsernameField.ForeColor = Color.White;
            txtUsernameField.Location = new Point(92, 220);
            txtUsernameField.Name = "txtUsernameField";
            txtUsernameField.Size = new Size(224, 29);
            txtUsernameField.TabIndex = 0;
            txtUsernameField.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_register
            // 
            btn_register.BackColor = Color.FromArgb(51, 65, 85);
            btn_register.Cursor = Cursors.Hand;
            btn_register.FlatAppearance.BorderSize = 0;
            btn_register.FlatStyle = FlatStyle.Flat;
            btn_register.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_register.ForeColor = Color.White;
            btn_register.Location = new Point(92, 340);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(100, 38);
            btn_register.TabIndex = 2;
            btn_register.Text = "Registrar";
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += btn_register_Click;
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.FromArgb(59, 130, 246);
            btn_login.Cursor = Cursors.Hand;
            btn_login.FlatAppearance.BorderSize = 0;
            btn_login.FlatStyle = FlatStyle.Flat;
            btn_login.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_login.ForeColor = Color.White;
            btn_login.Location = new Point(216, 340);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(100, 38);
            btn_login.TabIndex = 3;
            btn_login.Text = "Acceder";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // msk_password
            // 
            msk_password.BackColor = Color.FromArgb(40, 52, 72);
            msk_password.BorderStyle = BorderStyle.FixedSingle;
            msk_password.Font = new Font("Segoe UI", 12F);
            msk_password.ForeColor = Color.White;
            msk_password.Location = new Point(92, 280);
            msk_password.Name = "msk_password";
            msk_password.PasswordChar = '*';
            msk_password.Size = new Size(224, 29);
            msk_password.TabIndex = 1;
            msk_password.TextAlign = HorizontalAlignment.Center;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(408, 469);
            Controls.Add(msk_password);
            Controls.Add(btn_login);
            Controls.Add(btn_register);
            Controls.Add(txtUsernameField);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TDSV121 - Sistema de acceso";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsernameField;
        private Button btn_register;
        private Button btn_login;
        private MaskedTextBox msk_password;
    }
}
