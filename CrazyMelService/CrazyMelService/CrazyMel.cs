//***********************
//Authors: Kyle Fowler, Matt Anselmo, Adrian Krebs
//Project: CrazyMels
//File: CrazyMel.cs
//Date: 23/11/14
//Purpose: This file is the main route outline of where to route the different 
//          Rest requests
//***********************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace CrazyMelService
{
    [ServiceContract]
    public interface CrazyMel
    {
        //INSERTS
        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,                                
                                UriTemplate = "InsertCustomer/")]
        bool InsertCustomer(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertProduct/")]
        bool InsertProduct(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertOrder/")]
        bool InsertOrder(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertCart/")]
        bool InsertCart(Stream data);



        //UPDATES
        [OperationContract]
        [WebInvoke(Method = "PUT",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateCustomer/")]
        bool UpdateCustomer(Stream data);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateProduct/")]
        bool UpdateProduct(Stream data);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateOrder/")]
        bool UpdateOrder(Stream data);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateCart/")]
        bool UpdateCart(Stream data);



        //DELETES
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteCustomer/")]
        bool DeleteCustomer(Stream data);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteProduct/")]
        bool DeleteProduct(Stream data);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteOrder/")]
        bool DeleteOrder(Stream data);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteCart/")]
        bool DeleteCart(Stream data);



        //Searches
        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "GetPO/{po}")]
        string GetPO(string po);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,                                
                                UriTemplate = "Search/{CustomerString}/{ProductString}/{OrderString}/{CartString}")]
        string Search(string CustomerString, string ProductString, string OrderString, string CartString);
    }
}
