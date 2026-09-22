using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NexoStock.Utils
{
    internal class ConnectionDB
    {
        private readonly string connectionString =
            "Server=localhost;Database=nexusstock;Uid=root;Pwd=root;";

        public MySqlConnection GetConnection()
        {
            MySqlConnection connection =
                new MySqlConnection(connectionString);

            connection.Open();

            return connection;
        }

        public MySqlDataReader ExecuteReader(
            string query,
            params MySqlParameter[] parameters)
        {
            MySqlConnection connection = GetConnection();

            MySqlCommand command =
                new MySqlCommand(query, connection);

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            return command.ExecuteReader(
                CommandBehavior.CloseConnection
            );
        }

        public int ExecuteNonQuery(
          string query,
        params MySqlParameter[] parameters)
        {
            using MySqlConnection connection = GetConnection();

            using MySqlCommand command = new MySqlCommand(query, connection);

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            return command.ExecuteNonQuery();
        }
    }
}