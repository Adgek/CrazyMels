using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Soa4
{
    public partial class tableOutput : System.Web.UI.Page
    {
        List<string> headers = new List<string>();
        List<string> rows = new List<string>();

        /// <summary>
        /// handle displaying response data to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            string response = (string)Session["serviceResponse"];
            if (response ==  null)
            {
                Response.Redirect("inputForm.aspx", true);
            }
            response = response.Replace("<string xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">", "<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.LoadXml(response);
            XmlNodeList xnList = xml.SelectNodes("/response/row");
            GetHeaders(xml);
            PrintHeaders();
            GetRows(xml);
            PrintRows();
        }


        private void GetHeaders(XmlDocument xml)
        {
            XmlNodeList xnList = xml.SelectNodes("/response/row");

            XmlNode Headers = xnList[0];

            foreach (System.Xml.XmlElement a in Headers)
            {
                headers.Add(a.InnerText);
            }
        }

                
            
        private void PrintHeaders()
        {
            outputTab.InnerHtml += "<table class=\"table table-hover table-bordered\" >";
            outputTab.InnerHtml += "<thead>";
            outputTab.InnerHtml += "<tr>";
            foreach(string header in headers)
            {
                outputTab.InnerHtml += "<th>" + header +"</th>";
            }
            outputTab.InnerHtml += "</tr>";
            outputTab.InnerHtml += "</thead>";
        }

        private void GetRows(XmlDocument xml)
        {
            XmlNodeList xnList = xml.SelectNodes("/response/row");
            Boolean doneFirstRow = false;
            foreach (XmlNode xn in xnList)
            {
                if(!doneFirstRow)
                {
                    doneFirstRow = true;
                }
                else
                {
                    foreach(XmlNode node in xn)
                    {
                        rows.Add(node.InnerText);
                    }
                }
            }
        }

        private void PrintRows()
        {
            outputTab.InnerHtml += "<tbody>";
            int count = 0;
            foreach(String row in rows)
            {
                if(count == 0)
                {
                    outputTab.InnerHtml += "<tr>";
                }
                outputTab.InnerHtml += "<th>" + row + "</th>";
                count++;
                if(count >= headers.Count)
                {
                    count = 0;
                    outputTab.InnerHtml += "</tr>";
                }

            }
            outputTab.InnerHtml += "</tbody> </table>";
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {

        }

        //<thead>
        //    <tr>
        //        <th>ID</th>
        //        <th>Product Name</th>
        //        <th>Quantity</th>
        //        <th>Unit Price</th>
        //        <th>Unit Weight</th>
        //    </tr>
        //</thead>
    }
}