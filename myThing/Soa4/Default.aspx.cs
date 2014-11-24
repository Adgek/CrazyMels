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

        /// <summary>
        /// search button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            redirectToPage("search");
        }

        /// <summary>
        /// handle redirecting to another page
        /// </summary>
        /// <param name="action"></param>
        private void redirectToPage(string action)
        {
            Session["firstPageAction"] = action;
           Response.Redirect("inputForm.aspx", true);
        }

        /// <summary>
        /// insert button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void insertBtn_Click(object sender, EventArgs e)
        {
            redirectToPage("insert");
        }

        /// <summary>
        /// update button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void updateBtn_Click(object sender, EventArgs e)
        {
            redirectToPage("update");
        }

        /// <summary>
        /// delete button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            redirectToPage("delete");
        }

        /// <summary>
        /// leave button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void leaveBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.google.com");
        }
    }
}