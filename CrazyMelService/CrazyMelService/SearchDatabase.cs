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

        public List<string> searchColumns;

        public SearchDatabase()
        {
            customerList = new List<Customer>();
            productList = new List<Product>();
            orderList = new List<Order>();
            cartList = new List<Cart>();

            searchColumns = new List<string>();
        }
        public SearchDatabase(string c, string p, string o, string ca) : this()
        {
            char delimiter = ',';
            customer = new Customer(c, delimiter);
            product = new Product(p, delimiter);
            order = new Order(o, delimiter);
            cart = new Cart(ca, delimiter);
        }
        public string SearchPo(string po)
        {
            //Get Order table from po number
            //Get all Carts related to OrderID
                //foreach Cart get product that was in cart by cartID
            //Get CustomerID from CustID related to Order
            string query = @" SELECT [Order].OrderID, [Order].OrderDate, [Order].PoNumber, [Customer].CustID, [Customer].FirstName, [Customer].LastName, [Customer].PhoneNumber, [Product].ProdID, [Product].ProdName, [Product].Price, [Product].ProdWeight, [Product].InStock, [Cart].Quantity  FROM [Order] 
  INNER JOIN [Customer] ON [Customer].CustID=[Order].CustID
  INNER JOIN [Cart] ON [Cart].OrderID=[Order].OrderID
  INNER JOIN [Product] ON [Product].ProdID=[Cart].ProdID
  WHERE [Order].PoNumber='" + po + "'";
            
            return query;   
           
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
            bool IGNORE_BLANK_ENTRIES_FOR_VALIDATION = true;

            if (!customer.validateInput(IGNORE_BLANK_ENTRIES_FOR_VALIDATION)) { return false; }
            if (!product.validateInput(IGNORE_BLANK_ENTRIES_FOR_VALIDATION)) { return false; }
            if (!order.validateInput(IGNORE_BLANK_ENTRIES_FOR_VALIDATION)) { return false; }
            if (!cart.validateInput(IGNORE_BLANK_ENTRIES_FOR_VALIDATION)) { return false; }
            return true;
        }

        public string searchCustomers()
        {
            AddCustomerColumnNames();

            string query = "SELECT * FROM [Customer] ";
            query += GetWheres();

            return query;   
        }

        
        public string searchProducts()
        {
            AddProductColumnNames();

            string query = "SELECT * FROM [Product] ";

            query += GetWheres();

            return query;     
        }

        

        public string searchOrders()
        {
            AddOrderColumnNames();

            string query = "SELECT * FROM [Order] ";
            query += GetWheres();

            return query;    
        }

        

        public string searchCustomersOrders()
        {
            AddCustomerColumnNames();
            AddOrderColumnNames();

            string query = "SELECT * FROM [Customer] INNER JOIN [Order] ON [Customer].[CustID]=[Order].[CustID] ";

            query += GetWheres();
            return query;   
        }
                
        public string searchProductsInCustomersOrders()
        {
            AddProductColumnNames();
            AddOrderColumnNames();

            string query = "SELECT [Product].ProdID, [Product].ProdName, [Product].Price, [Product].ProdWeight, [Product].InStock, [Order].OrderID, [Order].CustID, [Order].PoNumber, [Order].OrderDate, [Customer].CustID, [Customer].FirstName, [Customer].LastName, [Customer].PhoneNumber FROM [Product]";
            query += " INNER JOIN [Cart] ON [Cart].ProdID=[Product].ProdID";
            query += " INNER JOIN [Order] ON [Order].OrderID=[Cart].OrderID ";
            query += " INNER JOIN [Customer] ON [Customer].CustID=[Order].CustID ";                    

            query += GetWheres();
            
            return query;      
        }
        
        public string searchCarts()
        {
            AddCartColumnNames();

            string query = "SELECT * FROM [Cart] ";
            
            query += GetWheres();
        
            return query;   
        }

        //This one is funky might be too tired to think straight...lol
        public string searchCustomersOrdersQuantities()
        {
            AddCustomerColumnNames();
            AddCartColumnNames();

            string query = "SELECT [Customer].CustID, [Customer].FirstName, [Customer].LastName, [Customer].PhoneNumber, [Cart].OrderID, [Cart].ProdID, [Cart].Quantity, [Product].ProdID, [Product].ProdName, [Product].Price, [Product].ProdWeight, [Product].InStock FROM [Customer]";
            query += " INNER JOIN [Order] ON [Order].CustID=[Customer].CustID";
            query += " INNER JOIN [Cart] ON [Cart].OrderID=[Order].OrderID";
            query += " INNER JOIN [Product] ON [Product].ProdID=[Cart].ProdID ";

            query += GetWheres();
            return query;      
        }

        public string searchProductQuantities()
        {
            AddProductColumnNames();
            AddCartColumnNames();

            string query = "SELECT * FROM [Product]";
            query += " INNER JOIN [Cart] ON [Cart].ProdID=[Product].ProdID ";           

            query += GetWheres();
            return query;      
        }

        public string searchCartsinOrders()
        {
            AddOrderColumnNames();
            AddCartColumnNames();

            string query = "SELECT * FROM [Order]";
            query += " INNER JOIN [Cart] ON [Cart].OrderID=[Order].OrderID ";

            query += GetWheres();
            return query;    
        }

        public string searchCustomersQuantitiesInSpecificOrders()
        {
            AddCustomerColumnNames();
            AddOrderColumnNames();
            AddCartColumnNames();

            string query = "SELECT [Customer].CustID, [Customer].FirstName, [Customer].LastName, [Customer].PhoneNumber, [Order].OrderID, [Order].CustID, [Order].PoNumber, [Order].OrderDate, [Cart].OrderID, [Cart].ProdID, [Cart].Quantity, [Product].ProdID, [Product].ProdName, [Product].Price, [Product].ProdWeight, [Product].InStock FROM [Customer]";
            query += " INNER JOIN [Order] ON [Order].CustID=[Customer].CustID";
            query += " INNER JOIN [Cart] ON [Cart].OrderID=[Order].OrderID";
            query += " INNER JOIN [Product] ON [Product].ProdID=[Cart].ProdID ";

            query += GetWheres();
            return query;       
        }

        public string searchProductsQuantitiesInSpecificOrders()
        {
            AddProductColumnNames();
            AddOrderColumnNames();
            AddCartColumnNames();

            string query = "SELECT [Product].ProdID, [Product].ProdName, [Product].Price, [Product].ProdWeight, [Product].InStock, [Order].OrderID, [Order].CustID, [Order].PoNumber, [Order].OrderDate, [Cart].OrderID, [Cart].ProdID, [Cart].Quantity, [Customer].CustID, [Customer].FirstName, [Customer].LastName, [Customer].PhoneNumber FROM [Product]";
            query += " INNER JOIN [Cart] ON [Cart].ProdID=[Product].ProdID";
            query += " INNER JOIN [Order] ON [Order].OrderID=[Cart].OrderID";
            query += " INNER JOIN [Customer] ON [Customer].CustID=[Order].CustID";

            query += GetWheres();
            return query;
        }

        private string GetWheres()
        {
            string query = "WHERE ";
            foreach (string item in customer.whereQueries)
            {
                query += item + " AND ";
            }
            foreach (string item in product.whereQueries)
            {
                query += item + " AND ";
            }
            foreach (string item in order.whereQueries)
            {
                query += item + " AND ";
            }
            foreach (string item in cart.whereQueries)
            {
                query += item + " AND ";
            }
            query = query.Substring(0, query.LastIndexOf(" AND ")) + query.Substring(query.LastIndexOf(" AND ") + 5);
            query += ";";

            return query;
        }

        private void AddCustomerColumnNames()
        {
            searchColumns.Add(customer.custIDColumnName);
            searchColumns.Add(customer.firstNameColumnName);
            searchColumns.Add(customer.lastNameColumnName);
            searchColumns.Add(customer.phoneNumberColumnName);
        }

        private void AddProductColumnNames()
        {
            searchColumns.Add(product.productIdColumnName);
            searchColumns.Add(product.productNameColumnName);
            searchColumns.Add(product.priceColumnName);
            searchColumns.Add(product.prodWeightColumnName);
            searchColumns.Add(product.inStockColumnName);
        }

        private void AddOrderColumnNames()
        {
            searchColumns.Add(order.orderIDColumnName);
            searchColumns.Add(order.custIDColumnName);
            searchColumns.Add(order.poNumberColumnName);
            searchColumns.Add(order.orderDateColumnName);
        }

        private void AddCartColumnNames()
        {
            searchColumns.Add(cart.orderIDColumnName);
            searchColumns.Add(cart.prodIDColumnName);
            searchColumns.Add(cart.quantityColumnName);
        }
    }
}