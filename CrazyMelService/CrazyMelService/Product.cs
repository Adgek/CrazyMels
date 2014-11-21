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
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public float ProdWeight { get; set; }
        [DataMember]
        public bool InStock { get; set; }
    }

    public partial class Products
    {
        private static readonly Products _instance = new Products();
        private Products() { }
        public static Products Instance
        {
            get { return _instance; }
        }
        public List<Product> ProductList
        {
            get { return products; }
        }
        private List<Product> products = new List<Product>() 
        { 
        };
    }
}