using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NexoStock.Services
{
    public class CategoryRepository
    {
        private readonly ConnectionDB connectionDB;

        public CategoryRepository()
        {
            connectionDB = new ConnectionDB();
        }

        public bool CreateCategory(CategoryClass category)
        {
            string query = @"
                INSERT INTO categorys
                    (Name, State)
                VALUES
                    (@name, @state);";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@name", category.Name),
                    new MySqlParameter("@state", category.State)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show(
                    $"La categoría '{category.Name}' ya existe.",
                    "Categoría Duplicada",
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

        public List<CategoryClass> GetAllCategories()
        {
            List<CategoryClass> categories = new List<CategoryClass>();

            string query = "SELECT * FROM categorys";

            using (var reader = connectionDB.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    CategoryClass category = new CategoryClass
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        State = reader.GetBoolean("State")
                    };

                    categories.Add(category);
                }
            }

            return categories;
        }

        public bool UpdateCategory(CategoryClass category)
        {
            string query = @"
                UPDATE categorys
                SET Name = @name,
                    State = @state
                WHERE Id = @id;";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@name", category.Name),
                new MySqlParameter("@state", category.State),
                new MySqlParameter("@id", category.Id)
            );

            return rowsAffected > 0;
        }

        public bool DeleteCategory(int categoryId)
        {
            string query = "UPDATE categorys SET State = 0 WHERE Id = @id";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@id", categoryId)
            );

            return rowsAffected > 0;
        }

        public bool RestoreCategory(int categoryId)
        {
            string query = "UPDATE categorys SET State = 1 WHERE Id = @id";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@id", categoryId)
            );

            return rowsAffected > 0;
        }
    }
}