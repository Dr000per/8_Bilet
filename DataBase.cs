using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _8_Bilet
{
    public class DataBase : IDisposable
    {
        SqlConnection _connection;
        string _connectionstring = @"Data Source = DESKTOP-BBAJL13\SQLEXPRESS; Initial Catalog = bileti; Integrated Security = True;";            // Это строка подключения к базе на своём ПК (менять под свою)
        //string _connectionstring = @"Server = db.edu.cchgeu.ru; DataBase = 193_Shelylin; User = 193_Shelylin; Password = 193_Shelylin;";          // Это строка подключения к базе теха (менять под свою)

        public DataBase()
        {
            OpenConnection();
        }

        public void OpenConnection()
        {
            _connection = new SqlConnection(_connectionstring);
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public DataTable ExecuteSql(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, _connection);
            var reader = cmd.ExecuteReader();
            dt.Load(reader);

            return dt;
        }

        public void ExecuteSqlNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, _connection);
            cmd.ExecuteNonQuery();
        }
        public void Dispose()
        {
            CloseConnection();
        }
    }
}
