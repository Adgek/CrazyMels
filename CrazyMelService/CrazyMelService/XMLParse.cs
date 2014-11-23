using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace CrazyMelService
{
    public static class XMLParse
    {
        public static Object ParseXML(string XMLString)
        {
            Object obj = null;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLString);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Object");

            string classType = nodes.Item(0).SelectSingleNode("Type").InnerText;

            if (String.Equals(classType, "Customer", StringComparison.InvariantCultureIgnoreCase))
            {
                string custID = GetNodeData(nodes.Item(0), "CustID");
                string firstName = GetNodeData(nodes.Item(0), "FirstName");
                string lastName = GetNodeData(nodes.Item(0), "LastName");
                string phoneNumber = GetNodeData(nodes.Item(0), "PhoneNumber");                
                
                obj = new Customer(firstName, lastName, phoneNumber, custID);
            }

            if (String.Equals(classType, "Product", StringComparison.InvariantCultureIgnoreCase))
            {
                string prodID = GetNodeData(nodes.Item(0), "ProdID"); 
                string prodName = GetNodeData(nodes.Item(0), "ProductName"); 
                string price = GetNodeData(nodes.Item(0), "Price"); 
                string prodWeight = GetNodeData(nodes.Item(0), "ProdWeight"); 
                string inStock = GetNodeData(nodes.Item(0), "InStock");

                obj = new Product(prodName, price, prodWeight, inStock, prodID);
            }

            if (String.Equals(classType, "Order", StringComparison.InvariantCultureIgnoreCase))
            {
                string orderID = GetNodeData(nodes.Item(0), "OrderID"); 
                string custID = GetNodeData(nodes.Item(0), "CustID"); 
                string poNumber = GetNodeData(nodes.Item(0), "PoNumber"); 
                string orderDate = GetNodeData(nodes.Item(0), "OrderDate");

                obj = new Order(orderID, custID, poNumber, orderDate);
            }

            if (String.Equals(classType, "Cart", StringComparison.InvariantCultureIgnoreCase))
            {
                string orderID = nodes.Item(0).SelectSingleNode("OrderID").InnerText;
                string prodID = nodes.Item(0).SelectSingleNode("ProdID").InnerText;
                string quantity = nodes.Item(0).SelectSingleNode("Quantity").InnerText;

                obj = new Cart(orderID, prodID, quantity);
            } 
            

            return obj;
        }

        private static string GetNodeData(XmlNode node, string columnName)
        {
            string result = "";

            try
            {
                result = node.SelectSingleNode(columnName).InnerText;
            }
            catch (Exception e)
            {
                return "";
            }

            return result;
        }
    }
}

/*

<Object>
  <Type>Customer</Type>
  <CustID>1</CustID>
  <FirstName>matt</FirstName>
  <LastName>anselmo</LastName>
  <PhoneNumber>2267501111</PhoneNumber>  
</Object>

<Object>
  <Type>Product</Type>
  <ProdID>1</ProdID>
  <ProdName>banana</ProdName>
  <Price>1.9</Price>
  <ProdWeight>.1</ProdWeight>
  <InStock>1</InStock>
</Object>

<Object>
  <Type>Order</Type>
  <OrderID>1</OrderID>
  <CustID>1</CustID>
  <PoNumber>asdasdasdasd</PoNumber>
  <OrderDate>01-01-1999</OrderDate>
</Object>

<Object>
  <Type>Cart</Type>
  <OrderID>1</OrderID>
  <ProdID>matt</ProdID>
  <Quantity>anselmo</Quantity>  
</Object>

*/