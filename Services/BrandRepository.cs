using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NexoStock.Services
{
    public class BrandRepository
    {
        private readonly ConnectionDB connectionDB;

        public BrandRepository()
        {
            connectionDB = new ConnectionDB();
        }

        public bool CreateBrand(BrandClass brand)
        {
            string query = @"
                INSERT INTO brands
                    (Name, State)
                VALUES
                    (@name, @state);";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@name", brand.Name),
                    new MySqlParameter("@state", brand.State)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show(
                    $"La marca '{brand.Name}' ya existe.",
                    "Marca Duplicada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error de Base de Datos: {ex.Message}",
                    "Error Técnico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        public List<BrandClass> GetAllBrands()
        {
            List<BrandClass> brands = new List<BrandClass>();

            string query = "SELECT * FROM brands";

            using (var reader = connectionDB.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    BrandClass brand = new BrandClass
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        State = reader.GetBoolean("State")
                    };

                    brands.Add(brand);
                }
            }

            return brands;
        }

        public bool UpdateBrand(BrandClass brand)
        {
            string query = @"
                UPDATE brands
                SET Name = @name,
                    State = @state
                WHERE Id = @id;";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@name", brand.Name),
                new MySqlParameter("@state", brand.State),
                new MySqlParameter("@id", brand.Id)
            );

            return rowsAffected > 0;
        }

        public bool DeleteBrand(int brandId)
        {
            string query = "UPDATE brands SET State = 0 WHERE Id = @id";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@id", brandId)
            );

            return rowsAffected > 0;
        }

        public bool RestoreBrand(int brandId)
        {
            string query = "UPDATE brands SET State = 1 WHERE Id = @id";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@id", brandId)
            );

            return rowsAffected > 0;
        }
    }
}