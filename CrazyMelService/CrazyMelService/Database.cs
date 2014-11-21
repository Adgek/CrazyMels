using System;
using System.Collections.Generic;
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

        public Database() { }
        public Database(string Username, string Password, string Server, string DatabaseName)
        {
            username = Username;
            password = Password;
            server = Server;
            databaseName = DatabaseName;
        }
    }
}