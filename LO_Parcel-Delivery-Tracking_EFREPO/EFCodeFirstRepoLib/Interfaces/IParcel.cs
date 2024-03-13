using EFCodeFirstModelsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstRepoLib.Interfaces
{
    internal interface IParcel
    {
        List<Parcel> GetParcelsByStatus(string parcelStatus);
        List<Parcel> GetParcelsForSender(int senderId);
    }
}
