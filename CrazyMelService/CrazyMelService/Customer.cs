﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelService
{
    [DataContract]
    public class Customer
    {
        private string tableName { get; set; }
        private string custIDColumnName { get; set; }
        private string firstNameColumnName { get; set; }
        private string lastNameColumnName { get; set; }
        private string phoneNumberColumnName { get; set; }  

        [DataMember]
        private string custID { get; set; }
        [DataMember]
        private string firstName { get; set; }
        [DataMember]
        private string lastName { get; set; }
        [DataMember]
        private string phoneNumber { get; set; }

        public Customer() 
        {
            tableName = "[Customer]";
            custIDColumnName = "[CustID]";
            firstNameColumnName = "[FirstName]";
            lastNameColumnName = "[LastName]";
            phoneNumberColumnName = "[PhoneNumber]";
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
        }

        public string SQLInsert()
        {
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
    }

    

  
}