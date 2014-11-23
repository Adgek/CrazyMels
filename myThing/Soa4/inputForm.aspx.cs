﻿using Soa4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Soa4
{
    //http://stackoverflow.com/questions/17013300/insert-datetime-into-sql-server-2008-from-c-sharp
    public partial class inputForm : System.Web.UI.Page
    {
        static string regex = @"^[A-Za-z0-9_.-]+$";
        static Regex reg = new Regex(regex);

        Dictionary<string, List<TextBox>> inputBoxes = new Dictionary<string, List<TextBox>>();

        Dictionary<string, Dictionary<string, string>> infoPair = new Dictionary<string, Dictionary<string, string>>();

        XMLcreator xmlgen = new XMLcreator();

        REST restObject = new REST();

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
            info.InnerHtml += "<h3>" + (string)Session["firstPageAction"] + " mode</h3>";            
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
            if(parseAndCheckInput())
            {
                sendRequest("POST");
            }
        }

        private void update()
        {
            if (parseAndCheckInput())
            {
                sendRequest("PUT");
            }
        }

        private void delete()
        {
            if (parseAndCheckInput())
            {
                sendRequest("DELETE");
            }
        }

        private void sendRequest(string verb)
        {
            string objType = infoPair.Keys.First();
            if (objType == "product")
            {
                string Checked = "false";
                if (Psoldout.Checked)
                    Checked = "true";
                infoPair[objType].Add("InStock", Checked.ToString());
            }
            string xml = xmlgen.CreateXMLSingle(infoPair[objType], objType);
            restObject.MakeRequest(xml, objType, (string)Session["firstPageAction"], verb);
        }

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

        private void search()
        {
            parseInputForAllRows();
        }
        //glyphicon glyphicon-warning-sign
        private void ShowAlert(string json)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "close", "ShowAlert('"+ json+ "');", true);
            return;
        }

        protected void getOut_Click(object sender, EventArgs e)
        {           
            Response.Redirect("http://www.google.com");
        }
    }
}