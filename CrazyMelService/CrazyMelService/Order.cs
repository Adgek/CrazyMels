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
            orderID = orderID;
            custID = CustID;
            poNumber = PoNumber;
            orderDate = OrderDate;
        }

        public string SQLInsert()
        {
            return "INSERT INTO " + tableName + " VALUES ('" + custID + "', '" + poNumber + "', '" + orderDate + "');";
        }

        public string SQLUpdate()
        {
            string query = "UPDATE " + tableName + " SET ";
                       
            if (custID != "")
            {
                query += custIDColumnName + "='" + custID + "', ";
            }
            if (poNumber != "")
            {
                query += poNumberColumnName + "='" + poNumber + "', ";
            }
            if (orderDate != "")
            {
                query += orderDateColumnName + "='" + orderDate + "', ";
            }

            query = query.Substring(0, query.LastIndexOf(",")) + query.Substring(query.LastIndexOf(",") + 1);

            query += "WHERE " + orderIDColumnName + "='" + orderID + "';";

            return query;
        }

        public string SQLDelete()
        {
            return "DELETE FROM  " + tableName + " WHERE " + orderIDColumnName + "='" + orderID + "');";
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
            if (!Validator.ValidateVarChar(poNumber, 30))
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