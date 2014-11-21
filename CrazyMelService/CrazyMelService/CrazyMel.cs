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
    }
}
