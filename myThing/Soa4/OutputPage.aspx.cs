using Soa4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Soa4
{
    public partial class OutputPage : System.Web.UI.Page
    {
        List<PO> orders = new List<PO>();
        List<PO> finalList = new List<PO>();
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            string response = (string)Session["serviceResponse"];
            if (response == null)
            {
                Response.Redirect("inputForm.aspx", true);
            }
            response = response.Replace("<string xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">", "<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.LoadXml(response);
            XmlNodeList xnList = xml.SelectNodes("/response/row");
            ParseOrders(xnList);

            SortOutOrders();
            GeneratePOPanels();
        }

        private void SortOutOrders()
        {
            IEnumerable<string> ids = orders.Select(x => x.ponumber).Distinct();
            PO purchase = new PO();
            foreach (string id in ids)
            {
                purchase = new PO();
                purchase = orders.Where(p => p.ponumber == id).FirstOrDefault();
                IEnumerable<PO> products = orders.Where(p => p.ponumber == id);
                foreach (PO p in products)
                {
                    purchase.products.Add(p.prodid + "," + p.prodname + "," + p.quantity + "," + p.price + "," + p.prodweight + "," + p.instock);
                }
                finalList.Add(purchase);
            }
        }

        private void GeneratePOPanels()
        {
            foreach (PO p in finalList)
            {
                POArea.InnerHtml += "<div class=\"panel panel-default\">" + "<div class=\"panel-body\">";

                POArea.InnerHtml += "<div class=\"row\">";
                POArea.InnerHtml += "<div class=\"col-md-3\">";
                POArea.InnerHtml += "<asp:Label runat=\"server\">Customer Information</asp:Label>";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "<div class=\"col-md-6\">";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "<div class=\"col-md-3\">";
                POArea.InnerHtml += "<asp:Label runat=\"server\">Purchase Date : " + p.orderdate + " </asp:Label>";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "</div>";

                POArea.InnerHtml += "<div class=\"row\">";
                POArea.InnerHtml += "<div class=\"col-md-3\">";
                POArea.InnerHtml += "<asp:Label runat=\"server\">ID : " + p.custID + "</asp:Label>";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "<div class=\"col-md-6\">";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "<div class=\"col-md-3\">";
                POArea.InnerHtml += "<asp:Label runat=\"server\"></asp:Label>";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "</div> ";

                POArea.InnerHtml += "<div class=\"row\">";
                POArea.InnerHtml += "<div class=\"col-md-3\">";
                POArea.InnerHtml += "<asp:Label runat=\"server\">Name : " + p.lastname + ", " + p.firstname + "</asp:Label>";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "<div class=\"col-md-6\">";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "<div class=\"col-md-3\">";
                POArea.InnerHtml += "<asp:Label runat=\"server\"> P.O. Number : " + p.ponumber + "</asp:Label>";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "</div>";

                POArea.InnerHtml += "<div class=\"row\">";
                POArea.InnerHtml += "<div class=\"col-md-3\">";
                POArea.InnerHtml += "<asp:Label runat=\"server\">Phone : " + p.phoneNumber + "</asp:Label>";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "<div class=\"col-md-6\">";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "<div class=\"col-md-3\">";
                POArea.InnerHtml += "<asp:Label runat=\"server\"></asp:Label>";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "</div>";

                POArea.InnerHtml += "<div class=\"row\">";
                POArea.InnerHtml += "<div class=\"col-md-2\">";
                POArea.InnerHtml += "</div>";

                POArea.InnerHtml += "<div class=\"col-md-8\">";

                POArea.InnerHtml += "<div class=\"table-responsive\">";
                POArea.InnerHtml += "<table class=\"table table-hover table-bordered\">";
                POArea.InnerHtml += "<thead>";
                POArea.InnerHtml += "<tr>";
                POArea.InnerHtml += "<th>ID</th>";
                POArea.InnerHtml += "<th>Product Name</th>";
                POArea.InnerHtml += "<th>Quantity</th>";
                POArea.InnerHtml += "<th>Unit Price</th>";
                POArea.InnerHtml += "<th>Unit Weight</th>";
                POArea.InnerHtml += "<th>In Stock</th>";
                POArea.InnerHtml += "</tr>";
                POArea.InnerHtml += "</thead>";
                POArea.InnerHtml += "<tbody>";
                foreach (string s in p.products)
                {
                    string[] split = s.Split(',');
                    POArea.InnerHtml += "<tr>";
                    foreach (string sp in split)
                    {
                        POArea.InnerHtml += "<td>" + sp + "</td>";
                    }
                    POArea.InnerHtml += "</tr>";
                }
                POArea.InnerHtml += "<tr>";
                POArea.InnerHtml += "<td></td>";
                POArea.InnerHtml += "<td></td>";
                POArea.InnerHtml += "<td></td>";
                POArea.InnerHtml += "<td>SubTotal</td>";
                POArea.InnerHtml += "<td>1000</td>";
                POArea.InnerHtml += "</tr>";
                POArea.InnerHtml += "<tr>";
                POArea.InnerHtml += "<td></td>";
                POArea.InnerHtml += "<td></td>";
                POArea.InnerHtml += "<td></td>";
                POArea.InnerHtml += "<td>Tax (13%)</td>";
                POArea.InnerHtml += "<td>25</td>";
                POArea.InnerHtml += "</tr>";
                POArea.InnerHtml += "<tr>";
                POArea.InnerHtml += "<td></td>";
                POArea.InnerHtml += "<td></td>";
                POArea.InnerHtml += "<td></td>";
                POArea.InnerHtml += "<td>Total</td>";
                POArea.InnerHtml += "<td>1025</td>";
                POArea.InnerHtml += "</tr>";

                POArea.InnerHtml += "</tbody>";
                POArea.InnerHtml += "</table>";
                POArea.InnerHtml += "</div>";

                POArea.InnerHtml += "</div>";

                POArea.InnerHtml += "<div class=\"col-md-2\">";
                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "</div>";

                POArea.InnerHtml += "</div>";
                POArea.InnerHtml += "</div>";

            }
        }

        private void ParseOrders(XmlNodeList xnList)
        {

            PO purchaseOrder = new PO();
            foreach (XmlNode xn in xnList)
            {
                int count = 0;

                purchaseOrder = new PO();
                foreach (XmlNode node in xn)
                {
                    count++;
                    switch (count)
                    {
                        case 1:
                            purchaseOrder.custID = node.InnerText;
                            break;
                        case 2:
                            purchaseOrder.firstname = node.InnerText;
                            break;
                        case 3:
                            purchaseOrder.lastname = node.InnerText;
                            break;
                        case 4:
                            purchaseOrder.phoneNumber = node.InnerText;
                            break;
                        case 5:
                            purchaseOrder.prodid = node.InnerText;
                            break;
                        case 6:
                            purchaseOrder.prodname = node.InnerText;
                            break;
                        case 7:
                            purchaseOrder.price = node.InnerText;
                            break;
                        case 8:
                            purchaseOrder.prodweight = node.InnerText;
                            break;
                        case 9:
                            purchaseOrder.instock = node.InnerText;
                            break;
                        case 10:
                            purchaseOrder.orderid = node.InnerText;
                            break;
                        case 11:
                            purchaseOrder.ponumber = node.InnerText;
                            break;
                        case 12:
                            purchaseOrder.orderdate = node.InnerText;
                            break;
                        case 13:
                            purchaseOrder.quantity = node.InnerText;
                            break;
                    }
                }
                orders.Add(purchaseOrder);
            }
        }
    }
}