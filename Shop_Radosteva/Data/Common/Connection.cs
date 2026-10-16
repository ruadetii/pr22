using MySql.Data.MySqlClient;

namespace Shop_Radosteva.Data.Common
{
    public class Connection
    {
        readonly static string path = "server=localhost;port=3306;database=pr23;uid=root";

        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(path);
            connection.Open();

            return connection;
        }

        public static MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(SQL, connection);
            return command.ExecuteReader();
        }

        public static void CloseConnection(MySqlConnection connection) 
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
