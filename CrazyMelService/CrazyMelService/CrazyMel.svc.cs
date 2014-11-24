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
        public bool InsertCustomer(Stream data)//(string FirstName, string LastName, string PhoneNumber)
        {           
            StreamReader reader = new StreamReader(data);           
            string xmlString = reader.ReadToEnd();

            Customer c = (Customer)XMLParse.ParseXML(xmlString);

            if (!c.validateInput()) { return false; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            { 
                d.OpenSQLConnection();
                d.Query(c.SQLInsert());
            }
            catch(Exception e)
            {
                return false;
            }          
            
            return true;
        }

        public bool InsertProduct(Stream data)
        {
            StreamReader reader = new StreamReader(data);           
            string xmlString = reader.ReadToEnd();

            Product c = (Product)XMLParse.ParseXML(xmlString);

            if (!c.validateInput()) { return false; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            { 
                d.OpenSQLConnection();
                d.Query(c.SQLInsert());
            }
            catch(Exception e)
            {
                return false;
            }          
            
            return true;
        }

        public bool InsertOrder(Stream data)
        {
            StreamReader reader = new StreamReader(data);           
            string xmlString = reader.ReadToEnd();

            Order c = (Order)XMLParse.ParseXML(xmlString);

            if (!c.validateInput()) { return false; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            { 
                d.OpenSQLConnection();
                d.Query(c.SQLInsert());
            }
            catch(Exception e)
            {
                return false;
            }          
            
            return true;
        }

        public bool InsertCart(Stream data)
        {
            StreamReader reader = new StreamReader(data);           
            string xmlString = reader.ReadToEnd();

            Cart c = (Cart)XMLParse.ParseXML(xmlString);

            if (!c.validateInput()) { return false; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            { 
                d.OpenSQLConnection();
                d.Query(c.SQLInsert());
            }
            catch(Exception e)
            {
                return false;
            }          
            
            return true;
        }

        //UPDATES

        public bool UpdateCustomer(Stream data)
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
                return false;
            }
            return true;            
        }

        public bool UpdateProduct(Stream data)
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
                return false;
            }
            return true;
        }

        public bool UpdateOrder(Stream data)
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
                return false;
            }
            return true;
        }

        public bool UpdateCart(Stream data)
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
                return false;
            }
            return true;
        }

        //UPDATES

        public bool DeleteCustomer(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Customer c = (Customer)XMLParse.ParseXML(xmlString);

            if (!c.validateInput(true)) { return false; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLDelete());
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool DeleteProduct(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Product c = (Product)XMLParse.ParseXML(xmlString);

            if (!c.validateInput(true)) { return false; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLDelete());
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool DeleteOrder(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Order c = (Order)XMLParse.ParseXML(xmlString);

            if (!c.validateInput(true)) { return false; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLDelete());
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool DeleteCart(Stream data)
        {
            StreamReader reader = new StreamReader(data);
            string xmlString = reader.ReadToEnd();

            Cart c = (Cart)XMLParse.ParseXML(xmlString);

            if (!c.validateInput(true)) { return false; }
            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();
                d.Query(c.SQLDelete());
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool GetPO(string po)
        {
            SearchDatabase mySearch = new SearchDatabase();

            mySearch.SearchPo(po);
            return true;
        }

        public XmlDocument Search(string CustomerString, string ProductString, string OrderString, string CartString)
        {
            XmlDocument xml = null;
            SearchDatabase mySearch = new SearchDatabase(CustomerString, ProductString, OrderString, CartString);
            string sqlQuery = mySearch.Search();

            Database d = new Database(SQL_USERNAME, SQL_PASSWORD, SQL_SERVER, SQL_DATABASE);
            try
            {
                d.OpenSQLConnection();

                xml = d.SearchQuery(sqlQuery, mySearch);
            }
            catch (Exception e)
            {
                return null;
            }

            return xml;
        }
    }
}
