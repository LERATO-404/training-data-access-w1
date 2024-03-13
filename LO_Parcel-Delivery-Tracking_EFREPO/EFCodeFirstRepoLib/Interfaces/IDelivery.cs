using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstModelsLib.Models;

namespace EFCodeFirstRepoLib.Interfaces
{
    public interface IDelivery
    {

        List<Delivery> GetDeliveriesByPersonnel(int personnelId);
        List<Delivery> GetDeliveriesByStatus(string deliveryStatus);

    }
}
