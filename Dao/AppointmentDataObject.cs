using System.Data;
using Microsoft.Data.SqlClient;
using tdsv121_dae_final.Connection;

namespace tdsv121_dae_final.Dao
{
    internal class AppointmentDataObject : DataObject
    {
        public DataTable GetAllAppointmentsAdmin()
        {
            // Consulta adaptada exactamente a los nombres de tus columnas en SQL Server
            string query = @"
                SELECT 
                    a.id AS IdCita,
                    u.username AS MecanicoAsignado,
                    c.firstname AS Cliente,
                    car.plate AS Placa,
                    a.status AS Estado,
                    a.date_time AS FechaHora
                FROM {TableName} a
                INNER JOIN users u ON a.createdByUserId = u.id
                INNER JOIN customers c ON a.customerId = c.id
                INNER JOIN cars car ON a.carId = car.id";

            return dataAccess.ExecuteQuery(query, DataAccess.Tables.APPOINTMENTS);
        }



        public DataTable GetCustomersForCombo()
        {
            // Une el nombre y apellido para mostrarlo bonito en el ComboBox
            string query = "SELECT id, firstname + ' ' + lastname AS fullname FROM {TableName}";
            return dataAccess.ExecuteQuery(query, DataAccess.Tables.CUSTOMERS);
        }

        public DataTable GetCarsForCombo()
        {
            string query = "SELECT id, plate FROM {TableName}";
            return dataAccess.ExecuteQuery(query, DataAccess.Tables.CARS);
        }

        public DataTable GetMechanicsForCombo()
        {
            string query = "SELECT id, username FROM {TableName}";
            return dataAccess.ExecuteQuery(query, DataAccess.Tables.USERS);
        }

        public int InsertAppointment(string status, DateTime dateTime, int customerId, int carId, int createdByUserId)
        {
            string query = @"
                INSERT INTO {TableName} (status, date_time, customerId, carId, createdByUserId)
                VALUES (@status, @dateTime, @customerId, @carId, @createdByUserId)";

            return dataAccess.ExecuteNonQuery(
                query,
                DataAccess.Tables.APPOINTMENTS,
                new SqlParameter("@status", status),
                new SqlParameter("@dateTime", dateTime),
                new SqlParameter("@customerId", customerId),
                new SqlParameter("@carId", carId),
                new SqlParameter("@createdByUserId", createdByUserId)
            );
        }

        public int UpdateAppointmentStatus(int appointmentId, string status)
        {
            string query = @"
        UPDATE {TableName} 
        SET status = @status 
        WHERE id = @id";

            return dataAccess.ExecuteNonQuery(
                query,
                DataAccess.Tables.APPOINTMENTS,
                new SqlParameter("@status", status),
                new SqlParameter("@id", appointmentId)
            );
        }

        public int DeleteAppointment(int appointmentId)
        {
            string query = "DELETE FROM {TableName} WHERE id = @id";

            return dataAccess.ExecuteNonQuery(
                query,
                DataAccess.Tables.APPOINTMENTS,
                new SqlParameter("@id", appointmentId)
            );
        }
    }
}