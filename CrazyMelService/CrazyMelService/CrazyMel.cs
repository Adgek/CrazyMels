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
        string InsertCustomer(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertProduct/")]
        string InsertProduct(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertOrder/")]
        string InsertOrder(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertCart/")]
        string InsertCart(Stream data);

        //UPDATES
        [OperationContract]
        [WebInvoke(Method = "PUT",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateCustomer/")]
        string UpdateCustomer(Stream data);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateProduct/")]
        string UpdateProduct(Stream data);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateOrder/")]
        string UpdateOrder(Stream data);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateCart/")]
        string UpdateCart(Stream data);



        //DELETES
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteCustomer/")]
        string DeleteCustomer(Stream data);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteProduct/")]
        string DeleteProduct(Stream data);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteOrder/")]
        string DeleteOrder(Stream data);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteCart/")]
        string DeleteCart(Stream data);



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
