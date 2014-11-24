﻿//***********************
//Authors: Kyle Fowler, Matt Anselmo, Adrian Krebs
//Project: CrazyMels
//File: CrazyMel.svc.cs
//Date: 23/11/14
//Purpose: This file is the main controller which states exactly what happens
//          when each call comes in
//***********************
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
    public class Service1 : CrazyMel
    {       
        private static string SQL_USERNAME = "sa";
        private static string SQL_PASSWORD = "root";
        private static string SQL_SERVER = "KYLESRIG";
        private static string SQL_DATABASE = "CrazyMels";

        //4 inserts, one for each table. in each, check data, if valid data connect to DB,insert data to db 

        //
        public string InsertCustomer(Stream data)
        {           
            StreamReader reader = new StreamReader(data);           
            string xmlString = reader.ReadToEnd();

            Customer c = (Customer)XMLParse.ParseXML(xmlString);

            //return bad input
            if (!c.validateInput()) { return "Data not valid"; }

            //connect to db
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

        //insert product
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

        //insert order
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

        //insert cart
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

        //update customer
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

        //update product
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

        //update order
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

        //update cart
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




        //Deletes

        //delete Customer
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

        //delete product
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

        //delete order
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

        //delete cart
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




        //SEARCHES

        //Get the PO 
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

        //General Search of all fields
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
