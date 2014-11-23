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
        public SearchDatabase(Customer c, Product p, Order o, Cart ca) : this()
        {
            customer = c;
            product = p;
            order = o;
            cart = ca;
        }


    }
}