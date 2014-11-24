using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soa4.Models
{
    public class PO
    {
        public PO()
        {
            products = new List<string>();
        }
        public string custID;
        public string firstname;
        public string lastname;
        public string phoneNumber;
        public string prodid;
        public string prodname;
        public string price;
        public string prodweight;
        public string instock;
        public string orderid;
        public string ponumber;
        public string orderdate;
        public string quantity;

        public List<string> products;
    }
}