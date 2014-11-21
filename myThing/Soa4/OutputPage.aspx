﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OutputPage.aspx.cs" Inherits="Soa4.OutputPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Crazy Melvin's Shopping Emporium</h1>
        <p class="lead">Here at Crazy Melvin's we believe in selling things cheap!! That's why our User Interface is cheap!</p>
    </div>

    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label runat="server">Customer Information</asp:Label>
                </div>
                <div class="col-md-6">
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server">Purchase Date : orderDate</asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <asp:Label runat="server">ID : custID</asp:Label>
                </div>
                <div class="col-md-6">
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <asp:Label runat="server">Name : lastName, firstName</asp:Label>
                </div>
                <div class="col-md-6">
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server"> P.O. Number : poNumber</asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <asp:Label runat="server">Phone : xxx-xxx-xxxx</asp:Label>
                </div>
                <div class="col-md-6">
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                </div>

                <div class="col-md-8">

                    <div class="table-responsive">
                        <table class="table table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Product Name</th>
                                    <th>Quantity</th>
                                    <th>Unit Price</th>
                                    <th>Unit Weight</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>product</td>
                                    <td>2</td>
                                    <td>55.00</td>
                                    <td>25 lb.</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>product</td>
                                    <td>2</td>
                                    <td>55.00</td>
                                    <td>25 lb.</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>product</td>
                                    <td>2</td>
                                    <td>55.00</td>
                                    <td>25 lb.</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>product</td>
                                    <td>2</td>
                                    <td>55.00</td>
                                    <td>25 lb.</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>product</td>
                                    <td>2</td>
                                    <td>55.00</td>
                                    <td>25 lb.</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>SubTotal</td>
                                    <td>1000</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>Tax (13%)</td>
                                    <td>25</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>Total</td>
                                    <td>1025</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                </div>

                <div class="col-md-2">
                </div>
            </div>

        </div>
    </div>

    <div class="row text-center">
        <div class="btn-group" role="group">
            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Go Back"></asp:Button>

            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Print"></asp:Button>

            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Get me outta here!"></asp:Button>
        </div>
    </div>

</asp:Content>


