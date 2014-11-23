<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inputForm.aspx.cs" Inherits="Soa4.inputForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Crazy Melvin's Shopping Emporium</h1>
        <asp:label runat="server" id="info"></asp:label>
    </div>
    <br />


    <div class="row">
        <div class="col-md-4 text-center">
            <div class="panel panel-default">
                <div class="panel-body">
                    <label>
                        <asp:CheckBox runat="server" value="" />
                        Please generate a Purchase Order
                    </label>
                </div>
            </div>
        </div>
        <div class="col-md-8 ">
            <div class="panel panel-default">
                <div class="panel-body" id="errorDiv" runat="server">
                
                </div>
            </div>
        </div>
    </div>



    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Customer</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <label for="custID">custID</label>
                    <asp:TextBox runat="server" ToolTip="CustID" class="form-control" ID="CcustID" placeholder="Enter custID" />
                </div>
                <div class="col-md-3">
                    <label for="custID">firstName</label>
                    <asp:TextBox runat="server" ToolTip="FirstName" class="form-control" ID="CfirstName" placeholder="Enter firstName" />
                </div>
                <div class="col-md-3">
                    <label for="custID">lastName</label>
                    <asp:TextBox runat="server" ToolTip="LastName" class="form-control" ID="ClastName" placeholder="Enter lastName" />
                </div>
                <div class="col-md-3">
                    <label for="custID">phoneNumber</label>
                    <asp:TextBox runat="server" ToolTip="PhoneNumber" class="form-control" ID="CphoneNumber" placeholder="xxx-xxx-xxxx" />
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Product</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <label for="custID">prodID</label>
                    <asp:TextBox runat="server" ToolTip="ProdID" class="form-control" ID="PprodID" placeholder="Enter prodID" />
                </div>
                <div class="col-md-2">
                    <label for="custID">prodName</label>
                    <asp:TextBox runat="server" ToolTip="ProdName" class="form-control" ID="PprodName" placeholder="Enter prodName" />
                </div>
                <div class="col-md-2">
                    <label for="custID">price</label>
                    <asp:TextBox runat="server" ToolTip="Price" class="form-control" ID="Pprice" placeholder="Enter price" />
                </div>
                <div class="col-md-2">
                    <label for="custID">prodWeight</label>
                    <asp:TextBox runat="server" ToolTip="ProdWeight" class="form-control" ID="Pweight" placeholder="Enter prodWeight" />
                </div>
                <div class="col-md-3 vertical-center">
                    <br />
                    <label>
                        <asp:CheckBox id="Psoldout" ToolTip="InStock"  runat="server" value="" />
                        Sold Out
                    </label>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Order</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <label for="custID">orderID</label>
                    <asp:TextBox runat="server" class="form-control" ToolTip="OrderID" ID="OorderID" placeholder="Enter orderID" />
                </div>
                <div class="col-md-3">
                    <label for="custID">custID</label>
                    <asp:TextBox runat="server" class="form-control" ToolTip="CustID" ID="OcustID2" placeholder="Enter custID" />
                </div>
                <div class="col-md-3">
                    <label for="custID">poNumber</label>
                    <asp:TextBox runat="server" class="form-control" ToolTip="PoNumber" ID="OpoNumber" placeholder="Enter poNumber" />
                </div>
                <div class="col-md-3">
                    <label for="custID">orderDate</label>
                    <asp:TextBox runat="server" class="form-control" ToolTip="OrderDate" ID="OorderDate" placeholder="MM-DD-YY" />
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Cart</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <label for="custID">orderID</label>
                    <asp:TextBox runat="server" class="form-control" ToolTip="OrderID" ID="CAorderID2" placeholder="Enter orderID" />
                </div>
                <div class="col-md-3">
                    <label for="custID">prodID</label>
                    <asp:TextBox runat="server" class="form-control" ToolTip="ProdID" ID="CAprodID2" placeholder="Enter custID" />
                </div>
                <div class="col-md-3">
                    <label for="custID">quantity</label>
                    <asp:TextBox runat="server" class="form-control" ToolTip="Quantity" ID="CAquantity" placeholder="Enter quantity" />
                </div>
                <div class="col-md-3">
                </div>
            </div>
        </div>
    </div>

    <div class="row text-center">
        <div class="btn-group" role="group">
            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Go Back" ID="goBack" OnClick="goBack_Click"></asp:Button>

            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Execute" ID="execute" OnClick="execute_Click"></asp:Button>

            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Get me outta here!" ID="getOut" OnClick="getOut_Click"></asp:Button>

        </div>
    </div>

</asp:Content>
