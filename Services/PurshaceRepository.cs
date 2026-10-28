using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using NexoStock.Class;
using NexoStock.Utils;

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
    }
}