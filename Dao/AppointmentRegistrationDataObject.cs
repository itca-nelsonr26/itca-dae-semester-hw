using System;
using Microsoft.Data.SqlClient;
using tdsv121_dae_final.Connection;

namespace tdsv121_dae_final.Dao
{
    public class AppointmentRegistrationDataObject
    {
        private readonly DataBaseConnection databaseConnection = new DataBaseConnection();

        public int RegisterAppointment(
            string document,
            string firstName,
            string lastName,
            string phone,
            string email,
            string plate,
            string maker,
            string carModel,
            DateTime appointmentDateTime,
            int createdByUserId)
        {
            ValidateData(document, firstName, lastName, phone, email, plate, maker, carModel, createdByUserId);

            using SqlConnection connection = databaseConnection.GetConnection();
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                int customerId = GetOrCreateCustomer(
                    connection,
                    transaction,
                    document,
                    firstName,
                    lastName,
                    phone,
                    email);

                int carId = GetOrCreateCar(
                    connection,
                    transaction,
                    plate,
                    maker,
                    carModel,
                    customerId);

                const string appointmentQuery = @"
                    INSERT INTO appointments (status, date_time, customerId, carId, createdByUserId)
                    VALUES (@status, @dateTime, @customerId, @carId, @createdByUserId);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using SqlCommand appointmentCommand = new SqlCommand(appointmentQuery, connection, transaction);
                appointmentCommand.Parameters.AddWithValue("@status", "Activa");
                appointmentCommand.Parameters.AddWithValue("@dateTime", appointmentDateTime);
                appointmentCommand.Parameters.AddWithValue("@customerId", customerId);
                appointmentCommand.Parameters.AddWithValue("@carId", carId);
                appointmentCommand.Parameters.AddWithValue("@createdByUserId", createdByUserId);

                int appointmentId = Convert.ToInt32(appointmentCommand.ExecuteScalar());
                transaction.Commit();
                return appointmentId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private int GetOrCreateCustomer(
            SqlConnection connection,
            SqlTransaction transaction,
            string document,
            string firstName,
            string lastName,
            string phone,
            string email)
        {
            const string searchQuery = "SELECT id FROM customers WHERE document = @document";

            using SqlCommand searchCommand = new SqlCommand(searchQuery, connection, transaction);
            searchCommand.Parameters.AddWithValue("@document", document);
            object? result = searchCommand.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }

            const string insertQuery = @"
                INSERT INTO customers (document, firstname, lastname, phone, email)
                VALUES (@document, @firstName, @lastName, @phone, @email);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
            insertCommand.Parameters.AddWithValue("@document", document);
            insertCommand.Parameters.AddWithValue("@firstName", firstName);
            insertCommand.Parameters.AddWithValue("@lastName", lastName);
            insertCommand.Parameters.AddWithValue("@phone", phone);
            insertCommand.Parameters.AddWithValue("@email", email);

            return Convert.ToInt32(insertCommand.ExecuteScalar());
        }

        private int GetOrCreateCar(
            SqlConnection connection,
            SqlTransaction transaction,
            string plate,
            string maker,
            string carModel,
            int customerId)
        {
            const string searchQuery = "SELECT id, customerId FROM cars WHERE plate = @plate";

            using SqlCommand searchCommand = new SqlCommand(searchQuery, connection, transaction);
            searchCommand.Parameters.AddWithValue("@plate", plate);

            using SqlDataReader reader = searchCommand.ExecuteReader();

            if (reader.Read())
            {
                int existingCarId = reader.GetInt32(0);
                int existingCustomerId = reader.GetInt32(1);
                reader.Close();

                if (existingCustomerId != customerId)
                {
                    throw new InvalidOperationException("La placa ya está registrada a nombre de otro cliente.");
                }

                return existingCarId;
            }

            reader.Close();

            const string insertQuery = @"
                INSERT INTO cars (plate, car_model, maker, customerId)
                VALUES (@plate, @carModel, @maker, @customerId);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
            insertCommand.Parameters.AddWithValue("@plate", plate);
            insertCommand.Parameters.AddWithValue("@carModel", carModel);
            insertCommand.Parameters.AddWithValue("@maker", maker);
            insertCommand.Parameters.AddWithValue("@customerId", customerId);

            return Convert.ToInt32(insertCommand.ExecuteScalar());
        }

        private void ValidateData(
            string document,
            string firstName,
            string lastName,
            string phone,
            string email,
            string plate,
            string maker,
            string carModel,
            int createdByUserId)
        {
            if (string.IsNullOrWhiteSpace(document) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(plate) ||
                string.IsNullOrWhiteSpace(maker) ||
                string.IsNullOrWhiteSpace(carModel))
            {
                throw new ArgumentException("Completa todos los campos antes de registrar la cita.");
            }

            if (phone.Length > 8)
            {
                throw new ArgumentException("El teléfono debe tener como máximo 8 caracteres.");
            }

            if (createdByUserId <= 0)
            {
                throw new ArgumentException("No se pudo identificar al usuario que registra la cita.");
            }
        }
    }
}
