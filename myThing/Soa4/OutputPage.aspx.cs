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
        }
    }
}