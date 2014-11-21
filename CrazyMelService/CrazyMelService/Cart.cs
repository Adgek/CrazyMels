using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelService
{
    [DataContract]
    public class Cart
    {
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int ProdID { get; set; }
        [DataMember]
        public int Quantity { get; set; }       
    }
}