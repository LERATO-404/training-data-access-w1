using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODisconnectedLib.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string PostalCode { get; set; }
    }
}
