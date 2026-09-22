using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    (name, surname, dni, email, tel, password, rol, state, created_date)
                VALUES 
                    (@name, @surname, @dni, @email, @tel, @password, @rol, @state, @createdDate);
            ";

                int rowsAffected = connectionDB.ExecuteNonQuery(
                    query,
                    new MySqlParameter("@name", user.Name),
                    new MySqlParameter("@surname", user.Surname),
                    new MySqlParameter("@dni", user.Dni),
                    new MySqlParameter("@email", user.Email),
                    new MySqlParameter("@tel", user.Tel),
                    new MySqlParameter("@password", user.Password),
                    new MySqlParameter("@rol", user.Rol),
                    new MySqlParameter("@state", user.State),
                    new MySqlParameter("@createdDate", user.CreatedDate)
                );

                return rowsAffected > 0;
            
            }
    }
}
