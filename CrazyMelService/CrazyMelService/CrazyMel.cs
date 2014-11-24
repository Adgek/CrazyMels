﻿using System;
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
        //string FirstName, string LastName, string PhoneNumber
        string InsertCustomer(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertProduct/")]
        //string ProductName, string Price, string ProdWeight, string InStock
        string InsertProduct(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertOrder/")]
        //string CustID, string PoNumber, string OrderDate
        string InsertOrder(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertCart/")]
        //string OrderID, string ProdID, string Quantity
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

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "GetPO/{po}")]
        //string FirstName, string LastName, string PhoneNumber
        string GetPO(string po);

        [OperationContract]
        [WebInvoke(Method = "GET",//"GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,                                
                                UriTemplate = "Search/{CustomerString}/{ProductString}/{OrderString}/{CartString}")]
        //Search/1,Matthew,Anselmo,1231231111/1,Banana,,,,/,,,/,,,
        string Search(string CustomerString, string ProductString, string OrderString, string CartString);
    }
}
