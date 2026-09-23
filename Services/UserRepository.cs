using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Services
{
    public class UserRepository
    {
        private readonly ConnectionDB connectionDB;

        public UserRepository()
        {
            connectionDB = new ConnectionDB();
        }

        public bool CreateUser(UserClass user)
        {
            string query = @"
        INSERT INTO users 
            (Name, Surname, Dni, Email, Tel, Username, Password, Rol, State, CreatedDate)
        VALUES 
            (@name, @surname, @dni, @email, @tel, @username, @password, @rol, @state, @createdDate); ";

            try
            {
                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@name", user.Name),
                    new MySqlParameter("@surname", user.Surname),
                    new MySqlParameter("@dni", user.Dni),
                    new MySqlParameter("@email", user.Email),
                    new MySqlParameter("@tel", user.Tel),
                    new MySqlParameter("@username", user.Username),
                    new MySqlParameter("@password", user.Password),
                    new MySqlParameter("@rol", user.Rol),
                    new MySqlParameter("@state", user.State),
                    new MySqlParameter("@createdDate", user.CreatedDate)
                );

                return rowsAffected > 0;
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                string mensajeError = "No se pudo registrar el usuario porque un dato ya existe.";
                string mensajeMySQL = ex.Message.ToLower();

                if (mensajeMySQL.Contains("dni"))
                {
                    mensajeError = $"El DNI '{user.Dni}' ya está registrado en el sistema.";
                }
                else if (mensajeMySQL.Contains("email"))
                {
                    mensajeError = $"El correo electrónico '{user.Email}' ya está siendo usado por otra cuenta.";
                }
                else if (mensajeMySQL.Contains("username") )
                {
                    mensajeError = $"El nombre de usuario '{user.Username}' ya no está disponible.";
                }
                else if (mensajeMySQL.Contains("tel"))
                {
                    mensajeError = $"El teléfono '{user.Tel}' ya se encuentra en uso.";
                }

                MessageBox.Show(mensajeError, "Datos Duplicados", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error de Base de Datos: {ex.Message}", "Error Técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public List<UserClass> GetAllUsers()
        {
            List<UserClass> users = new List<UserClass>();
            string query = "SELECT * FROM users";
            using (var reader = connectionDB.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    UserClass user = new UserClass
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Surname = reader.GetString("Surname"),
                        Dni = reader.GetString("Dni"),
                        Email = reader.GetString("Email"),
                        Tel = reader.GetString("Tel"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Rol = reader.GetString("Rol"),
                        State = reader.GetBoolean("State"),
                        CreatedDate = reader.GetDateTime("CreatedDate")
                    };
                    users.Add(user);
                }
            }
            return users;
        }

        public bool UpdateUser(UserClass user)
        {
            string query = @"
                UPDATE users 
                SET Name = @name, Surname = @surname, Dni = @dni, Email = @email, Tel = @tel, Username = @username, Password = @password, Rol = @rol, State = @state
                WHERE Id = @id;
            ";
            int rowsAffected = connectionDB.ExecuteNonQuery(
                query,
                new MySqlParameter("@name", user.Name),
                new MySqlParameter("@surname", user.Surname),
                new MySqlParameter("@dni", user.Dni),
                new MySqlParameter("@email", user.Email),
                new MySqlParameter("@tel", user.Tel),
                new MySqlParameter("@username", user.Username),
                new MySqlParameter("@password", user.Password),
                new MySqlParameter("@rol", user.Rol),
                new MySqlParameter("@state", user.State),
                new MySqlParameter("@id", user.Id)
            );
            return rowsAffected > 0;
        }

        public bool DeleteUser(int userId)
        {
            string query = "UPDATE users SET State = 0 WHERE Id = @id";
            int rowsAffected = connectionDB.ExecuteNonQuery(query, new MySqlParameter("@id", userId));
            return rowsAffected > 0;
        }

        public bool RestoreUser(int userId)
        {
            string query = "UPDATE users SET State = 1 WHERE Id = @id";
            int rowsAffected = connectionDB.ExecuteNonQuery(query, new MySqlParameter("@id", userId));
            return rowsAffected > 0;
        }

    }
}
