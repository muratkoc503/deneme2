using System;
using System.Data.SqlClient;

namespace WebForm1
{
    public class sqlHelpCom
    {
        private string _server;
        private string _database;
        private string _username;
        private string _password;

        public sqlHelpCom(string server, string database, string username, string password)
        {
            _server = server;
            _database = database;
            _username = username;
            _password = password;
        }

        public string GetConnectionString()
        {
            return $"Data Source={_server};Initial Catalog={_database};User ID={_username};Password={_password}";
        }

        public bool sqlHelpConnect()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Bağlantı hatası durumunda burada gerekli işlemler yapılabilir.
                return false;
            }
        }
    }
}
