using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CrazyMelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : CrazyMel
    {       
        //4 inserts, one for each table. in each, check data, if valid data connect to DB,insert data to db 
        public bool InsertCustomer(string FirstName, string LastName, string PhoneNumber)
        {
            Customer c = new Customer(FirstName, LastName, PhoneNumber);

            return true;
        }

        public bool InsertProduct(string ProductName, string Price, string ProdWeight, string InStock)
        {
            return true;
        }

        public bool InsertOrder(string CustID, string PoNumber, string OrderDate)
        {
            return true;
        }

        public bool InsertCart(string OrderID, string ProdID, string Quantity)
        {
            return true;
        }

        //UPDATES

        public bool UpdateCustomer(string CustID, string FirstName, string LastName, string PhoneNumber)
        {
            
            return true;
        }

        public bool UpdateProduct(string ProdID, string ProductName, string Price, string ProdWeight, string InStock)
        {
            return true;
        }

        public bool UpdateOrder(string OrderID, string CustID, string PoNumber, string OrderDate)
        {
            return true;
        }

        public bool UpdateCart(string OrderID, string ProdID, string Quantity)
        {
            return true;
        }
    }
}
