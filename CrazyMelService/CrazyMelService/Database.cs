﻿//***********************
//Authors: Kyle Fowler, Matt Anselmo, Adrian Krebs
//Project: CrazyMels
//File: Database.cs
//Date: 23/11/14
//Purpose: This file is the Database handler, taking care of database connections and querys to the database
//***********************
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

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

        public void Query(string QueryString)
        {            
            SqlCommand cmd = new SqlCommand(QueryString, con);
            cmd.ExecuteNonQuery();            
        }

        //querys a search of the database and puts it in an xml format
        public string SearchQuery(string query, SearchDatabase sd)
        {
            SearchDatabase searchDatabase = sd;            
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count < 1) { return "No PO report found"; }

            string XMLResponse = "\n<response>\n";
                
            XMLResponse += "    <row>\n";

            foreach (string item in sd.searchColumns)
            {
                XMLResponse += "        <value>" + item + "</value>\n";
            }

            XMLResponse += "    </row>\n";

            foreach (DataRow dr in dt.Rows)
            {

                XMLResponse += "    <row>\n";

                foreach (var item in dr.ItemArray)
                {
                    XMLResponse += "        <value>" + item.ToString() + "</value>\n";
                }

                XMLResponse += "    </row>\n";
             }

            XMLResponse += "</response>";

            return XMLResponse;
        }

        private string GetConnectionString(string Server, string Database)
        {
            string connectionString = "Data Source=" + Server + ";Initial Catalog=" + Database + ";Integrated Security=True";
            return connectionString;
        }
    }
}