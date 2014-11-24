<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OutputPage.aspx.cs" Inherits="Soa4.OutputPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Crazy Melvin's Shopping Emporium</h1>
        <p class="lead">Here at Crazy Melvin's we believe in selling things cheap!! That's why our User Interface is cheap!</p>
    </div>

    <div id="POArea" runat="server">
        
    </div>

    <div class="row text-center">
        <div class="btn-group" role="group">
            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Go Back"></asp:Button>

            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Print"></asp:Button>

            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Get me outta here!"></asp:Button>
        </div>
    </div>

</asp:Content>


