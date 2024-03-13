using ParcelDeliveryTrackingLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDeliveryTrackingLib.Interfaces
{
    public interface IParcelRepository
    {
        List<Parcel> GetAllParcels();
    }
}
