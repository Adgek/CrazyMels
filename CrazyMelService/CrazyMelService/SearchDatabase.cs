using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrazyMelService
{
    public class SearchDatabase
    {
        Customer customer;
        Product product;
        Order order;
        Cart cart;

        List<Customer> customerList;
        List<Product> productList;
        List<Order> orderList;
        List<Cart> cartList;

        public SearchDatabase()
        {
            customerList = new List<Customer>();
            productList = new List<Product>();
            orderList = new List<Order>();
            cartList = new List<Cart>();
        }
        public SearchDatabase(string c, string p, string o, string ca)
            : this()
        {
            char delimiter = ',';
            customer = new Customer(c, delimiter);
            product = new Product(c, delimiter);
            order = new Order(c, delimiter);
            cart = new Cart(c, delimiter);
        }
        public string Search()
        {
            return "";
        }


    }
}