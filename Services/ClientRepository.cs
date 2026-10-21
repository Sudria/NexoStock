
using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NexoStock.Services
{
    public class ClientRepository
    {
        private readonly ConnectionDB connectionDB = new ConnectionDB();

        // Crear cliente
        public bool CreateClient(ClientClass client)
        {
            string query = @"
                INSERT INTO clients
                (Name, Surname, Dni, Email, Tel, State)
                VALUES
                (@Name, @Surname, @Dni, @Email, @Tel, @State);";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@Name", client.Name),
                    new MySqlParameter("@Surname", client.Surname),
                    new MySqlParameter("@Dni", client.Dni),
                    new MySqlParameter("@Email", client.Email),
                    new MySqlParameter("@Tel", client.Tel),
                    new MySqlParameter("@State", client.State)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al crear el cliente: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        // Obtener todos los clientes
        public List<ClientClass> GetAllClients()
        {
            List<ClientClass> clients = new List<ClientClass>();

            string query = @"
                SELECT Id, Name, Surname, Dni, Email, Tel, State, CreatedDate
                FROM clients
                ORDER BY Id DESC;";

            try
            {
                using (MySqlDataReader reader = connectionDB.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        clients.Add(new ClientClass
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Dni = reader["Dni"].ToString(),
                            Email = reader["Email"].ToString(),
                            Tel = reader["Tel"].ToString(),
                            State = Convert.ToBoolean(reader["State"]),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al obtener los clientes: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return clients;
        }

        // Obtener cliente por ID
        public ClientClass GetClientById(int id)
        {
            string query = @"
                SELECT Id, Name, Surname, Dni, Email, Tel, State, CreatedDate
                FROM clients
                WHERE Id = @Id;";

            try
            {
                using (MySqlDataReader reader = connectionDB.ExecuteReader(
                    query,
                    new MySqlParameter("@Id", id)))
                {
                    if (reader.Read())
                    {
                        return new ClientClass
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Dni = reader["Dni"].ToString(),
                            Email = reader["Email"].ToString(),
                            Tel = reader["Tel"].ToString(),
                            State = Convert.ToBoolean(reader["State"]),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al obtener el cliente: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return null;
        }

        // Actualizar cliente
        public bool UpdateClient(ClientClass client)
        {
            string query = @"
                UPDATE clients
                SET Name = @Name,
                    Surname = @Surname,
                    Dni = @Dni,
                    Email = @Email,
                    Tel = @Tel,
                    State = @State
                WHERE Id = @Id;";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@Name", client.Name),
                    new MySqlParameter("@Surname", client.Surname),
                    new MySqlParameter("@Dni", client.Dni),
                    new MySqlParameter("@Email", client.Email),
                    new MySqlParameter("@Tel", client.Tel),
                    new MySqlParameter("@Id", client.Id),
                    new MySqlParameter("@State", client.State)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al actualizar el cliente: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        // Eliminar lógicamente
        public bool DeleteClient(int id)
        {
            string query = @"
                UPDATE clients
                SET State = 0
                WHERE Id = @Id AND State = 1;";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@Id", id)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al eliminar el cliente: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        // Restaurar cliente
        public bool RestoreClient(int id)
        {
            string query = @"
                UPDATE clients
                SET State = 1
                WHERE Id = @Id AND State = 0;";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@Id", id)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al restaurar el cliente: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        public List<ClientClass> GetActiveClients()
        {
            List<ClientClass> clients = new List<ClientClass>();

            string query = @"
        SELECT Id, Name, Surname, Dni, Email, Tel, State
        FROM clients
        WHERE State = 1
        ORDER BY Surname, Name;
    ";

            try
            {
                using (MySqlDataReader reader = connectionDB.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        clients.Add(new ClientClass
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Surname = reader.GetString("Surname"),
                            Dni = reader.GetString("Dni"),
                            Email = reader.GetString("Email"),
                            Tel = reader.GetString("Tel"),
                            State = reader.GetBoolean("State")
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }

            return clients;
        }
    }
}
