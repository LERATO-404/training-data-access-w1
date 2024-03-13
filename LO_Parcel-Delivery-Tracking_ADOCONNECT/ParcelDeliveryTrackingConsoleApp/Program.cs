using ParcelDeliveryTrackingLib.Models;
using ParcelDeliveryTrackingLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDeliveryTrackingConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=localhost; Database=lo_parceldeliverytracking_db; uid=root; pwd=10RelationalDatabasesAreVeryUseful!;";
            ParcelRepository repo = new ParcelRepository(connectionString);
            List<Parcel> parcels = repo.GetAllParcels();

            Console.WriteLine($"Parcel Id:{"",10} Sender:{"",10} Receiver:{"",10} Weight:{"",10}" +
                $"Parcel Status:{"",10} Delivery Date:{"",10} Additional Notes:{"",10}");

            parcels.ForEach(p => Console.WriteLine($"{p.ParcelId,-20} {p.SenderID,-18} {p.ReceiverID,-18} {p.Weight,-18}" +
                $"{p.ParcelStatus,-20} {p.DeliveryDate,-29} {p.AdditionalNotes,-20}"));

            Console.ReadLine();
        }
    }
}
