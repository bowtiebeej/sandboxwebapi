using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSandbox.ViewModel
{
    public class Address
    {
        public int? Id { get; set; }
        public string AddressType { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }
    }
}