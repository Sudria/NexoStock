using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NexoStock.Services
{
    public class ProviderRepository
    {
        private readonly ConnectionDB connectionDB;

        public ProviderRepository()
        {
            connectionDB = new ConnectionDB();
        }

        public bool CreateProvider(ProviderClass provider)
        {
            string query = @"
                INSERT INTO providers
                    (Name, Surname, Cuit, Email, Tel, State, CreatedDate)
                VALUES
                    (@name, @surname, @cuit, @email, @tel, @state, @createdDate);";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@name", provider.Name),
                    new MySqlParameter("@surname", provider.Surname),
                    new MySqlParameter("@cuit", provider.Cuit),
                    new MySqlParameter("@email", provider.Email),
                    new MySqlParameter("@tel", provider.Tel),
                    new MySqlParameter("@state", provider.State),
                    new MySqlParameter("@createdDate", provider.CreatedDate)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                string mensajeError = "No se pudo registrar el proveedor porque un dato ya existe.";
                string mensajeMySQL = ex.Message.ToLower();

                if (mensajeMySQL.Contains("cuit"))
                {
                    mensajeError = $"El CUIT '{provider.Cuit}' ya está registrado.";
                }
                else if (mensajeMySQL.Contains("email"))
                {
                    mensajeError = $"El correo electrónico '{provider.Email}' ya está siendo utilizado.";
                }
                else if (mensajeMySQL.Contains("name"))
                {
                    mensajeError = $"El nombre '{provider.Name}' ya existe.";
                }

                MessageBox.Show(
                    mensajeError,
                    "Datos Duplicados",
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

        public List<ProviderClass> GetAllProviders()
        {
            List<ProviderClass> providers = new List<ProviderClass>();

            string query = "SELECT * FROM providers";

            using (var reader = connectionDB.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    ProviderClass provider = new ProviderClass
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Surname = reader.GetString("Surname"),
                        Cuit = reader.GetString("Cuit"),
                        Email = reader.GetString("Email"),
                        Tel = reader.GetString("Tel"),
                        State = reader.GetBoolean("State"),
                        CreatedDate = reader.GetDateTime("CreatedDate")
                    };

                    providers.Add(provider);
                }
            }

            return providers;
        }

        public bool UpdateProvider(ProviderClass provider)
        {
            string query = @"
                UPDATE providers
                SET Name = @name,
                    Surname = @surname,
                    Cuit = @cuit,
                    Email = @email,
                    Tel = @tel,
                    State = @state
                WHERE Id = @id;";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@name", provider.Name),
                new MySqlParameter("@surname", provider.Surname),
                new MySqlParameter("@cuit", provider.Cuit),
                new MySqlParameter("@email", provider.Email),
                new MySqlParameter("@tel", provider.Tel),
                new MySqlParameter("@state", provider.State),
                new MySqlParameter("@id", provider.Id)
            );

            return rowsAffected > 0;
        }

        public bool DeleteProvider(int providerId)
        {
            string query = "UPDATE providers SET State = 0 WHERE Id = @id";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@id", providerId)
            );

            return rowsAffected > 0;
        }

        public bool RestoreProvider(int providerId)
        {
            string query = "UPDATE providers SET State = 1 WHERE Id = @id";

            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@id", providerId)
            );

            return rowsAffected > 0;
        }
    }
}