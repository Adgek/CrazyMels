<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Soa4._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Crazy Melvin's Shopping Emporium</h1>
        <p class="lead">Here at Crazy Melvin's we believe in selling things cheap!! That's why our User Interface is cheap!</p>
    </div>

    <div class="row text-center">
        <div class="btn-group" role="group">
                <asp:button class="btn btn-primary btn-lg" ID="searchBtn" runat="server" text="Search" OnClick="searchBtn_Click"></asp:button>
        
                <asp:button class="btn btn-primary btn-lg" runat="server" text="Insert some Stuff" ID="insertBtn" OnClick="insertBtn_Click"></asp:button>
         
                <asp:button class="btn btn-primary btn-lg" runat="server" text="Update some Stuff" ID="updateBtn" OnClick="updateBtn_Click"></asp:button>
         
                <asp:button class="btn btn-primary btn-lg" runat="server" text="Delete some Stuff" ID="deleteBtn" OnClick="deleteBtn_Click"></asp:button>
         
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-4 text-center">            
            <p>
                <asp:button class="btn btn-primary btn-lg" runat="server" text="Get me outta here!" ID="leaveBtn" OnClick="leaveBtn_Click"></asp:button>
            </p>
        </div>
        <div class="col-md-4">
        </div>
    </div>

</asp:Content>
