using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODisconnectedLib.Models
{
    public class Parcel
    {
        public int ParcelId { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public double Weight { get; set; }
        public string ParcelStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
