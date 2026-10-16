
using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NexoStock.Services
{
    public class SaleRepository
    {
        private readonly ConnectionDB connectionDB;

        public SaleRepository()
        {
            connectionDB = new ConnectionDB();
        }

        // CREAR VENTA
        public bool CreateSale(Sale sale)
        {
            string query = @"
                INSERT INTO sales (UserId, Total, State)
                VALUES (@userId, @total, @state);
            ";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@userId", sale.UserId),
                    new MySqlParameter("@total", sale.Total),
                    new MySqlParameter("@state", sale.State)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al registrar la venta: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        // OBTENER TODAS LAS VENTAS
        public List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();

            string query = @"
                SELECT
                    Id,
                    UserId,
                    SaleDate,
                    Total,
                    State
                FROM sales
                ORDER BY SaleDate DESC;
            ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        Sale sale = new Sale
                        {
                            Id = reader.GetInt32("Id"),
                            UserId = reader.GetInt32("UserId"),
                            SaleDate = reader.GetDateTime("SaleDate"),
                            Total = reader.GetDecimal("Total"),
                            State = reader.GetBoolean("State")
                        };

                        sales.Add(sale);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al obtener las ventas: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return sales;
        }

        // OBTENER VENTA POR ID
        public Sale GetSaleById(int saleId)
        {
            string query = @"
                SELECT
                    Id,
                    UserId,
                    SaleDate,
                    Total,
                    State
                FROM sales
                WHERE Id = @id;
            ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@id", saleId)))
                {
                    if (reader.Read())
                    {
                        return new Sale
                        {
                            Id = reader.GetInt32("Id"),
                            UserId = reader.GetInt32("UserId"),
                            SaleDate = reader.GetDateTime("SaleDate"),
                            Total = reader.GetDecimal("Total"),
                            State = reader.GetBoolean("State")
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al buscar la venta: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return null;
        }

        // CAMBIAR ESTADO DE LA VENTA
        public bool UpdateSaleState(int saleId, bool state)
        {
            string query = @"
                UPDATE sales
                SET State = @state
                WHERE Id = @id;
            ";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@state", state),
                    new MySqlParameter("@id", saleId)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al actualizar la venta: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }
    }
}
