using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace productoMVC.Models
{
    public class ControlPagosEntities
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        // Constructor
        public ControlPagosEntities()
        {
            Initialize();
        }

        // Inicializa los valores de la conexión
        private void Initialize()
        {
            server = "localhost";
            database = "controlpagos";
            uid = "root";
            password = "";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                               database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        // Abre la conexión a la base de datos
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // Gestiona los errores de conexión
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("No se puede conectar al servidor. Contacte al administrador.");
                        break;

                    case 1045:
                        Console.WriteLine("Nombre de usuario o contraseña incorrectos, por favor intente de nuevo.");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public DataTable SelectQuery(string query)
        {
            DataTable dataTable = new DataTable();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                this.CloseConnection();
            }
            return dataTable;
        }

        public void ExecuteQuery(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}
