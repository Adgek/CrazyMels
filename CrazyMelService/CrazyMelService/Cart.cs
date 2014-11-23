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
        //Adrian Added value
        //Increment the values by power of two for added on classes
        private const int QUIERED_VALUE = 8;

        private string tableName { get; set; }
        private string orderIDColumnName { get; set; }
        private string prodIDColumnName { get; set; }
        private string quantityColumnName { get; set; }
        
        //Adrian added value
        private bool quiered { get; set; }

        [DataMember]
        public string orderID { get; set; }
        [DataMember]
        public string prodID { get; set; }
        [DataMember]
        public string quantity { get; set; } 
      
        //Adrian added Value.... not sure i need the DataMember
        //This also prob makes errors as it wasnt tested.
        public List<string> whereQueries { get; set; }

        public Cart() 
        {
            tableName = "[Cart]";
            orderIDColumnName = "[OrderID]";
            prodIDColumnName = "[ProdID]";
            quantityColumnName = "[Quantity]";
            quiered = false;
        }

        public Cart(string OrderID, string ProdID, string Quantity) : this()
        {
            orderID = OrderID;
            prodID = ProdID;
            quantity = Quantity;            
        }

        public Cart(string constructString, char delimiter) : this()
        {
            string[] namesArray = constructString.Split(delimiter);

            orderID = namesArray[0];
            prodID = namesArray[1];
            quantity = namesArray[2];

            //Adrian Changes add to the WHERE Query of
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

        //Adrian Added Function. makes a Where query.
        //Might not work not tested. Might need [ORDER] in here..... not sure.
        public string AddWhereQuery(string value, string columnName)
        {
            return "WHERE " + columnName + "='" + value + "';";
        }

        public string SQLInsert()
        {
            //FIX THIS MATTTT NO ORDER lol
            //this is a compileerror so that Matt sees this
            return "INSERT INTO " + tableName + " VALUES ('" + orderID + "', '" + prodID + "', '" + quantity + "');";
        }

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

        public string SQLDelete()
        {
            string query = "";
            query += "DELETE FROM [Cart] WHERE [Cart].OrderID=" + orderID + " AND [Cart].ProdID=" + prodID + ";";            
            return query;
        }

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

        //Adrian changes for Search Delete and Update when blank is valid
        public bool validateInput(bool blankIsValid)
        {
            if (!Validator.ValidateInt(orderID) && orderID != "")
            {
                return false;
            }
            if (!Validator.ValidateInt(prodID) && orderID != "")
            {
                return false;
            }
            if (!Validator.ValidateInt(quantity)  && orderID != "")
            {
                return false;
            }
            return true;
        }

        //Adrian changes get value of orderQuiery
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