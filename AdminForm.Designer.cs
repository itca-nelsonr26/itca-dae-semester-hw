
namespace tdsv121_dae_final
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            lblUsuario = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            label6 = new Label();
            label5 = new Label();
            comboBox5 = new ComboBox();
            comboBox4 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            tabPage2 = new TabPage();
            dataGridView3 = new DataGridView();
            button7 = new Button();
            button8 = new Button();
            label15 = new Label();
            textBox7 = new TextBox();
            label14 = new Label();
            textBox6 = new TextBox();
            label13 = new Label();
            textBox5 = new TextBox();
            dataGridView2 = new DataGridView();
            button6 = new Button();
            button5 = new Button();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            button1 = new Button();
            button9 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 0;
            label1.Text = "Panel de administrador";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = SystemColors.ControlLightLight;
            lblUsuario.Location = new Point(542, 9);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(38, 15);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "label2";
            lblUsuario.Click += lblUsuario_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(76, 44);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1017, 486);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(comboBox5);
            tabPage1.Controls.Add(comboBox4);
            tabPage1.Controls.Add(dateTimePicker1);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(comboBox3);
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1009, 458);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Gestion de citas";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(47, 215);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(909, 166);
            dataGridView1.TabIndex = 14;
            // 
            // button4
            // 
            button4.Location = new Point(733, 168);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 13;
            button4.Text = "Limpiar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(431, 168);
            button3.Name = "button3";
            button3.Size = new Size(116, 23);
            button3.TabIndex = 12;
            button3.Text = "Actualizar estado";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(133, 168);
            button2.Name = "button2";
            button2.Size = new Size(109, 23);
            button2.TabIndex = 11;
            button2.Text = "Agendar cita";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(47, 107);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 10;
            label6.Text = "Estado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(307, 102);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 9;
            label5.Text = "Tipo de servicio";
            label5.Click += label5_Click;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(133, 104);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(121, 23);
            comboBox5.TabIndex = 8;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(431, 99);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(141, 23);
            comboBox4.TabIndex = 7;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(654, 99);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(647, 46);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 5;
            label4.Text = "Mecanico";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(345, 46);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 4;
            label3.Text = "Vehiculo";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 46);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 3;
            label2.Text = "Cliente";
            label2.Click += label2_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(733, 43);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(431, 43);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(141, 23);
            comboBox2.TabIndex = 1;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(133, 43);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView3);
            tabPage2.Controls.Add(button7);
            tabPage2.Controls.Add(button8);
            tabPage2.Controls.Add(label15);
            tabPage2.Controls.Add(textBox7);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(textBox6);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(textBox5);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1009, 458);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Clientes y vehiculos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(35, 297);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(912, 104);
            dataGridView3.TabIndex = 20;
            dataGridView3.CellClick += dataGridView3_CellClick;
            // 
            // button7
            // 
            button7.Location = new Point(160, 423);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 19;
            button7.Text = "Editar auto";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(35, 423);
            button8.Name = "button8";
            button8.Size = new Size(100, 29);
            button8.TabIndex = 18;
            button8.Text = "Guardar auto";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(695, 268);
            label15.Name = "label15";
            label15.Size = new Size(48, 15);
            label15.TabIndex = 17;
            label15.Text = "Modelo";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(772, 268);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 16;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(383, 268);
            label14.Name = "label14";
            label14.Size = new Size(40, 15);
            label14.TabIndex = 15;
            label14.Text = "Marca";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(450, 268);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 14;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(138, 271);
            label13.Name = "label13";
            label13.Size = new Size(35, 15);
            label13.TabIndex = 13;
            label13.Text = "Placa";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(185, 268);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 12;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(35, 81);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(912, 104);
            dataGridView2.TabIndex = 11;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // button6
            // 
            button6.Location = new Point(160, 200);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 10;
            button6.Text = "Editar cliente";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(35, 200);
            button5.Name = "button5";
            button5.Size = new Size(100, 29);
            button5.TabIndex = 4;
            button5.Text = "Guardar cliente";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(727, 50);
            label12.Name = "label12";
            label12.Size = new Size(43, 15);
            label12.TabIndex = 9;
            label12.Text = "Correo";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(462, 50);
            label11.Name = "label11";
            label11.Size = new Size(53, 15);
            label11.TabIndex = 8;
            label11.Text = "Telefono";
            label11.Click += label11_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(240, 50);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 7;
            label10.Text = "Nombre";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(35, 50);
            label9.Name = "label9";
            label9.Size = new Size(26, 15);
            label9.TabIndex = 6;
            label9.Text = "DUI";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(814, 47);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 5;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(539, 47);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 4;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(307, 47);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(82, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(462, 226);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 1;
            label8.Text = "Vehiculo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(462, 13);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 0;
            label7.Text = "Clientes";
            // 
            // button1
            // 
            button1.Location = new Point(1066, 9);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Cerrar sesion";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button9
            // 
            button9.Location = new Point(927, 9);
            button9.Name = "button9";
            button9.Size = new Size(100, 29);
            button9.TabIndex = 4;
            button9.Text = "Agregar usuario";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(1181, 568);
            Controls.Add(button9);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Controls.Add(lblUsuario);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblUsuario;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button3;
        private Button button2;
        private Label label6;
        private Label label5;
        private ComboBox comboBox5;
        private ComboBox comboBox4;
        private DateTimePicker dateTimePicker1;
        private Button button4;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button button6;
        private Button button5;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label8;
        private Label label7;
        private DataGridView dataGridView3;
        private Button button7;
        private Button button8;
        private Label label15;
        private TextBox textBox7;
        private Label label14;
        private TextBox textBox6;
        private Label label13;
        private TextBox textBox5;
        private Button button9;
    }
}
