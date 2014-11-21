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

        public Customer(string FirstName, string LastName, string PhoneNumber, string CustID = "") : base()
        {
            custID = CustID;
            firstName = FirstName;
            lastName = LastName;
            phoneNumber = PhoneNumber;
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
            query.Remove(query.Length - 1);

            query += "WHERE " + custIDColumnName + "='" + custID + "';";

            return query;
        }

        public string SQLDelete()
        {
            return "DELETE FROM  " + tableName + " WHERE " + custIDColumnName + "='" + custID + "');";
        }
    }

    

  
}