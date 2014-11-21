using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Soa4
{
    public partial class inputForm : System.Web.UI.Page
    {
        static string regex = @"^[A-Za-z0-9_.-]+$";
        static Regex reg = new Regex(regex);

        Dictionary<string, List<TextBox>> inputBoxes = new Dictionary<string, List<TextBox>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitInputList();
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
                default:
                    Server.Transfer("Default.aspx", true);
                    break;

            }
            info.Text = (string)Session["firstPageAction"];            
        }

        private void InitInputList()
        {
            inputBoxes.Add("customer", new List<TextBox>());
            inputBoxes.Add("product", new List<TextBox>());
            inputBoxes.Add("order", new List<TextBox>());
            inputBoxes.Add("cart", new List<TextBox>());

            inputBoxes["customer"].Add(CcustID);
            inputBoxes["customer"].Add(CfirstName);
            inputBoxes["customer"].Add(ClastName);
            inputBoxes["customer"].Add(CphoneNumber);

            inputBoxes["product"].Add(PprodID);
            inputBoxes["product"].Add(PprodName);
            inputBoxes["product"].Add(Pprice);
            inputBoxes["product"].Add(Pweight);

            inputBoxes["order"].Add(OorderID);
            inputBoxes["order"].Add(OcustID2);
            inputBoxes["order"].Add(OpoNumber);
            inputBoxes["order"].Add(OorderDate);

            inputBoxes["cart"].Add(CAorderID2);
            inputBoxes["cart"].Add(CAprodID2);
            inputBoxes["cart"].Add(CAquantity);
        }

        private Boolean checkIfAllCharsAreValid(String test)
        {
            return reg.Match(test).Success;
        }

        private void initForSearch()
        {

        }

        private void initForDelete()
        {
            foreach (KeyValuePair<string, List<TextBox>> entry in inputBoxes)
            {
                foreach(TextBox tb in entry.Value)
                {
                    if (!tb.ID.Contains("ID") || tb.ID.Contains("OcustID2"))
                    {
                        disableTextbox(tb);
                    }
                }
            }
            Psoldout.Enabled = false;
        }

        private void initForUpdate()
        {

        }

        private void initForInsert()
        {
            disableTextbox(CcustID);
            disableTextbox(PprodID);
            disableTextbox(OorderID);
        }

        private void disableTextbox(TextBox tb)
        {
            tb.Attributes.Add("disabled", "disabled");
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

        protected void execute_Click(object sender, EventArgs e)
        {
            string action = (string)Session["firstPageAction"];
            switch (action)
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