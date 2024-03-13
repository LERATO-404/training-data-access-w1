using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstModelsLib;
using EFCodeFirstModelsLib.Models;
using EFCodeFirstRepoLib.Interfaces;

namespace EFCodeFirstRepoLib.Repositories
{
    public class ParcelRepository : IParcel
    {
        private readonly ParcelDeliveryTrackingDBEntities _context = new ParcelDeliveryTrackingDBEntities();

        public List<Parcel> GetParcelsForSender(int senderID)
        {
            return _context.parcels
            .Where(parcel => parcel.SenderID == senderID)
            .ToList();

        }

        

        public List<Parcel> GetParcelsByStatus(string parcelStatus)
        {
            return _context.parcels
            .Where(parcel => parcel.ParcelStatus == parcelStatus)
            .ToList();
        }
    }
}
