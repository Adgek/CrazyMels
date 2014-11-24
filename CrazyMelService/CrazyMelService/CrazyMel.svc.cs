using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace CrazyMelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : CrazyMel
    {       
        private static string SQL_USERNAME = "sa";
        private static string SQL_PASSWORD = "root";
        private static string SQL_SERVER = "MATT";
        private static string SQL_DATABASE = "CrazyMel";

        //4 inserts, one for each table. in each, check data, if valid data connect to DB,insert data to db 
        public string InsertCustomer(Stream data)//(string FirstName, string LastName, string PhoneNumber)
        {           
            StreamReader reader = new StreamReader(data);           
            string xmlString = reader.ReadToEnd();

            Customer c = (Customer)XMLParse.ParseXML(xmlString);

            if (!c.validateInput()) { return "Data not valid"; }

            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            { 
                d.OpenSQLConnection();
                d.Query(c.SQLInsert());
            }
            catch(Exception e)
            {
                return e.Message;
            }          
            
            return "Insert success";
        }

        public string InsertProduct(Stream data)
        {
            StreamReader reader = new StreamReader(data);           
            string xmlString = reader.ReadToEnd();

            Product c = (Product)XMLParse.ParseXML(xmlString);

            if (!c.validateInput()) { return "Data not valid"; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            { 
                d.OpenSQLConnection();
                d.Query(c.SQLInsert());
            }
            catch(Exception e)
            {
                return e.Message;
            }          
            
            return "Insert success";
        }

        public string InsertOrder(Stream data)
        {
            StreamReader reader = new StreamReader(data);           
            string xmlString = reader.ReadToEnd();

            Order c = (Order)XMLParse.ParseXML(xmlString);

            if (!c.validateInput()) { return "Data not valid"; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            { 
                d.OpenSQLConnection();
                d.Query(c.SQLInsert());
            }
            catch(Exception e)
            {
                return e.Message;
            }          
            
            return "Insert success";
        }

        public string InsertCart(Stream data)
        {
            StreamReader reader = new StreamReader(data);           
            string xmlString = reader.ReadToEnd();

            Cart c = (Cart)XMLParse.ParseXML(xmlString);

            if (!c.validateInput()) { return "Data not valid"; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            { 
                d.OpenSQLConnection();
                d.Query(c.SQLInsert());
            }
            catch(Exception e)
            {
                return e.Message;
            }          
            
            return "Insert success";
        }

        //UPDATES

        public string UpdateCustomer(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Customer c = (Customer)XMLParse.ParseXML(xmlString);
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLUpdate());
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return "Update success";            
        }

        public string UpdateProduct(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Product c = (Product)XMLParse.ParseXML(xmlString);
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLUpdate());
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return "Update success";
        }

        public string UpdateOrder(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Order c = (Order)XMLParse.ParseXML(xmlString);
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLUpdate());
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return "Update success";
        }

        public string UpdateCart(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Cart c = (Cart)XMLParse.ParseXML(xmlString);
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLUpdate());
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return "Update success";
        }

        //UPDATES

        public string DeleteCustomer(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Customer c = (Customer)XMLParse.ParseXML(xmlString);

            if (!c.validateInput(true)) { return "Data not valid"; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLDelete());
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Delete success";
        }

        public string DeleteProduct(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Product c = (Product)XMLParse.ParseXML(xmlString);

            if (!c.validateInput(true)) { return "Data not valid"; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLDelete());
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Delete success";
        }

        public string DeleteOrder(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Order c = (Order)XMLParse.ParseXML(xmlString);

            if (!c.validateInput(true)) { return "Data not valid"; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLDelete());
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Delete success";
        }

        public string DeleteCart(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Cart c = (Cart)XMLParse.ParseXML(xmlString);

            if (!c.validateInput(true)) { return "Data not valid"; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLDelete());
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Delete success";
        }

        public string GetPO(string po)
        {
            SearchDatabase mySearch = new SearchDatabase();
            string sqlQuery = mySearch.SearchPo(po);

            string sqlResponse = "";

            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();

                sqlResponse = d.SearchQuery(sqlQuery, mySearch);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return sqlResponse;            
        }

        public string Search(string CustomerString, string ProductString, string OrderString, string CartString)
        {
            XmlDocument xml = null;
            SearchDatabase mySearch = new SearchDatabase(CustomerString, ProductString, OrderString, CartString);
            string sqlQuery = mySearch.Search();
            string sqlResponse = "";

            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();

                sqlResponse = d.SearchQuery(sqlQuery, mySearch);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return sqlResponse;
        }
    }
}
