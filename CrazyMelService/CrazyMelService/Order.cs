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
        //Adrian Added value
        //Increment the values by power of two for added on classes
        private const int QUIERED_VALUE = 4;

        private string tableName { get; set; }
        private string orderIDColumnName { get; set; }
        private string custIDColumnName { get; set; }
        private string poNumberColumnName { get; set; }
        private string orderDateColumnName { get; set; }

        //Adrian added value
        private bool quiered { get; set; }

        [DataMember]
        public string orderID { get; set; }
        [DataMember]
        public string custID { get; set; }
        [DataMember]
        public string poNumber { get; set; }
        [DataMember]
        public string orderDate { get; set; }
        
        //Adrian added Value.... not sure i need the DataMember
        //This also prob makes errors as it wasnt tested.        
        public List<string> whereQueries { get; set; }           

        public Order() 
        {
            tableName = "[Order]";
            orderIDColumnName = "[OrderID]";
            custIDColumnName = "[CustID]";
            poNumberColumnName = "[PoNumber]";
            orderDateColumnName = "[OrderDate]";
            quiered = false;
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

            //Adrian Changes add to the WHERE Query of
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

        //Adrian Added Function. makes a Where query.
        //Might not work not tested. Might need [ORDER] in here..... not sure.
        public string AddWhereQuery(string value, string columnName)
        {
            return "WHERE " + columnName + "='" + value + "';";
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
            query += "DELETE FROM [Cart] WHERE [OrderID]=" + orderID + ";";
            query += "DELETE FROM [Order] WHERE [OrderID]=" + orderID + ";";            
            return query;
        }

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

        //Adrian changes for Search Delete and Update when blank is valid
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

        //Adrian Changes get value of orderQuiery
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