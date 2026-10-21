
using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NexoStock.Services
{
    public class SaleDetailRepository
    {
        private readonly ConnectionDB connectionDB;

        public SaleDetailRepository()
        {
            connectionDB = new ConnectionDB();
        }

        // CREAR DETALLE DE VENTA
        public bool CreateSaleDetail(SaleDetail detail)
        {
            string query = @"
                INSERT INTO sale_details
                    (SaleId, ProductId, Quantity, UnitPrice)
                VALUES
                    (@saleId, @productId, @quantity, @unitPrice);
            ";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@saleId", detail.SaleId),
                    new MySqlParameter("@productId", detail.ProductId),
                    new MySqlParameter("@quantity", detail.Quantity),
                    new MySqlParameter("@unitPrice", detail.UnitPrice)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al registrar el detalle de venta: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }



        public DataTable GetTopSellingProductsByUser(int userId)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            p.Name AS 'Producto',
            SUM(sd.Quantity) AS 'Unidades vendidas'
        FROM sales s
        INNER JOIN sale_details sd ON sd.SaleId = s.Id
        INNER JOIN products p ON p.Id = sd.ProductId
        WHERE s.UserId = @UserId
        GROUP BY p.Id, p.Name
        ORDER BY SUM(sd.Quantity) DESC
        LIMIT 5;
    ";

            try
            {
                using (MySqlDataReader reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@UserId", userId)))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al obtener los productos más vendidos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return table;
        }

        // OBTENER TODOS LOS DETALLES DE UNA VENTA
        public List<SaleDetail> GetDetailsBySaleId(int saleId)
        {
            List<SaleDetail> details = new List<SaleDetail>();

            string query = @"
                SELECT
                    Id,
                    SaleId,
                    ProductId,
                    Quantity,
                    UnitPrice
                FROM sale_details
                WHERE SaleId = @saleId
                ORDER BY Id;
            ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@saleId", saleId)))
                {
                    while (reader.Read())
                    {
                        SaleDetail detail = new SaleDetail
                        {
                            Id = reader.GetInt32("Id"),
                            SaleId = reader.GetInt32("SaleId"),
                            ProductId = reader.GetInt32("ProductId"),
                            Quantity = reader.GetInt32("Quantity"),
                            UnitPrice = reader.GetDecimal("UnitPrice")
                        };

                        details.Add(detail);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al obtener los detalles de la venta: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return details;
        }

        // ELIMINAR DETALLE DE VENTA
        public bool DeleteSaleDetail(int detailId)
        {
            string query = @"
                DELETE FROM sale_details
                WHERE Id = @id;
            ";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@id", detailId)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al eliminar el detalle: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }


        public DataTable GetSaleDetailsTable(int saleId)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            p.Name AS 'Producto',
            sd.Quantity AS 'Cantidad',
            sd.UnitPrice AS 'Precio unitario',
            sd.Subtotal AS 'Subtotal'
        FROM sale_details sd
        INNER JOIN products p ON sd.ProductId = p.Id
        WHERE sd.SaleId = @SaleId
        ORDER BY sd.Id;
    ";

            try
            {
                using (MySqlDataReader reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@SaleId", saleId)))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al cargar los detalles: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return table;
        }
    }
}
