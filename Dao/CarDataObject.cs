using Microsoft.Data.SqlClient;
using System;
using System.Data;
using tdsv121_dae_final.Connection;

namespace tdsv121_dae_final.Dao
{
    internal class CarDataObject : DataObject
    {
        public DataTable GetAllCars()
        {
            // Opcional: puedes hacer JOIN con customers para mostrar el dueño si gustas, o directo de cars
            string query = "SELECT id, plate AS Placa, car_model AS Modelo, maker AS Marca, customerId AS IdCliente FROM {TableName}";
            return dataAccess.ExecuteQuery(query, DataAccess.Tables.CARS);
        }

        public int InsertCar(string plate, string model, string maker, int customerId)
        {
            string query = @"
                INSERT INTO {TableName} (plate, car_model, maker, customerId)
                VALUES (@plate, @model, @maker, @customerId)";

            return dataAccess.ExecuteNonQuery(
                query,
                DataAccess.Tables.CARS,
                new SqlParameter("@plate", plate),
                new SqlParameter("@model", model),
                new SqlParameter("@maker", maker),
                new SqlParameter("@customerId", customerId)
            );
        }

        public int UpdateCar(int id, string plate, string model, string maker, int customerId)
        {
            string query = @"
        UPDATE {TableName} 
        SET plate = @plate, 
            car_model = @model, 
            maker = @maker, 
            customerId = @customerId 
        WHERE id = @id";

            return dataAccess.ExecuteNonQuery(
                query,
                DataAccess.Tables.CARS,
                new SqlParameter("@id", id),
                new SqlParameter("@plate", plate),
                new SqlParameter("@model", model),
                new SqlParameter("@maker", maker),
                new SqlParameter("@customerId", customerId)
            );
        }


    }
}