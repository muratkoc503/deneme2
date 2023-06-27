using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebForm1;

namespace WebApplication5
{
    public class SqlQuery
    {
        public DataTable GetSQLData(string query, string yamlName)
        {
            DataTable dataTable = new DataTable();

            try
            {
                ConfigData configData = ConfigData.ReadConfigData(yamlName);

                // SQL bağlantısı oluştur
                sqlHelpCom sqlHelper = new sqlHelpCom(configData.Server, configData.Database, configData.Username, configData.Password);

                if (!sqlHelper.sqlHelpConnect())
                {
                    // SQL bağlantısı başarısız oldu
                    // Hata mesajı gösterebilir veya diğer işlemler yapabilirsiniz
                    return dataTable;
                }

                // SQL bağlantısı ve sorgu için SqlConnection ve SqlCommand oluştur
                using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // SqlDataAdapter ve DataTable kullanarak verileri al
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda gerekli işlemleri yapabilirsiniz
            }

            return dataTable;
        }
    }
}