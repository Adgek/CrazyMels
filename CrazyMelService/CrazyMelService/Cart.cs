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
        private string tableName { get; set; }
        private string orderIDColumnName { get; set; }
        private string prodIDColumnName { get; set; }
        private string quantityColumnName { get; set; }
        
        [DataMember]
        public string orderID { get; set; }
        [DataMember]
        public string prodID { get; set; }
        [DataMember]
        public string quantity { get; set; } 
      
        public Cart() 
        {
            tableName = "[Cart]";
            orderIDColumnName = "[OrderID]";
            prodIDColumnName = "[ProdID]";
            quantityColumnName = "[Quantity]";
        }

        public Cart(string OrderID, string ProdID, string Quantity) : this()
        {
            orderID = OrderID;
            prodID = ProdID;
            quantity = Quantity;            
        }

        public string SQLInsert()
        {
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
            return "DELETE FROM  " + tableName + " WHERE " + orderIDColumnName + "='" + orderID + "' AND " + prodIDColumnName + "='" + prodID + "';";
        }

        public bool validateInput()
        {
            if (!Validator.ValidateInt(orderID) && orderID != "")
            {
                return false;
            }
            if (!Validator.ValidateInt(prodID))
            {
                return false;
            }
            if (!Validator.ValidateInt(quantity))
            {
                return false;
            }
            return true;
        }
    }


}