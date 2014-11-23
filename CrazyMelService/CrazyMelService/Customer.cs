using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelService
{
    [DataContract]
    public class Customer
    {
        //Adrian Added value
        //Increment the values by power of two for added on classes
        private const int QUIERED_VALUE = 1;

        private string tableName { get; set; }
        private string custIDColumnName { get; set; }
        private string firstNameColumnName { get; set; }
        private string lastNameColumnName { get; set; }
        private string phoneNumberColumnName { get; set; }  

        //Adrian added value
        private bool quiered { get; set; }

        [DataMember]
        private string custID { get; set; }
        [DataMember]
        private string firstName { get; set; }
        [DataMember]
        private string lastName { get; set; }
        [DataMember]
        private string phoneNumber { get; set; }
        
        //Adrian added Value.... not sure i need the DataMember
        //This also prob makes errors as it wasnt tested.    
        public List<string> whereQueries { get; set; }

        public Customer() 
        {
            tableName = "[Customer]";
            custIDColumnName = "[CustID]";
            firstNameColumnName = "[FirstName]";
            lastNameColumnName = "[LastName]";
            phoneNumberColumnName = "[PhoneNumber]";
            quiered = false;
        }

        public Customer(string FirstName, string LastName, string PhoneNumber, string CustID = "") : this()
        {
            custID = CustID;
            firstName = FirstName;
            lastName = LastName;
            phoneNumber = PhoneNumber;            
        }

        public Customer(string constructString, char delimiter) : this()
        {
            string[] namesArray = constructString.Split(delimiter);

            custID = namesArray[0];
            firstName = namesArray[1];
            lastName = namesArray[2];
            phoneNumber = namesArray[3];

            //Adrian Changes add to the WHERE Query of
            //QuieredColumns and set the flag to true
            
            if(custID != "")
            {
                whereQueries.Add(AddWhereQuery(custID, custIDColumnName));
                quiered = true;
            }
            if(firstName != "")
            {
                whereQueries.Add(AddWhereQuery(firstName, firstNameColumnName));
                quiered = true;
            }
            if(lastName != "")
            {
                whereQueries.Add(AddWhereQuery(lastName, lastNameColumnName));
                quiered = true;
            }
            if(phoneNumber != "")
            {
                whereQueries.Add(AddWhereQuery(phoneNumber, phoneNumberColumnName));
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
            return "INSERT INTO " + tableName + " VALUES ('" + firstName + "', '" + lastName + "', '" + phoneNumber + "');";
        }

        public string SQLUpdate()
        {
            string query = "UPDATE " + tableName + " SET ";

            if(firstName != ""){
                query += firstNameColumnName + "='" + firstName + "', ";
            }
            if(lastName != ""){
                query += lastNameColumnName + "='" + lastName + "', ";
            }
            if(phoneNumber != ""){
                query += phoneNumberColumnName + "='" + phoneNumber + "', ";
            }
           
            query = query.Substring(0, query.LastIndexOf(",")) + query.Substring(query.LastIndexOf(",") + 1);

            query += "WHERE " + custIDColumnName + "='" + custID + "';";

            return query;
        }

        public string SQLDelete()
        {
            string query = "";
            query += "DELETE FROM [Cart] WHERE [Cart].OrderID IN (SELECT [OrderID] FROM [Order] WHERE [CustID]=" + custID + ");";
            query += "DELETE FROM [Order] WHERE [CustID]=" + custID + ";";
            query += "DELETE FROM [Customer] WHERE [CustID]=" + custID + ";";
            return query;
        }

        public bool validateInput()
        {
            if (!Validator.ValidateInt(custID) && custID != "")
            {
                return false;
            }
            if (!Validator.ValidateVarchar(firstName, 50))
            {
                return false;
            }
            if (!Validator.ValidateVarchar(lastName, 50))
            {
                return false;
            }
            if (!Validator.ValidateVarchar(phoneNumber, 12))
            {
                return false;
            }
            return true;
        }

        //Adrian changes for Search Delete and Update when blank is valid
        public bool validateInput(bool blankIsValid)
        {
            if (!Validator.ValidateInt(custID) && custID != "")
            {
                return false;
            }
            if (!Validator.ValidateVarchar(firstName, 50) && firstName != "")
            {
                return false;
            }
            if (!Validator.ValidateVarchar(lastName, 50) && lastName != "")
            {
                return false;
            }
            if (!Validator.ValidateVarchar(phoneNumber, 12) && phoneNumber != "")
            {
                return false;
            }
            return true;
        }

        //Adrian changes get value of orderQuiery
        public int WasCustomerQuiered()
        {
            if(quiered)
            {
                return QUIERED_VALUE;
            }

            return 0;
        }
    }

    

  
}