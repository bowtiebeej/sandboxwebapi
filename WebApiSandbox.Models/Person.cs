using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSandbox.Models
{
    public class Person
    {
        public virtual int? Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual long HomePhone { get; set; }
        public virtual long WorkPhone { get; set; }
        public virtual IList<Address> Address { get; set; }
    }
}
