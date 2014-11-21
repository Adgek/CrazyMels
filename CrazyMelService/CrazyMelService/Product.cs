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
        public string productId { get; set; }
        [DataMember]
        public string productName { get; set; }
        [DataMember]
        public string price { get; set; }
        [DataMember]
        public string prodWeight { get; set; }
        [DataMember]
        public string inStock { get; set; }
    
    
        public Product() 
        {
            tableName = "[Product]";
            productIdColumnName = "[ProductId]";
            productNameColumnName = "[ProductName]";
            priceColumnName = "[Price]";
            prodWeightColumnName = "[ProdWeight]";
            inStockColumnName = "[InStock]";
        }

        public Product(string ProductName, string Price, string ProdWeight, string InStock, string ProductId = "") : this()
        {
            productId = ProductId;
            productName = ProductName;
            price = Price;
            prodWeight = ProdWeight;
            inStock = InStock;
        }

        public string SQLInsert()
        {
            return "INSERT INTO " + tableName + " VALUES ('" + productName + "', '" + price + "', '" + prodWeight + "', '" + inStock + "');";
        }

        public string SQLUpdate()
        {
            string query = "UPDATE " + tableName + " SET ";

            if(productName != ""){
                query += productNameColumnName + "='" + productName + "', ";
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

            query += "WHERE " + productIdColumnName + "='" + productId + "';";

            return query;
        }

        public string SQLDelete()
        {
            return "DELETE FROM  " + tableName + " WHERE " + productIdColumnName + "='" + productId + "');";
        }
    }
    
}