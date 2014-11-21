using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Soa4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            redirectToPage("search");
        }

        private void redirectToPage(string action)
        {
            Session["firstPageAction"] = action;
            Server.Transfer("inputForm.aspx", true);
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            redirectToPage("insert");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            redirectToPage("update");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            redirectToPage("delete");
        }

        protected void leaveBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.google.com");
        }
    }
}