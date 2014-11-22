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

            if (classType == "Customer")
            {
                string custID = nodes.Item(0).SelectSingleNode("CustID").InnerText;
                string firstName = nodes.Item(0).SelectSingleNode("FirstName").InnerText;
                string lastName = nodes.Item(0).SelectSingleNode("LastName").InnerText;
                string phoneNumber = nodes.Item(0).SelectSingleNode("PhoneNumber").InnerText;                
                
                obj = new Customer(firstName, lastName, phoneNumber, custID);
            }

            if (classType == "Product")
            {
                string prodID = nodes.Item(0).SelectSingleNode("ProdID").InnerText;
                string prodName = nodes.Item(0).SelectSingleNode("ProductName").InnerText;
                string price = nodes.Item(0).SelectSingleNode("Price").InnerText;
                string prodWeight = nodes.Item(0).SelectSingleNode("ProdWeight").InnerText;
                string inStock = nodes.Item(0).SelectSingleNode("InStock").InnerText;

                obj = new Product(prodName, price, prodWeight, inStock, prodID);
            }

            if (classType == "Order")
            {
                string orderID = nodes.Item(0).SelectSingleNode("OrderID").InnerText;
                string custID = nodes.Item(0).SelectSingleNode("CustID").InnerText;
                string poNumber = nodes.Item(0).SelectSingleNode("PoNumber").InnerText;
                string orderDate = nodes.Item(0).SelectSingleNode("OrderDate").InnerText;

                obj = new Order(orderID, custID, poNumber, orderDate);
            }

            if (classType == "Cart")
            {
                string orderID = nodes.Item(0).SelectSingleNode("OrderID").InnerText;
                string prodID = nodes.Item(0).SelectSingleNode("ProdID").InnerText;
                string quantity = nodes.Item(0).SelectSingleNode("Quantity").InnerText;

                obj = new Cart(orderID, prodID, quantity);
            } 
            

            return obj;
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