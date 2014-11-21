using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Soa4
{
    public partial class inputForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = (string)Session["firstPageAction"];
            switch (action)
            {
                case "insert":
                    initForInsert();
                    break;
                case "update":
                    initForUpdate();
                    break;
                case "delete":
                    initForDelete();
                    break;
                case "search":
                    initForSearch();
                    break;
            }
            info.Text = (string)Session["firstPageAction"];
        }

        private void initForSearch()
        {
            throw new NotImplementedException();
        }

        private void initForDelete()
        {
            throw new NotImplementedException();
        }

        private void initForUpdate()
        {
            throw new NotImplementedException();
        }

        private void initForInsert()
        {
            throw new NotImplementedException();
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx", true);
        }

        protected void execute_Click(object sender, EventArgs e)
        {
            string action = (string)Session["firstPageAction"];
            switch(action)
            {
                case "insert":
                    insert();
                    break;
                case "update":
                    update();
                    break;
                case "delete":
                    delete();
                    break;
                case "search":
                    search();
                    break;
            }
        }

        private void insert()
        {

        }

        private void update()
        {

        }

        private void delete()
        {

        }

        private void search()
        {

        }

        protected void getOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.google.com");
        }
    }
}