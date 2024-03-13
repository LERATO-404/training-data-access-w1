using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstRepoLib.Interfaces;
using EFCodeFirstModelsLib.Models;
using EFCodeFirstModelsLib;

namespace EFCodeFirstRepoLib.Repositories
{
    public class DeliveryRepository : IDelivery
    {
        private readonly ParcelDeliveryTrackingDBEntities _context = new ParcelDeliveryTrackingDBEntities();

       

        public List<Delivery> GetDeliveriesByPersonnel(int personnelId)
        {
            return _context.deliveries
                .Where(d => d.DeliveryPersonnel == personnelId)
                .OrderBy(d=> d.DeliveryDate)
                .ToList();
        }

        public List<Delivery> GetDeliveriesByStatus(string deliveryStatus)
        {
            return _context.deliveries
            .Where(d => d.DeliveryStatus == deliveryStatus)
            .ToList();
        }

        
    }
}
