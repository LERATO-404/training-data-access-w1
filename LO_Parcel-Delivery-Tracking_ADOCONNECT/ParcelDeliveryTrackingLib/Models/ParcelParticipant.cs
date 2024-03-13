using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDeliveryTrackingLib.Models
{
    public class ParcelParticipant
    {
        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public int AddressID { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
