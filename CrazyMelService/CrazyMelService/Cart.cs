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
    public class Cart
    {
        //Increment the values by power of two for added on classes
        private const int QUIERED_VALUE = 8;

        public string tableName { get; set; }
        public string orderIDColumnName { get; set; }
        public string prodIDColumnName { get; set; }
        public string quantityColumnName { get; set; }

        private bool quiered { get; set; }

        [DataMember]
        public string orderID { get; set; }
        [DataMember]
        public string prodID { get; set; }
        [DataMember]
        public string quantity { get; set; } 
      
        public List<string> whereQueries;

        public Cart() 
        {
            tableName = "[Cart]";
            orderIDColumnName = "[OrderID]";
            prodIDColumnName = "[ProdID]";
            quantityColumnName = "[Quantity]";
            quiered = false;
            whereQueries = new List<string>();
        }

        //constructor of insert delete update
        public Cart(string OrderID, string ProdID, string Quantity) : this()
        {
            orderID = OrderID;
            prodID = ProdID;
            quantity = Quantity;            
        }

        //constructor for searches
        public Cart(string constructString, char delimiter) : this()
        {
            string[] namesArray = constructString.Split(delimiter);

            orderID = namesArray[0];
            prodID = namesArray[1];
            quantity = namesArray[2];

            //add to the WHERE Query of
            //QuieredColumns and set the flag to true
            
            if(orderID != "")
            {
                whereQueries.Add(AddWhereQuery(orderID, orderIDColumnName));
                quiered = true;
            }
            if(prodID != "")
            {
                whereQueries.Add(AddWhereQuery(prodID, prodIDColumnName));
                quiered = true;
            }
            if(quantity != "")
            {
                whereQueries.Add(AddWhereQuery(quantity, quantityColumnName));
                quiered = true;
            }
        }

        //makes a Where query
        public string AddWhereQuery(string value, string columnName)
        {
            return "[Cart]." + columnName + "='" + value + "'";
        }

        //how to insert an Cart
        public string SQLInsert()
        {
            return "INSERT INTO " + tableName + "([OrderID], [ProdID], [Quantity]) VALUES ('" + orderID + "', '" + prodID + "', '" + quantity + "');";
        }

        //how to update an Cart
        public string SQLUpdate()
        {
            string query = "UPDATE " + tableName + " SET ";

            if (orderID != "")
            {
                query += orderIDColumnName + "='" + orderID + "', ";
            }
            if (prodID != "")
            {
                query += prodIDColumnName + "='" + prodID + "', ";
            }
            if (quantity != "")
            {
                query += quantityColumnName + "='" + quantity + "', ";
            }

            query = query.Substring(0, query.LastIndexOf(",")) + query.Substring(query.LastIndexOf(",") + 1);

            query += "WHERE " + orderIDColumnName + "='" + orderID + "' AND " + prodIDColumnName + "='" + prodID + "';";

            return query;
        }

        //how to delete an Cart
        public string SQLDelete()
        {
            string query = "";
            if (prodID == "")
            {
                query += "DELETE FROM [Cart] WHERE [Cart].OrderID=" + orderID + ";";
                return query;
            }
            else if (orderID == "")
            {
                query += "DELETE FROM [Cart] WHERE [Cart].ProdID=" + prodID + ";";
                return query;
            }

            query += "DELETE FROM [Cart] WHERE [Cart].OrderID=" + orderID + " AND [Cart].ProdID=" + prodID + ";";

                        
            return query;
        }

        //Validate input
        public bool validateInput()
        {
            if (!Validator.ValidateInt(orderID) && orderID != "")
            {
                return false;
            }
            if (!Validator.ValidateInt(prodID) && orderID != "")
            {
                return false;
            }
            if (!Validator.ValidateInt(quantity))
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
            if (!Validator.ValidateInt(prodID) && prodID != "")
            {
                return false;
            }
            if (!Validator.ValidateInt(quantity)  && quantity != "")
            {
                return false;
            }
            return true;
        }

        //get value of orderQuiery
        public int WasCartQuiered()
        {
            if(quiered)
            {
                return QUIERED_VALUE;
            }

            return 0;
        }
    }


}