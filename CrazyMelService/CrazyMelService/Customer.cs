﻿//***********************
//Authors: Kyle Fowler, Matt Anselmo, Adrian Krebs
//Project: CrazyMels
//File: Customer.cs
//Date: 23/11/14
//Purpose: This file defines the Customer object
//***********************
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
        //Increment the values by power of two for added on classes
        private const int QUIERED_VALUE = 1;

        public string tableName { get; set; }
        public string custIDColumnName { get; set; }
        public string firstNameColumnName { get; set; }
        public string lastNameColumnName { get; set; }
        public string phoneNumberColumnName { get; set; }  

        private bool quiered { get; set; }

        [DataMember]
        private string custID { get; set; }
        [DataMember]
        private string firstName { get; set; }
        [DataMember]
        private string lastName { get; set; }
        [DataMember]
        private string phoneNumber { get; set; }
           
        public List<string> whereQueries;

        public Customer() 
        {
            tableName = "[Customer]";
            custIDColumnName = "[CustID]";
            firstNameColumnName = "[FirstName]";
            lastNameColumnName = "[LastName]";
            phoneNumberColumnName = "[PhoneNumber]";
            quiered = false;
            whereQueries = new List<string>();
        }

        //constructor of insert delete update
        public Customer(string FirstName, string LastName, string PhoneNumber, string CustID = "") : this()
        {
            custID = CustID;
            firstName = FirstName;
            lastName = LastName;
            phoneNumber = PhoneNumber;            
        }

        //constructor for searches
        public Customer(string constructString, char delimiter) : this()
        {
            string[] namesArray = constructString.Split(delimiter);

            custID = namesArray[0];
            firstName = namesArray[1];
            lastName = namesArray[2];
            phoneNumber = namesArray[3];

            //add to the WHERE Query of
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

        //makes a Where query.
        public string AddWhereQuery(string value, string columnName)
        {
            return "[Customer]." + columnName + "='" + value + "'";
        }

        //how to insert an Customer
        public string SQLInsert()
        {
           
            return "INSERT INTO " + tableName + "([FirstName], [LastName], [PhoneNumber]) VALUES ('" + firstName + "', '" + lastName + "', '" + phoneNumber + "');";
        }

        //how to update an Customer
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

        //how to delete an Customer
        public string SQLDelete()
        {
            string query = "";
            query += "DELETE FROM [Cart] WHERE [Cart].OrderID IN (SELECT [OrderID] FROM [Order] WHERE [CustID]=" + custID + ");";
            query += "DELETE FROM [Order] WHERE [CustID]=" + custID + ";";
            query += "DELETE FROM [Customer] WHERE [CustID]=" + custID + ";";
            return query;
        }

        //Validate input
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
            if (!Validator.ValidateVarchar(lastName, 50) || lastName == "")
            {
                return false;
            }
            if (!Validator.ValidateVarchar(phoneNumber, 12) || phoneNumber == "")
            {
                return false;
            }
            if (!Validator.ValidatePhoneNumber(phoneNumber))
            {
                return false;
            }
            return true;
        }

        //for Search Delete and Update when blank is valid
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

        //get value of orderQuiery
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