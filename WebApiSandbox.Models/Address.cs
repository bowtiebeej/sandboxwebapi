using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSandbox.Models
{
    public class Address
    {
        public virtual int? Id { get; set; }
        public virtual string AddressType { get; set; }
        public virtual string Street1 { get; set; }
        public virtual string Street2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual int? Zip { get; set; }
    }
}
