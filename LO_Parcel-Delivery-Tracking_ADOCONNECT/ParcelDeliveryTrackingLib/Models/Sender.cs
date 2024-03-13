using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDeliveryTrackingLib.Models
{
    public class Sender
    {
        public int SenderId { get; set; }
        public int ParticipantId { get; set; }
        public string TypeOfSender { get; set; }
    }
}
