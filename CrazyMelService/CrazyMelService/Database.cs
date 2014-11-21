using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrazyMelService
{
    public class Database
    {
        private string username { get; set; }
        private string password { get; set; }
        private string server { get; set; }
        private string databaseName { get; set; }
        private SqlConnection con;

        public Database() { }
        public Database(string Username, string Password, string Server, string DatabaseName)
        {
            username = Username;
            password = Password;
            server = Server;
            databaseName = DatabaseName;
        }

        public void OpenSQLConnection()
        {
            con = new SqlConnection(GetConnectionString(server, databaseName));
            con.Open();
        }

        public void CloseSQLConnection()
        {
            con.Close();
        }

        public void Qeury(string QueryString)
        {            
            SqlCommand cmd = new SqlCommand(QueryString, con);
            cmd.ExecuteNonQuery();            
        }

        private string GetConnectionString(string Server, string Database)
        {
            string connectionString = "Data Source=" + Server + ";Initial Catalog=" + Database + ";Integrated Security=True";
            return connectionString;
        }
    }
}