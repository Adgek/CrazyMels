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
        private string tableName { get; set; }
        private string productIdColumnName { get; set; }
        private string productNameColumnName { get; set; }
        private string priceColumnName { get; set; }
        private string prodWeightColumnName { get; set; }
        private string inStockColumnName { get; set; }  

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
    
    
        public Product() 
        {
            tableName = "[Product]";
            productIdColumnName = "[ProdId]";
            productNameColumnName = "[ProdName]";
            priceColumnName = "[Price]";
            prodWeightColumnName = "[ProdWeight]";
            inStockColumnName = "[InStock]";
        }

        public Product(string ProductName, string Price, string ProdWeight, string InStock, string ProductId = "") : this()
        {
            prodID = ProductId;
            prodName = ProductName;
            price = Price;
            prodWeight = ProdWeight;
            inStock = InStock;
        }

        public string SQLInsert()
        {
            return "INSERT INTO " + tableName + " VALUES ('" + prodName + "', '" + price + "', '" + prodWeight + "', '" + inStock + "');";
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
            query += "DELETE FROM [Cart] WHERE [Cart].OrderID=(SELECT [ProdID] FROM [Order] WHERE [ProdID]=" + prodID + ");";
            query += "DELETE FROM [Order] WHERE [ProdID]=" + prodID + ";";
            query += "DELETE FROM [Product] WHERE [ProdID]=" + prodID + ";";
            return query;
        }

        public bool validateInput()
        {
            if (!Validator.ValidateInt(prodID) && prodID != "")
            {
                return false;
            }
            if (!Validator.ValidateVarchar(prodName, 100))
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
    }
    
}