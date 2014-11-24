//***********************
//Authors: Kyle Fowler, Matt Anselmo, Adrian Krebs
//Project: CrazyMels
//File: Order.cs
//Date: 23/11/14
//Purpose: This file defines the Order object
//***********************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelService
{
    [DataContract]
    public class Order
    {
        //Increment the values by power of two for added on classes
        private const int QUIERED_VALUE = 4;

        public string tableName { get; set; }
        public string orderIDColumnName { get; set; }
        public string custIDColumnName { get; set; }
        public string poNumberColumnName { get; set; }
        public string orderDateColumnName { get; set; }

        private bool quiered { get; set; }

        [DataMember]
        public string orderID { get; set; }
        [DataMember]
        public string custID { get; set; }
        [DataMember]
        public string poNumber { get; set; }
        [DataMember]
        public string orderDate { get; set; }
                
        public List<string> whereQueries;    

        public Order() 
        {
            tableName = "[Order]";
            orderIDColumnName = "[OrderID]";
            custIDColumnName = "[CustID]";
            poNumberColumnName = "[PoNumber]";
            orderDateColumnName = "[OrderDate]";
            quiered = false;
            whereQueries = new List<string>();
        }

        //constructor of insert delete update
        public Order(string OrderID, string CustID, string PoNumber, string OrderDate) : this()
        {
            orderID = OrderID;
            custID = CustID;
            poNumber = PoNumber;
            orderDate = OrderDate;
        }

        //constructor for searches
        public Order(string constructString, char delimiter) : this()
        {
            string[] namesArray = constructString.Split(delimiter);

            orderID = namesArray[0];
            custID = namesArray[1];
            poNumber = namesArray[2];
            orderDate = namesArray[3];

            //add to the WHERE Query of
            //QuieredColumns and set the flag to true
            if(orderID != "")
            {
                whereQueries.Add(AddWhereQuery(orderID, orderIDColumnName));
                quiered = true;
            }
            if(custID != "")
            {
                whereQueries.Add(AddWhereQuery(custID, custIDColumnName));
                quiered = true;
            }
            if(poNumber != "")
            {
                whereQueries.Add(AddWhereQuery(poNumber, poNumberColumnName));
                quiered = true;
            }
            if(orderDate != "")
            {
                whereQueries.Add(AddWhereQuery(orderDate, orderDateColumnName));
                quiered = true;
            }
        }

        //makes a Where query
        public string AddWhereQuery(string value, string columnName)
        {
            return "[Order]." + columnName + "='" + value + "'";
        }

        //how to insert an Order
        public string SQLInsert()
        {
            return "INSERT INTO " + tableName + "(CustID, OrderDate, PoNumber) VALUES ('" + custID + "', '" + orderDate + "', '" + poNumber + "');";
        }

        //how to update an Order
        public string SQLUpdate()
        {
            string query = "UPDATE " + tableName + " SET ";
                       
            if (custID != "")
            {
                query += custIDColumnName + "='" + custID + "', ";
            }
            if (orderDate != "")
            {
                query += orderDateColumnName + "='" + orderDate + "', ";
            }
            if (poNumber != "")
            {
                query += poNumberColumnName + "='" + poNumber + "', ";
            }            

            query = query.Substring(0, query.LastIndexOf(",")) + query.Substring(query.LastIndexOf(",") + 1);

            query += "WHERE " + orderIDColumnName + "='" + orderID + "';";

            return query;
        }

        //how to delete an Order
        public string SQLDelete()
        {
            string query = "";
            query += "DELETE FROM [Cart] WHERE [OrderID]=" + orderID + ";";
            query += "DELETE FROM [Order] WHERE [OrderID]=" + orderID + ";";            
            return query;
        }

        //Validate input
        public bool validateInput()
        {
            if (!Validator.ValidateInt(orderID) && orderID != "")
            {
                return false;
            }
            if (!Validator.ValidateInt(custID))
            {
                return false;
            }
            if (!Validator.ValidateVarchar(poNumber, 30))
            {
                return false;
            }
            if (!Validator.ValidateDate(orderDate))
            {
                return false;
            }
            return true;
        }

        //for Search Delete and Update when blank is valid
        public bool validateInput(bool blankIsValid)
        {
            if (!Validator.ValidateInt(orderID) && orderID != "")
            {
                return false;
            }
            if (!Validator.ValidateInt(custID) && custID != "")
            {
                return false;
            }
            if (!Validator.ValidateVarchar(poNumber, 30) && poNumber != "")
            {
                return false;
            }
            if (!Validator.ValidateDate(orderDate) && orderDate != "")
            {
                return false;
            }
            return true;
        }

        //get value of orderQuiery
        public int WasOrderQuiered()
        {
            if(quiered)
            {
                return QUIERED_VALUE;
            }

            return 0;
        }
    }
}