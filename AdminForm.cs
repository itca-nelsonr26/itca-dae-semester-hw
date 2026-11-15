using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tdsv121_dae_final.Authorization;
using tdsv121_dae_final.Dao;


namespace tdsv121_dae_final
{
    public partial class AdminForm : Form
    {
        private Session session;

        public AdminForm(Session session)
        {
            InitializeComponent();
            this.session = session;
            lblUsuario.Text = "Bienvenido, " + session.GetUserName();
            // Llamamos al método para cargar la tabla al abrir el formulario
            CargarCitasAdmin();
            CargarComboBoxes();
            CargarClientesYVehiculos();
        }



        private void CargarComboBoxes()
        {
            try
            {
                AppointmentDataObject dao = new AppointmentDataObject();

                // 1. ComboBox de Clientes (comboBox1)
                comboBox1.DataSource = dao.GetCustomersForCombo();
                comboBox1.DisplayMember = "fullname";
                comboBox1.ValueMember = "id";

                // 2. ComboBox de Vehículos (comboBox2)
                comboBox2.DataSource = dao.GetCarsForCombo();
                comboBox2.DisplayMember = "plate";
                comboBox2.ValueMember = "id";

                // 3. ComboBox de Mecánicos (comboBox3)
                comboBox3.DataSource = dao.GetMechanicsForCombo();
                comboBox3.DisplayMember = "username";
                comboBox3.ValueMember = "id";

                // 4. ComboBox de Estado (comboBox5) 
                comboBox5.Items.Clear();
                comboBox5.Items.Add("Activa");
                comboBox5.Items.Add("En Proceso");
                comboBox5.Items.Add("Finalizada");
                comboBox5.Items.Add("Cancelada");
                if (comboBox5.Items.Count > 0) comboBox5.SelectedIndex = 0;

                // 5. ComboBox de Tipo de servicio (comboBox4) 
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Mantenimiento Preventivo");
                comboBox4.Items.Add("Reparación General");
                comboBox4.Items.Add("Diagnóstico Electrónico");
                if (comboBox4.Items.Count > 0) comboBox4.SelectedIndex = 0;


                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los selectores: " + ex.Message);
            }
        }
        private void CargarCitasAdmin()
        {
            try
            {
                // Instanciamos el DataObject de citas que acabamos de crear
                AppointmentDataObject appointmentDao = new AppointmentDataObject();
                DataTable dt = appointmentDao.GetAllAppointmentsAdmin();

                // Llenamos el DataGridView de la pestaña de gestión de citas
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las citas: " + ex.Message);
            }
        }

        // Métodos vacíos requeridos por el diseñador
        private void lblUsuario_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validamos que haya selecciones válidas en los ComboBox
                if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null || comboBox3.SelectedValue == null)
                {
                    MessageBox.Show("Por favor seleccione un cliente, un vehículo y un mecánico.");
                    return;
                }

                // Extraemos los IDs y valores de los controles de la interfaz
                int customerId = Convert.ToInt32(comboBox1.SelectedValue);
                int carId = Convert.ToInt32(comboBox2.SelectedValue);
                int mechanicId = Convert.ToInt32(comboBox3.SelectedValue);
                string status = comboBox5.SelectedItem?.ToString() ?? "Activa";
                DateTime appointmentDate = dateTimePicker1.Value;

                // Instanciamos el DAO y guardamos
                AppointmentDataObject dao = new AppointmentDataObject();
                int rowsAffected = dao.InsertAppointment(status, appointmentDate, customerId, carId, mechanicId);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("¡Cita agendada correctamente!");

                    // Recargamos el DataGridView de inmediato para que aparezca la nueva cita
                    CargarCitasAdmin();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la cita.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agendar: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado una fila en la tabla
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione una cita de la tabla para actualizar su estado.");
                    return;
                }

                // Obtenemos el ID de la cita seleccionada en la tabla
                int appointmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdCita"].Value);
                string nuevoEstado = comboBox5.SelectedItem?.ToString() ?? "Activa";

                AppointmentDataObject dao = new AppointmentDataObject();
                int rowsAffected = dao.UpdateAppointmentStatus(appointmentId, nuevoEstado);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("¡Estado de la cita actualizado correctamente!");
                    CargarCitasAdmin(); // Recargamos la tabla para ver el cambio reflejado
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione una cita de la tabla para eliminar.");
                    return;
                }

                int appointmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdCita"].Value);

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea eliminar esta cita?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    AppointmentDataObject dao = new AppointmentDataObject();
                    int rowsAffected = dao.DeleteAppointment(appointmentId);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cita eliminada correctamente.");
                        CargarCitasAdmin(); // Recargar la tabla
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la cita.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la cita: " + ex.Message);
            }
        }

        private void CargarClientesYVehiculos()
        {
            try
            {
                // Cargar Clientes
                CustomerDataObject customerDao = new CustomerDataObject();
                dataGridView2.DataSource = customerDao.GetAllCustomers(); // Ajusta el nombre si tu grid de clientes se llama diferente
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Cargar Vehículos
                CarDataObject carDao = new CarDataObject();
                dataGridView3.DataSource = carDao.GetAllCars(); // Ajusta el nombre si tu grid de autos se llama diferente
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de clientes y vehículos: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string dui = textBox1.Text.Trim();
                string nombreCompleto = textBox2.Text.Trim(); // Puedes dividirlo en nombre y apellido si usas dos campos
                string telefono = textBox3.Text.Trim();
                string correo = textBox4.Text.Trim();

                // Separamos el nombre y apellido básico si ingresan todo en un campo o adáptalo a tus TextBox
                string[] partesNombre = nombreCompleto.Split(' ');
                string firstName = partesNombre[0];
                string lastName = partesNombre.Length > 1 ? partesNombre[1] : "";

                CustomerDataObject dao = new CustomerDataObject();
                int resultado = dao.InsertCustomer(dui, firstName, lastName, telefono, correo);

                if (resultado > 0)
                {
                    MessageBox.Show("¡Cliente guardado con éxito!");
                    CargarClientesYVehiculos(); // Refresca la tabla y también actualizará el ComboBox de la otra pestaña si lo recargas
                    CargarComboBoxes(); // Para que el nuevo cliente aparezca inmediatamente al querer agendar cita
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                // Validamos que se haya seleccionado un cliente de la tabla de clientes para asociarle el auto
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione de la tabla el cliente dueño del vehículo.");
                    return;
                }

                int customerId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);
                string placa = textBox5.Text.Trim();
                string marca = textBox6.Text.Trim();
                string modelo = textBox7.Text.Trim();

                CarDataObject dao = new CarDataObject();
                int resultado = dao.InsertCar(placa, modelo, marca, customerId);

                if (resultado > 0)
                {
                    MessageBox.Show("¡Vehículo registrado con éxito!");
                    CargarClientesYVehiculos();
                    CargarComboBoxes();
                    textBox5.Clear(); textBox6.Clear(); textBox7.Clear();

                }
                else
                {
                    MessageBox.Show("No se pudo registrar el vehículo.");
                    textBox5.Clear(); textBox6.Clear(); textBox7.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no sea el encabezado de la tabla
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Usamos ?.ToString() ?? "" para evitar advertencias de nulos
                textBox1.Text = row.Cells["DUI"].Value?.ToString() ?? "";

                string nombre = row.Cells["Nombre"].Value?.ToString() ?? "";
                string apellido = row.Cells["Apellido"].Value?.ToString() ?? "";
                textBox2.Text = nombre + " " + apellido;

                textBox3.Text = row.Cells["Telefono"].Value?.ToString() ?? "";
                textBox4.Text = row.Cells["Correo"].Value?.ToString() ?? "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Validamos que haya una fila seleccionada en la tabla
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione un cliente de la tabla para editar.");
                    return;
                }

                // Obtenemos el ID de forma directa y segura con SelectedRows[0] (igual que en las citas)
                int customerId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);

                string dui = textBox1.Text.Trim();
                string nombreCompleto = textBox2.Text.Trim();
                string telefono = textBox3.Text.Trim();
                string correo = textBox4.Text.Trim();

                // Separamos nombre y apellido básico
                string[] partesNombre = nombreCompleto.Split(' ');
                string firstName = partesNombre[0];
                string lastName = partesNombre.Length > 1 ? partesNombre[1] : "";

                CustomerDataObject dao = new CustomerDataObject();
                int resultado = dao.UpdateCustomer(customerId, dui, firstName, lastName, telefono, correo);

                if (resultado > 0)
                {
                    MessageBox.Show("¡Cliente actualizado correctamente!");
                    CargarClientesYVehiculos();
                    CargarComboBoxes();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar cliente: " + ex.Message);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no sea el encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];


                textBox5.Text = row.Cells["Placa"].Value?.ToString() ?? "";
                textBox6.Text = row.Cells["Marca"].Value?.ToString() ?? "";
                textBox7.Text = row.Cells["Modelo"].Value?.ToString() ?? "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Validamos que haya una fila seleccionada en la tabla de vehículos
                if (dataGridView3.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione un vehículo de la tabla para editar.");
                    return;
                }

                // Obtenemos el ID del vehículo seleccionado
                int carId = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["id"].Value);

                // Obtenemos el ID del cliente al que pertenece (ya sea de la misma celda de la tabla de autos o del cliente seleccionado en la tabla izquierda)
                int customerId = 0;
                if (dataGridView3.SelectedRows[0].Cells["IdCliente"].Value != null)
                {
                    customerId = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["IdCliente"].Value);
                }
                else if (dataGridView2.SelectedRows.Count > 0)
                {
                    customerId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);
                }
                else
                {
                    MessageBox.Show("Por favor seleccione también el cliente dueño del vehículo.");
                    return;
                }

                string placa = textBox5.Text.Trim();
                string marca = textBox6.Text.Trim();
                string modelo = textBox7.Text.Trim();

                CarDataObject dao = new CarDataObject();
                int resultado = dao.UpdateCar(carId, placa, modelo, marca, customerId);

                if (resultado > 0)
                {
                    MessageBox.Show("¡Vehículo actualizado correctamente!");
                    CargarClientesYVehiculos(); // Refresca las tablas
                    CargarComboBoxes();         // Refresca los selectores de la pestaña de citas
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el vehículo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar vehículo: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
        "¿Está seguro de que desea cerrar sesión?",
        "Cerrar sesión",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (resultado == DialogResult.Yes)
            {
                // Instanciamos el formulario de login y lo mostramos
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Cerramos el panel de administrador actual
                this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                // Ocultamos temporalmente el panel de administrador
                this.Hide();

                // Le pasamos un nuevo LoginForm() para satisfacer el parámetro que exige su constructor
                RegistrationForm regForm = new RegistrationForm(new LoginForm());

                // ShowDialog hace que el programa espere a que cierren la ventana de registro
                regForm.ShowDialog();

                // Cuando cierran el registro y regresan, volvemos a mostrar el AdminForm
                this.Show();

                // Actualizamos los ComboBox por si el nuevo usuario registrado fue un mecánico
                CargarComboBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el módulo de registro: " + ex.Message);
                this.Show(); // Asegurarnos de mostrar el form si ocurre algo
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }
        private void label11_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

    }
}