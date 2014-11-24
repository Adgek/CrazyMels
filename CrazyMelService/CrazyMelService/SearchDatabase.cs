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
        public string SearchPo(string po)
        {
            //Get Order table from po number
            //Get all Carts related to OrderID
                //foreach Cart get product that was in cart by cartID
            //Get CustomerID from CustID related to Order
            return "success string";
        }
        public string Search()
        {
            if (!ValidateSearchFields())
            {
                return "Some error message here back to UI";
            }

            //get combination of Search
            int useCaseValue = customer.WasCustomerQuiered() + product.WasProductQuiered() + order.WasOrderQuiered() + cart.WasCartQuiered();

            //If statement on value to determine usecase
            switch (useCaseValue)
            {
                case 0://The users a tool
                    return "The user didnt search any fields";
                case 1://Customer Table
                    return searchCustomers();
                    break;
                case 2://Product Table
                    return searchProducts();
                    break;
                case 4://Order Table
                    return searchOrders();
                    break;
                case 5://Customers and orders
                    return searchCustomersOrders();
                    break;
                case 6://Products and orders
                    return searchProductsInCustomersOrders();
                    break;
                case 8://Cart Table
                    return searchCarts();
                    break;
                case 9://Carts and Customers
                    return searchCustomersOrdersQuantities();
                    break;
                case 10://Carts and Products
                    return searchProductQuantities();
                    break;
                case 12://Carts and Orders
                    return searchCartsinOrders();
                    break;
                case 13://Carts, Orders, and Customers
                    return searchCustomersQuantitiesInSpecificOrders();
                    break;
                case 14://Carts, Orders, and Products
                    return searchProductsQuantitiesInSpecificOrders();
                    break;

                default:
                    return "I screwed up the math dudes sorry lol";
                    break;
            }
        }

        public bool ValidateSearchFields()
        {
            bool IGNORE_BLANK_ENTRIES_FOR_VALIDATION = true;//This might be bad code Kyle/Matt. Kinda smells to have overloaded method just to share same name? I unno lol
                                                            //Maybe make the bool mean something and have both functions in one on an if statement. might be better.
            //validate user input
            if (!customer.validateInput(IGNORE_BLANK_ENTRIES_FOR_VALIDATION)) { return false; }
            if (!product.validateInput(IGNORE_BLANK_ENTRIES_FOR_VALIDATION)) { return false; }
            if (!order.validateInput(IGNORE_BLANK_ENTRIES_FOR_VALIDATION)) { return false; }
            if (!cart.validateInput(IGNORE_BLANK_ENTRIES_FOR_VALIDATION)) { return false; }
            return true;
        }




        //This is where i started Pseudocoding. Hope its easy to code. getting a bit late lol
        //***********************************
        // If this works fine i'm sure there is a better pattern here to make it 
        //more efficient and better coding. We can discuse that later Tommorrow
        //unless you see something i dont which is quick and easy. I'm noticing alot of 
        //repitition in my psuedocode of Inner joins and the Foreach's of certain tables.
        //************************************
        //Good Luck and Keep me in the loop tommorrow. The games at one till 4 then dinner after so I will be at Kyles at night.:)
        public string searchCustomers()
        {
            //Select *
                //FOREACH value in customer.whereQueries to print out where statements
            return "success Return Goes here";   
        }

        public string searchProducts()
        {  
            //Select *
                //FOREACH value in products.whereQueries to print out where statements
            return "success Return Goes here";   
        }

        public string searchOrders()
        {
            //Select *
                //FOREACH value in Orders.whereQueries to print out where statements
            return "success Return Goes here";   
        }

        public string searchCustomersOrders()
        {
            //Select *
                //Inner Join Customers and Orders
                //FOREACH value in customer.whereQueries
                //FOREACH value in Orders.whereQueries
            return "success Return Goes here";   
        }

        public string searchProductsInCustomersOrders()
        {
            //Select *
                //Inner Join Orders, Products, Carts and Customers
                    // Carts for linking is not displayed
                    // Customers because of our ID Rule is displayed
                //FOREACH value in products.whereQueries
                //FOREACH value in Orders.whereQueries
            return "success Return Goes here";   
        }

        public string searchCarts()
        {
            //Select *
                //FOREACH value in Carts.whereQueries to print out where statements
            return "success Return Goes here";   
        }

        //This one is funky might be too tired to think straight...lol
        public string searchCustomersOrdersQuantities()
        {
            //Select *
                //Inner Join Customers Orders Carts and Products 
                    // Orders because of our OrderID rule
                    // Products because of our prodID rule
                //FOREACH value in customer.whereQueries
                //FOREACH value in Carts.whereQueries
            return "success Return Goes here";   
        }

        public string searchProductQuantities()
        {
            //Select *
                //Inner Join Products and Carts
                //FOREACH value in products.whereQueries
                //FOREACH value in Carts.whereQueries
            return "success Return Goes here";
        }

        public string searchCartsinOrders()
        {
            //Select *
                //Inner Join Orders and Carts
                //FOREACH value in Orders.whereQueries
                //FOREACH value in Carts.whereQueries
            return "success Return Goes here";   
        }

        public string searchCustomersQuantitiesInSpecificOrders()
        {
            //Select *
                //Inner Join Customers, Orders, Carts and Products
                    //Products because of prodID rule
                //FOREACH value in customer.whereQueries
                //FOREACH value in Orders.whereQueries
                //FOREACH value in Carts.whereQueries
            return "success Return Goes here";   
        }

        public string searchProductsQuantitiesInSpecificOrders()
        {
            //Select *
                //Inner Join Products, Orders, Carts and Customers
                    //Customers because of custID rule
                //FOREACH value in product.whereQueries
                //FOREACH value in Orders.whereQueries
                //FOREACH value in Carts.whereQueries
            return "success Return Goes here";   
        }


    }
}