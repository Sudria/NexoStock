
using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NexoStock.Services
{
    public class ProductMovementRepository
    {
        private readonly ConnectionDB connectionDB;

        public ProductMovementRepository()
        {
            connectionDB = new ConnectionDB();
        }

        // REGISTRAR MOVIMIENTO
        public bool CreateMovement(ProductMovementClass movement)
        {
            string query = @"
                INSERT INTO product_movements
                    (UserId, Type, ReferenceId, MovementDate)
                VALUES
                    (@userId, @type, @referenceId, @movementDate);
            ";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@userId", movement.UserId),
                    new MySqlParameter("@type", movement.Type),
                    new MySqlParameter("@referenceId", movement.ReferenceId),
                    new MySqlParameter("@movementDate", movement.MovementDate)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al registrar el movimiento: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        // OBTENER TODOS LOS MOVIMIENTOS
        public List<ProductMovementClass> GetAllMovements()
        {
            List<ProductMovementClass> movements =
                new List<ProductMovementClass>();

            string query = @"
                SELECT
                    Id,
                    UserId,
                    Type,
                    ReferenceId,
                    MovementDate
                FROM product_movements
                ORDER BY MovementDate DESC;
            ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        ProductMovementClass movement =
                            new ProductMovementClass
                            {
                                Id = reader.GetInt32("Id"),
                                UserId = reader.GetInt32("UserId"),
                                Type = reader.GetString("Type"),
                                ReferenceId = reader.GetInt32("ReferenceId"),
                                MovementDate = reader.GetDateTime("MovementDate")
                            };

                        movements.Add(movement);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al obtener los movimientos: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return movements;
        }

        // OBTENER MOVIMIENTOS POR USUARIO
        public List<ProductMovementClass> GetMovementsByUser(int userId)
        {
            List<ProductMovementClass> movements =
                new List<ProductMovementClass>();

            string query = @"
                SELECT
                    Id,
                    UserId,
                    Type,
                    ReferenceId,
                    MovementDate
                FROM product_movements
                WHERE UserId = @userId
                ORDER BY MovementDate DESC;
            ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@userId", userId)))
                {
                    while (reader.Read())
                    {
                        movements.Add(new ProductMovementClass
                        {
                            Id = reader.GetInt32("Id"),
                            UserId = reader.GetInt32("UserId"),
                            Type = reader.GetString("Type"),
                            ReferenceId = reader.GetInt32("ReferenceId"),
                            MovementDate = reader.GetDateTime("MovementDate")
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al consultar los movimientos: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return movements;
        }

        // OBTENER MOVIMIENTOS POR TIPO
        public List<ProductMovementClass> GetMovementsByType(string type)
        {
            List<ProductMovementClass> movements =
                new List<ProductMovementClass>();

            string query = @"
                SELECT
                    Id,
                    UserId,
                    Type,
                    ReferenceId,
                    MovementDate
                FROM product_movements
                WHERE Type = @type
                ORDER BY MovementDate DESC;
            ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@type", type)))
                {
                    while (reader.Read())
                    {
                        movements.Add(new ProductMovementClass
                        {
                            Id = reader.GetInt32("Id"),
                            UserId = reader.GetInt32("UserId"),
                            Type = reader.GetString("Type"),
                            ReferenceId = reader.GetInt32("ReferenceId"),
                            MovementDate = reader.GetDateTime("MovementDate")
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al consultar los movimientos: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return movements;
        }
    }
}
