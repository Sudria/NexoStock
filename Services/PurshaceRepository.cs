using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NexoStock.Services
{
    internal class PurchaseRepository
    {
        private readonly ConnectionDB connectionDB = new ConnectionDB();

        public List<PurchaseClass> GetAllPurchases()
        {
            List<PurchaseClass> purchases = new List<PurchaseClass>();

            string query = @"
        SELECT
            p.Id,
            p.ProviderId,
            p.UserId,
            p.PurchaseDate,
            p.Total,
            CONCAT(pr.Name, ' ', pr.Surname) AS ProviderName,
            COALESCE(SUM(pd.Quantity), 0) AS TotalProducts
        FROM purchases p
        INNER JOIN providers pr ON p.ProviderId = pr.Id
        LEFT JOIN purchase_details pd ON p.Id = pd.PurchaseId
        GROUP BY
            p.Id,
            p.ProviderId,
            p.UserId,
            p.PurchaseDate,
            p.Total,
            pr.Name,
            pr.Surname
        ORDER BY p.PurchaseDate DESC;
    ";

            using (var reader = connectionDB.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    PurchaseClass purchase = new PurchaseClass
                    {
                        Id = reader.GetInt32("Id"),
                        ProviderId = reader.GetInt32("ProviderId"),
                        UserId = reader.GetInt32("UserId"),
                        PurchaseDate = reader.GetDateTime("PurchaseDate"),
                        Total = reader.GetDecimal("Total"),
                        ProviderName = reader.GetString("ProviderName"),
                        TotalProducts = reader.GetInt32("TotalProducts")
                    };

                    purchases.Add(purchase);
                }
            }

            return purchases;
        }

        public DataTable GetPurchaseDetailsTable(int purchaseId)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            pd.Id AS 'ID',
            pd.PurchaseId AS 'N° Compra',
            p.Name AS 'Producto',
            p.Cod AS 'Código',
            pd.Quantity AS 'Cantidad',
            pd.PurchasePrice AS 'Precio de Compra',
            pd.Subtotal AS 'Subtotal'
        FROM purchase_details pd
        INNER JOIN products p ON pd.ProductId = p.Id
        WHERE pd.PurchaseId = @PurchaseId
        ORDER BY pd.Id;
    ";

            try
            {
                using (MySqlDataReader reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@PurchaseId", purchaseId)))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al obtener los detalles de la compra: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return table;
        }

        public decimal GetPurchaseTotal(int purchaseId)
        {
            string query = @"
        SELECT Total
        FROM purchases
        WHERE Id = @PurchaseId;
    ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@PurchaseId", purchaseId)))
                {
                    if (reader.Read())
                        return reader.GetDecimal("Total");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al obtener el total de la compra: " + ex.Message
                );
            }

            return 0;
        }

        public DataTable GetPurchaseHeader(int purchaseId)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            p.PurchaseDate AS Fecha,
            CONCAT(pr.Name, ' ', pr.Surname) AS Proveedor
        FROM purchases p
        INNER JOIN providers pr ON p.ProviderId = pr.Id
        WHERE p.Id = @PurchaseId;
    ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@PurchaseId", purchaseId)))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al obtener los datos de la compra: " + ex.Message
                );
            }

            return table;
        }
    }
}