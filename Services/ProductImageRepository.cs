using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;

namespace NexoStock.Services
{
    internal class ProductImageRepository
    {
        private readonly ConnectionDB connectionDB = new ConnectionDB();

        // Obtener todas las imágenes de un producto
        public List<ProductImageClass> GetImagesByProductId(int productId)
        {
            List<ProductImageClass> images = new List<ProductImageClass>();

            string query = @"
                SELECT Id, ProductId, ImagePath
                FROM product_images
                WHERE ProductId = @ProductId
                ORDER BY Id ASC;
            ";

            using (var reader = connectionDB.ExecuteReader(
                query,
                new MySqlParameter("@ProductId", productId)))
            {
                while (reader.Read())
                {
                    ProductImageClass image = new ProductImageClass
                    {
                        Id = reader.GetInt32("Id"),
                        ProductId = reader.GetInt32("ProductId"),
                        ImagePath = reader.GetString("ImagePath")
                    };

                    images.Add(image);
                }
            }

            return images;
        }

        // Guardar una imagen si el producto tiene menos de 3
        public bool AddImage(ProductImageClass image)
        {
            if (GetImageCount(image.ProductId) >= 3)
                return false;

            string query = @"
                INSERT INTO product_images (ProductId, ImagePath)
                VALUES (@ProductId, @ImagePath);
            ";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@ProductId", image.ProductId),
                new MySqlParameter("@ImagePath", image.ImagePath)
            );

            return rowsAffected > 0;
        }

        // Obtener la cantidad de imágenes de un producto
        public int GetImageCount(int productId)
        {
            string query = @"
                SELECT COUNT(*)
                FROM product_images
                WHERE ProductId = @ProductId;
            ";

            using (var reader = connectionDB.ExecuteReader(
                query,
                new MySqlParameter("@ProductId", productId)))
            {
                if (reader.Read())
                    return Convert.ToInt32(reader[0]);
            }

            return 0;
        }

        // Eliminar una imagen por su ID
        public bool DeleteImage(int imageId)
        {
            string query = @"
                DELETE FROM product_images
                WHERE Id = @Id;
            ";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@Id", imageId)
            );

            return rowsAffected > 0;
        }

        // Eliminar todas las imágenes de un producto
        public bool DeleteImagesByProductId(int productId)
        {
            string query = @"
                DELETE FROM product_images
                WHERE ProductId = @ProductId;
            ";

            connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@ProductId", productId)
            );

            return true;
        }
    }
}