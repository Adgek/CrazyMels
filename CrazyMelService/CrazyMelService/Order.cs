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
        private string tableName { get; set; }
        private string orderIDColumnName { get; set; }
        private string custIDColumnName { get; set; }
        private string poNumberColumnName { get; set; }
        private string orderDateColumnName { get; set; }  

        [DataMember]
        public string orderID { get; set; }
        [DataMember]
        public string custID { get; set; }
        [DataMember]
        public string poNumber { get; set; }
        [DataMember]
        public string orderDate { get; set; }   

        public Order() 
        {
            tableName = "[Order]";
            orderIDColumnName = "[OrderID]";
            custIDColumnName = "[CustID]";
            poNumber = "[PoNumber]";
            orderDateColumnName = "[OrderDate]";
        }

        public Order(string OrderID, string CustID, string PoNumber, string OrderDate) : this()
        {
            orderID = OrderID;
            custID = CustID;
            poNumber = PoNumber;
            orderDate = OrderDate;
        }

        public Order(string constructString, char delimiter) : this()
        {
            string[] namesArray = constructString.Split(delimiter);

            orderID = namesArray[0];
            custID = namesArray[1];
            poNumber = namesArray[2];
            orderDate = namesArray[3];
        }

        public string SQLInsert()
        {
            return "INSERT INTO " + tableName + "(CustID, OrderDate, PoNumber) VALUES ('" + custID + "', '" + orderDate + "', '" + poNumber + "');";
        }

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

        public string SQLDelete()
        {
            string query = "";
            query += "DELETE FROM [Cart] WHERE [Cart].OrderID=" + orderID + ";";
            query += "DELETE FROM [Order] WHERE [OrderID]=" + orderID + ";";            
            return query;
        }

        public bool validateInput()
        {
            if (!Validator.ValidateInt(orderID))
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
    }
}