using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSandbox.ViewModel
{
    public class Person
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long HomePhone { get; set; }
        public long WorkPhone { get; set; }
        public IList<Address> Address { get; set; }
    }
}