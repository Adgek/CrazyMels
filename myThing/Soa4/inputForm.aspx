<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inputForm.aspx.cs" Inherits="Soa4.inputForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Crazy Melvin's Shopping Emporium</h1>
        <div runat="server" id="info" class="text-center"></div>
    </div>
    <br />


    <div class="row">
        <div class="col-md-4 ">
        </div>
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
        <div class="col-md-4 ">
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
                <div class="col-md-3"> 
                    <label>soldOut</label> <br />                
                    <div class="btn-group" id="soldoutDiv">
                        
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" id="soldoutDrop" runat="server">
                            Don't Care(Default)  <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu" role="menu">
                            <li><asp:button class="btn btn-link" runat="Server" id="dontcare" OnClick="soldout_Click" text="Don't Care(Default)"></asp:button></li>
                            <li class="divider"></li>
                            <li><asp:button class="btn btn-link" runat="Server" id="yes" OnClick="soldout_Click" Text="Yes"></asp:button></li>
                            <li><asp:button class="btn btn-link" runat="Server" id="no" OnClick="soldout_Click" Text="No"></asp:button></li>
                        </ul>
                    </div>
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

    <script>
        function ShowAlert(text) {
            var json = JSON.parse(text);
            for (var i = 0; i < json.length; i++) {
                var obj = json[i];
                icon = obj.icon;
                type = obj.type;
                message = obj.message;
                $.growl({
                    icon: icon,
                    title: '',
                    message: message
                }, {
                    element: 'body',
                    type: type,
                    placement: {
                        from: "top",
                        align: "center"
                    },
                    timer: 100000
                });
            }

        }
    </script>
</asp:Content>






