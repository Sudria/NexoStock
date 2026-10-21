using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NexoStock.Services
{
    public class ProductRepository
    {
        private readonly ConnectionDB connectionDB;

        public ProductRepository()
        {
            connectionDB = new ConnectionDB();
        }

        // CREAR PRODUCTO
        public bool CreateProduct(ProductClass product)
        {
            string query = @"
                INSERT INTO products
                    (Name, Cod, Description, SalePrice, Stock, StockMin, State, BrandId, CategoryId, ProviderId)
                VALUES
                    (@name, @cod, @description, @salePrice, @stock, @stockMin, @state, @brandId, @categoryId, @providerId);
            ";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@name", product.Name),
                    new MySqlParameter("@cod", product.Cod),
                    new MySqlParameter("@description", product.Description),
                    new MySqlParameter("@salePrice", product.SalePrice),
                    new MySqlParameter("@stock", product.Stock),
                    new MySqlParameter("@stockMin", product.StockMin),
                    new MySqlParameter("@state", product.State),
                    new MySqlParameter("@brandId", product.BrandId),
                    new MySqlParameter("@categoryId", product.CategoryId),
                    new MySqlParameter("@providerId", product.ProviderId)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                string mensajeError = "No se pudo registrar el producto porque un dato ya existe.";
                string mensajeMySQL = ex.Message.ToLower();

                if (mensajeMySQL.Contains("cod"))
                {
                    mensajeError = $"El código '{product.Cod}' ya está registrado.";
                }

                MessageBox.Show(
                    mensajeError,
                    "Dato Duplicado",
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


        // OBTENER TODOS LOS PRODUCTOS
        public List<ProductClass> GetAllProducts()
        {
            List<ProductClass> products = new List<ProductClass>();

            // 1. Cambiamos a LEFT JOIN para que traiga TODOS los productos siempre
            string query = @"
        SELECT 
            p.Id, p.Name, p.Cod, p.Description, p.SalePrice, p.Stock, p.StockMin, p.State,
            p.BrandId, b.Name AS Brand,
            p.CategoryId, c.Name AS Category,
            p.ProviderId, pr.Name AS Provider
        FROM products p
        LEFT JOIN brands b ON p.BrandId = b.Id
        LEFT JOIN categorys c ON p.CategoryId = c.Id
        LEFT JOIN providers pr ON p.ProviderId = pr.Id;
    ";

            using (var reader = connectionDB.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    ProductClass product = new ProductClass
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Cod = reader.GetString("Cod"),
                        // IsDBNull protege tu código si Description es opcional en la BD
                        Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString("Description"),
                        SalePrice = reader.GetDecimal("SalePrice"),
                        Stock = reader.GetInt32("Stock"),
                        StockMin = reader.GetInt32("StockMin"),
                        State = reader.GetBoolean("State"),

                        // IDs (si permiten nulos en tu BD, usa IsDBNull para evitar caídas)
                        BrandId = reader.IsDBNull(reader.GetOrdinal("BrandId")) ? 0 : reader.GetInt32("BrandId"),
                        CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) ? 0 : reader.GetInt32("CategoryId"),
                        ProviderId = reader.IsDBNull(reader.GetOrdinal("ProviderId")) ? 0 : reader.GetInt32("ProviderId"),

                        // Nombres obtenidos por LEFT JOIN (pueden venir NULL si el ID no existía)
                        Brand = reader.IsDBNull(reader.GetOrdinal("Brand")) ? "Sin Marca" : reader.GetString("Brand"),
                        Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? "Sin Categoría" : reader.GetString("Category"),
                        Provider = reader.IsDBNull(reader.GetOrdinal("Provider")) ? "Sin Proveedor" : reader.GetString("Provider")
                    };

                    products.Add(product);
                }
            }

            return products;
        }


        // ACTUALIZAR PRODUCTO
        public bool UpdateProduct(ProductClass product)
        {
            string query = @"
                UPDATE products
                SET
                    Name = @name,
                    Cod = @cod,
                    Description = @description,
                    SalePrice = @salePrice,
                    Stock = @stock,
                    StockMin = @stockMin,
                    State = @state,
                    BrandId = @brandId,
                    CategoryId = @categoryId,
                    ProviderId = @providerId
                WHERE Id = @id;
            ";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@name", product.Name),
                    new MySqlParameter("@cod", product.Cod),
                    new MySqlParameter("@description", product.Description),
                    new MySqlParameter("@salePrice", product.SalePrice),
                    new MySqlParameter("@stock", product.Stock),
                    new MySqlParameter("@stockMin", product.StockMin),
                    new MySqlParameter("@state", product.State),
                    new MySqlParameter("@brandId", product.BrandId),
                    new MySqlParameter("@categoryId", product.CategoryId),
                    new MySqlParameter("@providerId", product.ProviderId),
                    new MySqlParameter("@id", product.Id)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                string mensajeError = "No se pudo actualizar el producto porque el código ya existe.";

                MessageBox.Show(
                    mensajeError,
                    "Dato Duplicado",
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


        // ELIMINAR PRODUCTO
        public bool DeleteProduct(int productId)
        {
            string query = "UPDATE products SET State = 0 WHERE Id = @id";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@id", productId)
            );

            return rowsAffected > 0;
        }


        // RESTAURAR PRODUCTO
        public bool RestoreProduct(int productId)
        {
            string query = "UPDATE products SET State = 1 WHERE Id = @id";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@id", productId)
            );

            return rowsAffected > 0;
        }
    }
}