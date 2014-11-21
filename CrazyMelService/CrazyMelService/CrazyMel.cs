using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CrazyMelService
{
    [ServiceContract]
    public interface CrazyMel
    {
        //INSERTS

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertCustomer/{FirstName}/{LastName}/{PhoneNumber}")]
        bool InsertCustomer(string FirstName, string LastName, string PhoneNumber);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertProduct/{ProductName}/{Price}/{ProdWeight}/{InStock}")]
        bool InsertProduct(string ProductName, string Price, string ProdWeight, string InStock);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertOrder/{CustID}/{PoNumber}/{OrderDate}")]
        bool InsertOrder(string CustID, string PoNumber, string OrderDate);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "InsertCart/{OrderID}/{ProdID}/{Quantity}")]
        bool InsertCart(string OrderID, string ProdID, string Quantity);

        //UPDATES

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateCustomer/{CustID}/{FirstName}/{LastName}/{PhoneNumber}")]
        bool UpdateCustomer(string CustID, string FirstName, string LastName, string PhoneNumber);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateProduct/{ProdID}/{ProductName}/{Price}/{ProdWeight}/{InStock}")]
        bool UpdateProduct(string ProdID, string ProductName, string Price, string ProdWeight, string InStock);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateOrder/{OrderID}/{CustID}/{PoNumber}/{OrderDate}")]
        bool UpdateOrder(string OrderID, string CustID, string PoNumber, string OrderDate);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "UpdateCart/{OrderID}/{ProdID}/{Quantity}")]
        bool UpdateCart(string OrderID, string ProdID, string Quantity);

        //DELETES

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteCustomer/{CustID}/{FirstName}/{LastName}/{PhoneNumber}")]
        bool DeleteCustomer(string CustID, string FirstName, string LastName, string PhoneNumber);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteProduct/{ProdID}/{ProductName}/{Price}/{ProdWeight}/{InStock}")]
        bool DeleteProduct(string ProdID, string ProductName, string Price, string ProdWeight, string InStock);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteOrder/{OrderID}/{CustID}/{PoNumber}/{OrderDate}")]
        bool DeleteOrder(string OrderID, string CustID, string PoNumber, string OrderDate);

        [OperationContract]
        [WebInvoke(Method = "GET",
                                ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare,
                                UriTemplate = "DeleteCart/{OrderID}/{ProdID}/{Quantity}")]
        bool DeleteCart(string OrderID, string ProdID, string Quantity);
    }
}
