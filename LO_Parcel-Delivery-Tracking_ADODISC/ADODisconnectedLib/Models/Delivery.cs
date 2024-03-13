using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODisconnectedLib.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int ParcelID { get; set; }
        public int DeliveryPersonnel { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
