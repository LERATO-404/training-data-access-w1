using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDeliveryTrackingLib.Models
{
    public class Personnel
    {
        public int PersonnelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PersonnelRole { get; set; }
        public string Availability { get; set; }
    }
}
