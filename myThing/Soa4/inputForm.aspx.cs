using Soa4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Soa4
{
    /// <summary>
    /// This class handles the input of from the user
    /// </summary>
    public partial class inputForm : System.Web.UI.Page
    {

        string[] customer = new string[] { "CustID", "FirstName", "LastName","PhoneNumber" };
        string[] product = new string[] { "ProdID", "ProdName", "Price", "ProdWeight" };
        string[] order = new string[] { "OrderID", "CustID", "PoNumber", "OrderDate" };
        string[] cart = new string[] { "OrderID", "ProdID", "Quantity"};

        static string regex = @"^[A-Za-z0-9 _.-]+$";
        static Regex reg = new Regex(regex);

        Dictionary<string, List<TextBox>> inputBoxes = new Dictionary<string, List<TextBox>>();

        Dictionary<string, Dictionary<string, string>> infoPair = new Dictionary<string, Dictionary<string, string>>();

        XMLcreator xmlgen = new XMLcreator();

        REST restObject = new REST();

        /// <summary>
        /// handles page load initialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            info.InnerHtml = "<h3>" + UppercaseFirst((string)Session["firstPageAction"]) + " mode</h3>";            
        }

        /// <summary>
        /// build search string to be sent to the rest service
        /// </summary>
        /// <returns></returns>
        private string buildSearchString()
        {
            string SearchString = "";

            SearchString += BuildStringSection("customer",customer) + "/";
            SearchString += BuildStringSection("product", product) + "," + GetSoldOut() + "/";
            SearchString += BuildStringSection("order", order) + "/";
            SearchString += BuildStringSection("cart", cart);

            return SearchString;
        }

        /// <summary>
        /// builds a section of the search string to be sent to the rest service
        /// </summary>
        /// <param name="type">type of info being handled</param>
        /// <param name="typeArray">type fo array being used to build string</param>
        /// <returns></returns>
        private string BuildStringSection(string type, string[] typeArray)
        {
            string builtString = "";
            string temp = null;
            int count = 0;
            foreach (string s in typeArray)
            {
                if (count > 0)
                    builtString += ",";
                temp = null;
                if(infoPair.ContainsKey(type))
                    temp = infoPair[type].Where(c => c.Key == s).FirstOrDefault().Value;
                if (temp == null)
                    temp = "";                
                builtString += temp;
                count++;
            }

            return builtString;
        }

        /// <summary>
        /// change first letter in a string to upper case
        /// </summary>
        /// <param name="s">input string</param>
        /// <returns></returns>
        private string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// init the list of textboxes
        /// </summary>
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

        /// <summary>
        /// validate string for bad chars
        /// </summary>
        /// <param name="test">string to check</param>
        /// <returns></returns>
        private Boolean checkIfAllCharsAreValid(String test)
        {
            return reg.Match(test).Success;
        }

        /// <summary>
        /// nothing needed to be done here, may need to at a later date
        /// </summary>
        private void initForSearch()
        {

        }

        /// <summary>
        /// init form for deleting
        /// </summary>
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
            soldoutDrop.Disabled = true;
        }

        /// <summary>
        /// init form for updates
        /// </summary>
        private void initForUpdate()
        {

        }

        /// <summary>
        /// init form for insert
        /// </summary>
        private void initForInsert()
        {
            disableTextbox(CcustID);
            disableTextbox(PprodID);
            disableTextbox(OorderID);
        }

        /// <summary>
        /// disable a textbox
        /// </summary>
        /// <param name="tb">tb to disable</param>
        private void disableTextbox(TextBox tb)
        {
            tb.Attributes.Add("disabled", "disabled");
        }

        /// <summary>
        /// handle go back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

        /// <summary>
        /// handle execute button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// handle sold out drop down click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void soldout_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            soldoutDrop.InnerHtml = b.Text + "  <span class=\"caret\"></span>";
        }

        /// <summary>
        /// insert method handler
        /// </summary>
        private void insert()
        {
            if(parseAndCheckInput())
            {
                sendRequest("POST");
                
            }
        }

        /// <summary>
        /// update method handler
        /// </summary>
        private void update()
        {
            if (parseAndCheckInput())
            {
                sendRequest("PUT");
            }
        }

        /// <summary>
        /// delete method handler
        /// </summary>
        private void delete()
        {
            if (parseAndCheckInput())
            {
                sendRequest("DELETE");
            }
        }

        /// <summary>
        /// handle sending request to the rest service
        /// </summary>
        /// <param name="verb">rest verb being used</param>
        private void sendRequest(string verb)
        {
            string objType = infoPair.Keys.First();
            if (objType == "product")
            {                
                infoPair[objType].Add("InStock", GetSoldOut());
            }
            string xml = xmlgen.CreateXMLSingle(infoPair[objType], objType);
            string rep = restObject.MakeRequest(xml, objType, (string)Session["firstPageAction"], verb);
            List<string> response = new List<string>();
            response.Add(rep);
            ShowAlert(CreateErrorJson(response, "info", "glyphicon glyphicon-warning-sign"));
        }

        /// <summary>
        /// get sold out drop down value
        /// </summary>
        /// <returns></returns>
        private string GetSoldOut()
        {
            string Checked = "";
            if (soldoutDrop.InnerText.Contains("Yes"))
                Checked = "false";
            else if (soldoutDrop.InnerText.Contains("No"))
                Checked = "true";
            return Checked;
        }

        /// <summary>
        /// parse and check input for bad values
        /// </summary>
        /// <returns>true = valid, false = invalid</returns>
        private Boolean parseAndCheckInput()
        {
            Boolean valid = true;
            List<string> errors = new List<string>();
            if (parseInputForSingleRow())
            {
                if ((string)Session["firstPageAction"] != "insert")
                    errors.AddRange(mustContainID());
                errors.AddRange(ValidateChars());
                if(errors.Count > 0)
                {

                    ShowAlert(CreateErrorJson(errors, "danger", "glyphicon glyphicon-warning-sign"));
                    valid = false;
                }
            }
            else
            {
                List<string> error = new List<string>();
                error.Add("You may only enter data for one type when doing a " + (string)Session["firstPageAction"]);
                ShowAlert(CreateErrorJson(error, "danger", "glyphicon glyphicon-warning-sign"));
                valid = false;
            }
            return valid;
        }

        /// <summary>
        /// create json for showing alerts
        /// </summary>
        /// <param name="errors">string to use</param>
        /// <param name="type">type of message</param>
        /// <param name="icon">icon to display</param>
        /// <returns></returns>
        private static string CreateErrorJson(List<string> errors, string type, string icon)
        {
            string jsonErrors = "[";
            int count = 0;
            foreach (string error in errors)
            {
                if (count > 0)
                    jsonErrors += ",";
                jsonErrors += "{" +
                "\"icon\" : \"" + icon + "\"," +
                "\"type\"   : \"" + type + "\"," +
                "\"message\" : \"" + error + "\"" +
                "}";
                count++;
            }
            jsonErrors += "]";
            return jsonErrors;
        }

        /// <summary>
        /// check if id was filled in for update or delete
        /// </summary>
        /// <returns></returns>
        private List<string> mustContainID()
        {
            List<string> errors = new List<string>();
            foreach(KeyValuePair<string,Dictionary<string,string>> kvp in infoPair)
            {
                Boolean foundID = false;
                foreach(KeyValuePair<string,string> pair in kvp.Value)
                {
                    if(pair.Key.Contains("ID"))
                    {
                        foundID = true;
                    }
                }
                if(!foundID)
                {
                    errors.Add("To " + (string)Session["firstPageAction"] + " a " + kvp.Value + " you must enter a " + kvp.Value + " ID.");
                }
            }
            return errors;
        }

        /// <summary>
        /// validate only valid chars were used
        /// </summary>
        /// <returns></returns>
        private List<string> ValidateChars()
        {
            List<string> errors = new List<string>();
            foreach (KeyValuePair<string, Dictionary<string, string>> kvp in infoPair)
            {
                foreach (KeyValuePair<string, string> pair in kvp.Value)
                {
                    if(!checkIfAllCharsAreValid(pair.Value))
                    {
                        errors.Add("The field " + pair.Key + " is invalid. It may only contains the following characters: A-Z a-z 0-9 _ . -");
                    }
                }
            }
            return errors;
        }

        /// <summary>
        /// parse input for a single row in the form
        /// </summary>
        /// <returns></returns>
        private Boolean parseInputForSingleRow()
        {
            int? whereInfoWasFound = null;
            int count = 0;


            foreach (KeyValuePair<string, List<TextBox>> entry in inputBoxes)
            {
                foreach (TextBox tb in entry.Value)
                {
                    if (!String.IsNullOrWhiteSpace(tb.Text))
                    {
                        if (whereInfoWasFound == null)
                            whereInfoWasFound = count;
                        if (whereInfoWasFound != count)
                            return false;
                        if(!infoPair.ContainsKey(entry.Key)) 
                        {
                            infoPair.Add(entry.Key, new Dictionary<string, string>());
                        }
                        infoPair[entry.Key].Add(tb.ToolTip, tb.Text);
                    }
                }
                count++;
            }
            return true;
        }

        /// <summary>
        /// parse input for all rows in the form
        /// </summary>
        private void parseInputForAllRows()
        {
            foreach (KeyValuePair<string, List<TextBox>> entry in inputBoxes)
            {
                foreach (TextBox tb in entry.Value)
                {
                    if (!String.IsNullOrWhiteSpace(tb.Text))
                    {
                        if (!infoPair.ContainsKey(entry.Key))
                        {
                            infoPair.Add(entry.Key, new Dictionary<string, string>());
                        }
                        infoPair[entry.Key].Add(tb.ToolTip, tb.Text);
                    }
                }
            }
        }

        /// <summary>
        /// search handler method
        /// </summary>
        private void search()
        {
            parseInputForAllRows();
            ValidateActiveColumns();
            string response = restObject.MakeRequest("", buildSearchString(), "Search/", "GET");
            Session["serviceResponse"] = response;
            Response.Redirect("tableOutput.aspx", true);
        }

        /// <summary>
        /// validate active columns in the form
        /// </summary>
        private void ValidateActiveColumns()
        {
            if(infoPair.ContainsKey("product") && infoPair.ContainsKey("customer"))
            {
                List<string> error = new List<string>();
                error.Add("You cannot search for both product and customer in the same search.");
                ShowAlert(CreateErrorJson(error, "danger", "glyphicon glyphicon-warning-sign"));
            }
            return;
        }

        /// <summary>
        /// invoke show alert on page
        /// </summary>
        /// <param name="json"></param>
        private void ShowAlert(string json)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "close", "ShowAlert('"+ json + "');", true);
            return;
        }

        /// <summary>
        /// get out handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void getOut_Click(object sender, EventArgs e)
        {           
            Response.Redirect("http://www.google.com");
        }
    }
}