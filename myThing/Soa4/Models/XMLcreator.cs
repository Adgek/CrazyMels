using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soa4.Models
{
    public class XMLcreator
    {
        public string CreateXMLSingle(Dictionary<string, string> info, string type)
        {
            string xml = "<Object>" + Environment.NewLine +
                         "<Type>" + type + "</Type>" + Environment.NewLine;
            foreach(KeyValuePair<string,string> kvp in info)
            {
                xml += "<" + kvp.Key + ">" + kvp.Value + "</" + kvp.Key + ">" + Environment.NewLine;
            }
            xml+= "</Object>";

            return xml;
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