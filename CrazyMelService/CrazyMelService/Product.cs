using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelService
{    
    [DataContract]
    public class Product
    {
        //Adrian Added value
        //Increment the values by power of two for added on classes
        private const int QUIERED_VALUE = 2;

        public string tableName { get; set; }
        public string productIdColumnName { get; set; }
        public string productNameColumnName { get; set; }
        public string priceColumnName { get; set; }
        public string prodWeightColumnName { get; set; }
        public string inStockColumnName { get; set; }

        //Adrian added value
        private bool quiered { get; set; } 

        [DataMember]
        public string prodID { get; set; }
        [DataMember]
        public string prodName { get; set; }
        [DataMember]
        public string price { get; set; }
        [DataMember]
        public string prodWeight { get; set; }
        [DataMember]
        public string inStock { get; set; }
    
        //Adrian added Value.... not sure i need the DataMember
        //This also prob makes errors as it wasnt tested.        
        public List<string> whereQueries;
    
        public Product() 
        {
            tableName = "[Product]";
            productIdColumnName = "[ProdId]";
            productNameColumnName = "[ProdName]";
            priceColumnName = "[Price]";
            prodWeightColumnName = "[ProdWeight]";
            inStockColumnName = "[InStock]";
            quiered = false;
            whereQueries = new List<string>();
        }

        public Product(string ProductName, string Price, string ProdWeight, string InStock, string ProductId = "") : this()
        {
            prodID = ProductId;
            prodName = ProductName;
            price = Price;
            prodWeight = ProdWeight;
            inStock = InStock;
        }

        public Product(string constructString, char delimiter) : this()
        {
            string[] namesArray = constructString.Split(delimiter);

            prodID = namesArray[0];
            prodName = namesArray[1];
            price = namesArray[2];
            prodWeight = namesArray[3];
            inStock = namesArray[4];

            //Adrian Changes add to the WHERE Query of
            //QuieredColumns and set the flag to true           
            if(prodID != "")
            {
                whereQueries.Add(AddWhereQuery(prodID, productIdColumnName));
                quiered = true;
            }
            if(prodName != "")
            {
                whereQueries.Add(AddWhereQuery(prodName, productNameColumnName));
                quiered = true;
            }
            if(price != "")
            {
                whereQueries.Add(AddWhereQuery(price, priceColumnName));
                quiered = true;
            }
            if(prodWeight != "")
            {
                whereQueries.Add(AddWhereQuery(prodWeight, prodWeightColumnName));
                quiered = true;
            }
            if(inStock != "")
            {
                whereQueries.Add(AddWhereQuery(inStock, inStockColumnName));
                quiered = true;
            }
        }

        //Adrian Added Function. makes a Where query.
        //Might not work not tested. Might need [ORDER] in here..... not sure.
        public string AddWhereQuery(string value, string columnName)
        {
            return "[Product]." + columnName + "='" + value + "'";
        }

        public string SQLInsert()
        {
            return "INSERT INTO " + tableName + " ([ProdName], [Price], [ProdWeight], [InStock]) VALUES ('" + prodName + "', '" + price + "', '" + prodWeight + "', '" + inStock + "');";
        }

        public string SQLUpdate()
        {
            string query = "UPDATE " + tableName + " SET ";

            if(prodName != ""){
                query += productNameColumnName + "='" + prodName + "', ";
            }
            if(price != ""){
                query += priceColumnName + "='" + price + "', ";
            }
            if(prodWeight != ""){
                query += prodWeightColumnName + "='" + prodWeight + "', ";
            }
            if(inStock != ""){
                query += inStockColumnName + "='" + inStock + "', ";
            }

            query = query.Substring(0, query.LastIndexOf(",")) + query.Substring(query.LastIndexOf(",") + 1);

            query += "WHERE " + productIdColumnName + "='" + prodID + "';";

            return query;
        }

        public string SQLDelete()
        {
            string query = "";
            query += "DELETE FROM [Cart] WHERE [ProdID]=" + prodID + ";";
            query += "DELETE FROM [Product] WHERE [ProdID]=" + prodID + ";";
            return query;
        }

        public bool validateInput()
        {
            if (!Validator.ValidateInt(prodID) && prodID != "")
            {
                return false;
            }
            if (!Validator.ValidateVarchar(prodName, 100) || prodName == "")
            {
                return false;
            }
            if (!Validator.ValidateFloat(price))
            {
                return false;
            }
            if (!Validator.ValidateFloat(prodWeight))
            {
                return false;
            }
            if (!Validator.ValidateBool(inStock))
            {
                return false;
            }
            return true;
        }

        public bool validateInput(bool blankIsValid)
        {
            if (!Validator.ValidateInt(prodID) && prodID != "")
            {
                return false;
            }
            if (!Validator.ValidateVarchar(prodName, 100) && prodName != "")
            {
                return false;
            }
            if (!Validator.ValidateFloat(price) && price != "")
            {
                return false;
            }
            if (!Validator.ValidateFloat(prodWeight) && prodWeight != "")
            {
                return false;
            }
            if (!Validator.ValidateBool(inStock) && inStock != "")
            {
                return false;
            }
            return true;
        }

        //Adrian changes get value of orderQuiery
        public int WasProductQuiered()
        {
            if(quiered)
            {
                return QUIERED_VALUE;
            }

            return 0;
        }
    }
    
}