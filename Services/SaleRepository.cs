
using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Data;
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
        public bool CreateSale(SaleClass sale)
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
        public List<SaleClass> GetAllSales()
        {
            List<SaleClass> sales = new List<SaleClass>();

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
                        SaleClass sale = new SaleClass
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
        public SaleClass GetSaleById(int saleId)
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
                        return new SaleClass
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



        public DataTable GetSalesByUserId(int userId)
        {
            DataTable table = new DataTable();

            string query = @"
    SELECT
        s.Id AS 'N° Venta',
        s.SaleDate AS 'Fecha',
        c.Name AS 'Nombre',
        c.Surname AS 'Apellido',
        c.Dni AS 'DNI Cliente',
        s.Total AS 'Total',
        s.ClientId AS ClientId
    FROM sales s
    INNER JOIN clients c ON s.ClientId = c.Id
    WHERE s.UserId = @UserId
    ORDER BY s.SaleDate DESC;
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
                    "Error al cargar las ventas: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return table;
        }


        public int GetTotalSalesByUserId(int userId)
        {
            string query = @"
        SELECT COUNT(*)
        FROM sales
        WHERE UserId = @UserId;
    ";

            try
            {
                using (MySqlDataReader reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@UserId", userId)))
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al contar las ventas: " + ex.Message);
            }

            return 0;
        }


        public DataTable GetSalesByCategoryAndUser(int userId)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            c.Name AS Categoria,
            SUM(sd.Quantity) AS CantidadVendida
        FROM sales s
        INNER JOIN sale_details sd ON sd.SaleId = s.Id
        INNER JOIN products p ON p.Id = sd.ProductId
        INNER JOIN categorys c ON c.Id = p.CategoryId
        WHERE s.UserId = @UserId
        GROUP BY c.Id, c.Name
        ORDER BY CantidadVendida DESC;
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
                    "Error al obtener las categorías más vendidas: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return table;
        }

        public DataTable GetSalesByDayAndUser(int userId)
        {
            DataTable table = new DataTable();

            string query = @"
        WITH RECURSIVE calendario AS
        (
            SELECT DATE_FORMAT(CURDATE(), '%Y-%m-01') AS Fecha

            UNION ALL

            SELECT DATE_ADD(Fecha, INTERVAL 1 DAY)
            FROM calendario
            WHERE Fecha < LAST_DAY(CURDATE())
        )
        SELECT
            calendario.Fecha,
            COALESCE(SUM(s.Total), 0) AS TotalVendido
        FROM calendario
        LEFT JOIN sales s
            ON DATE(s.SaleDate) = calendario.Fecha
            AND s.UserId = @UserId
        GROUP BY calendario.Fecha
        ORDER BY calendario.Fecha;
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
                    "Error al obtener las ventas por día: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return table;
        }


        public DataTable GetLast5SalesByUserId(int userId)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            s.Id AS 'N° Venta',
            CONCAT(c.Name, ' ', c.Surname) AS 'Cliente',
            s.Total AS 'Importe'
        FROM sales s
        INNER JOIN clients c ON c.Id = s.ClientId
        WHERE s.UserId = @UserId
        ORDER BY s.SaleDate DESC, s.Id DESC
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
                    "Error al obtener las últimas ventas: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return table;
        }


        public DataTable GetSalesByCategory()
        {
            DataTable data = new DataTable();

            string query = @"
        SELECT 
            c.Name AS Categoria,
            SUM(sd.Quantity) AS CantidadVendida
        FROM sale_details sd
        INNER JOIN sales s ON s.Id = sd.SaleId
        INNER JOIN products p ON p.Id = sd.ProductId
        INNER JOIN categorys c ON c.Id = p.CategoryId
        WHERE s.State = 1
        GROUP BY c.Id, c.Name
        ORDER BY CantidadVendida DESC;";

            try
            {
                using (var reader = connectionDB.ExecuteReader(query))
                {
                    data.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al obtener las categorías más vendidas:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return data;
        }


        public DataTable GetTopSellersOfCurrentMonth()
        {
            DataTable data = new DataTable();

            string query = @"
        SELECT 
            CONCAT(u.Name, ' ', u.Surname) AS Nombre,
            SUM(s.Total) AS TotalVendido
        FROM sales s
        INNER JOIN users u ON s.UserId = u.Id
        WHERE 
            s.State = 1
            AND YEAR(s.SaleDate) = YEAR(CURRENT_DATE())
            AND MONTH(s.SaleDate) = MONTH(CURRENT_DATE())
        GROUP BY 
            s.UserId, u.Name, u.Surname
        ORDER BY 
            TotalVendido DESC
        LIMIT 5;";

            try
            {
                using (var reader = connectionDB.ExecuteReader(query))
                {
                    data.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al obtener los mejores vendedores:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return data;
        }

        public DataTable GetTopSellingProductsOfCurrentMonth()
        {
            DataTable data = new DataTable();

            string query = @"
        SELECT
            p.Name AS Producto,
            SUM(sd.Quantity) AS CantidadVendida
        FROM sale_details sd
        INNER JOIN sales s ON sd.SaleId = s.Id
        INNER JOIN products p ON sd.ProductId = p.Id
        WHERE
            s.State = 1
            AND YEAR(s.SaleDate) = YEAR(CURRENT_DATE())
            AND MONTH(s.SaleDate) = MONTH(CURRENT_DATE())
        GROUP BY
            p.Id, p.Name
        ORDER BY
            CantidadVendida DESC
        LIMIT 5;";

            try
            {
                using (var reader = connectionDB.ExecuteReader(query))
                {
                    data.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al obtener los productos más vendidos:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return data;
        }


        public bool CreateCompleteSale(SaleClass sale, List<SaleDetailClass> details, out int saleId)
        {
            saleId = 0;

            if (sale == null || details == null || details.Count == 0)
            {
                MessageBox.Show("La venta debe tener al menos un producto.");
                return false;
            }

            using (MySqlConnection connection = connectionDB.GetConnection())
            using (MySqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    // 1. Registrar la venta
                    string saleQuery = @"
                INSERT INTO sales (UserId, ClientId, Total)
                VALUES (@UserId, @ClientId, @Total);
            ";

                    using (MySqlCommand command =
                        new MySqlCommand(saleQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@UserId", sale.UserId);
                        command.Parameters.AddWithValue("@ClientId", sale.ClientId);
                        command.Parameters.AddWithValue("@Total", sale.Total);

                        command.ExecuteNonQuery();
                        saleId = Convert.ToInt32(command.LastInsertedId);
                    }

                    // 2. Registrar los detalles de venta
                    // El trigger de MySQL se encarga de descontar el stock.
                    foreach (SaleDetailClass detail in details)
                    {
                        if (detail.Quantity <= 0 || detail.UnitPrice < 0)
                        {
                            throw new Exception("La cantidad o el precio no son válidos.");
                        }

                        string detailQuery = @"
                    INSERT INTO sale_details
                        (SaleId, ProductId, Quantity, UnitPrice)
                    VALUES
                        (@SaleId, @ProductId, @Quantity, @UnitPrice);
                ";

                        using (MySqlCommand command =
                            new MySqlCommand(detailQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@SaleId", saleId);
                            command.Parameters.AddWithValue("@ProductId", detail.ProductId);
                            command.Parameters.AddWithValue("@Quantity", detail.Quantity);
                            command.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);

                            command.ExecuteNonQuery();
                        }
                    }

                    // 3. Confirmar transacción
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {
                        // La transacción pudo haberse cerrado por un error de conexión.
                    }

                    saleId = 0;

                    MessageBox.Show(
                        "No se pudo registrar la venta: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }
            }
        }


        public DataTable GetAllSalesWithClients()
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            s.Id AS 'N° Venta',
            s.SaleDate AS 'Fecha',
            CONCAT(c.Name, ' ', c.Surname) AS 'Cliente',
            c.Dni AS 'DNI Cliente',
            u.Username AS 'Vendedor',
            s.Total AS 'Total',
            s.ClientId AS ClientId,
            s.UserId AS UserId
        FROM sales s
        INNER JOIN clients c ON s.ClientId = c.Id
        INNER JOIN users u ON s.UserId = u.Id
        ORDER BY s.SaleDate DESC;
    ";

            try
            {
                using (MySqlDataReader reader = connectionDB.ExecuteReader(query))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al cargar las ventas: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return table;
        }

        public DataTable GetTopSellingProducts(DateTime dateFrom, DateTime dateTo)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            p.Id AS Id,
            p.Name AS Producto,
            p.Cod AS Codigo,
            SUM(sd.Quantity) AS CantidadVendida,
            SUM(sd.Quantity * sd.UnitPrice) AS TotalFacturado
        FROM sale_details sd
        INNER JOIN sales s ON sd.SaleId = s.Id
        INNER JOIN products p ON sd.ProductId = p.Id
        WHERE s.State = 1
          AND s.SaleDate >= @DateFrom
          AND s.SaleDate < @DateTo
        GROUP BY p.Id, p.Name, p.Cod
        ORDER BY CantidadVendida DESC
        LIMIT 10;
    ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@DateFrom", dateFrom.Date),
                    new MySqlParameter("@DateTo", dateTo.Date.AddDays(1))))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener los productos más vendidos: " + ex.Message);
            }

            return table;
        }

        public DataTable GetTopSellingCategories(DateTime dateFrom, DateTime dateTo)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            c.Id AS Id,
            c.Name AS Categoria,
            SUM(sd.Quantity) AS CantidadVendida,
            SUM(sd.Quantity * sd.UnitPrice) AS TotalFacturado
        FROM sale_details sd
        INNER JOIN sales s ON sd.SaleId = s.Id
        INNER JOIN products p ON sd.ProductId = p.Id
        INNER JOIN categorys c ON p.CategoryId = c.Id
        WHERE s.State = 1
          AND s.SaleDate >= @DateFrom
          AND s.SaleDate < @DateTo
        GROUP BY c.Id, c.Name
        ORDER BY CantidadVendida DESC;
    ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@DateFrom", dateFrom.Date),
                    new MySqlParameter("@DateTo", dateTo.Date.AddDays(1))))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener las categorías más vendidas: " + ex.Message);
            }

            return table;
        }

        public DataTable GetBestSellers(DateTime dateFrom, DateTime dateTo)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            u.Id AS Id,
            CONCAT(u.Name, ' ', u.Surname) AS Vendedor,
            COUNT(s.Id) AS CantidadVentas,
            SUM(s.Total) AS TotalFacturado
        FROM sales s
        INNER JOIN users u ON s.UserId = u.Id
        WHERE s.State = 1
          AND s.SaleDate >= @DateFrom
          AND s.SaleDate < @DateTo
        GROUP BY u.Id, u.Name, u.Surname
        ORDER BY TotalFacturado DESC
        LIMIT 10;
    ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@DateFrom", dateFrom.Date),
                    new MySqlParameter("@DateTo", dateTo.Date.AddDays(1))))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener los mejores vendedores: " + ex.Message);
            }

            return table;
        }

        public DataTable GetTopSellingBrands(DateTime dateFrom, DateTime dateTo)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            b.Id AS Id,
            b.Name AS Marca,
            SUM(sd.Quantity) AS CantidadVendida,
            SUM(sd.Quantity * sd.UnitPrice) AS TotalFacturado
        FROM sale_details sd
        INNER JOIN sales s ON sd.SaleId = s.Id
        INNER JOIN products p ON sd.ProductId = p.Id
        INNER JOIN brands b ON p.BrandId = b.Id
        WHERE s.State = 1
          AND s.SaleDate >= @DateFrom
          AND s.SaleDate < @DateTo
        GROUP BY b.Id, b.Name
        ORDER BY CantidadVendida DESC
        LIMIT 10;
    ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@DateFrom", dateFrom.Date),
                    new MySqlParameter("@DateTo", dateTo.Date.AddDays(1))))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener las marcas más vendidas: " + ex.Message);
            }

            return table;
        }

        public DataTable GetBestClients(DateTime dateFrom, DateTime dateTo)
        {
            DataTable table = new DataTable();

            string query = @"
        SELECT
            c.Id AS Id,
            CONCAT(c.Name, ' ', c.Surname) AS Cliente,
            c.Dni AS DNI,
            COUNT(s.Id) AS CantidadCompras,
            SUM(s.Total) AS TotalGastado
        FROM sales s
        INNER JOIN clients c ON s.ClientId = c.Id
        WHERE s.State = 1
          AND s.SaleDate >= @DateFrom
          AND s.SaleDate < @DateTo
        GROUP BY c.Id, c.Name, c.Surname, c.Dni
        ORDER BY TotalGastado DESC
        LIMIT 10;
    ";

            try
            {
                using (var reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@DateFrom", dateFrom.Date),
                    new MySqlParameter("@DateTo", dateTo.Date.AddDays(1))))
                {
                    table.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener los mejores clientes: " + ex.Message);
            }

            return table;
        }

        public DataTable GetSalesByPeriod(DateTime dateFrom, DateTime dateTo)
        {
            string query = @"
        SELECT
            DATE(s.SaleDate) AS Fecha,
            COUNT(DISTINCT s.Id) AS CantidadVentas,
            SUM(sd.Quantity) AS UnidadesVendidas,
            SUM(sd.Quantity * sd.UnitPrice) AS TotalFacturado
        FROM sales s
        INNER JOIN sale_details sd ON s.Id = sd.SaleId
        WHERE s.State = 1
          AND s.SaleDate >= @DateFrom
          AND s.SaleDate < @DateTo
        GROUP BY DATE(s.SaleDate)
        ORDER BY Fecha ASC;";

            MySqlParameter[] parameters =
            {
        new MySqlParameter("@DateFrom", dateFrom.Date),
        new MySqlParameter("@DateTo", dateTo.Date.AddDays(1))
    };

            DataTable data = new DataTable();

            using (MySqlDataReader reader = connectionDB.ExecuteReader(query, parameters))
            {
                data.Load(reader);
            }

            return data;
        }
    }
}
