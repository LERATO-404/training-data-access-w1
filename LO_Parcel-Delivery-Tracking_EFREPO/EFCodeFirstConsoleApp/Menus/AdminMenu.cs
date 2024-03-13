using EFCodeFirstRepoLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstConsoleApp.Menus
{
    public class AdminMenu
    {
        private readonly ParcelRepository parcelRepository;
        private readonly DeliveryRepository deliveryRepository;

        public AdminMenu(ParcelRepository parcelRepository, DeliveryRepository deliveryRepository)
        {
            this.parcelRepository = parcelRepository;
            this.deliveryRepository = deliveryRepository;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Admin Menu!");
                Console.WriteLine("1. Deliveries");
                Console.WriteLine("2. Parcels");
                Console.WriteLine("3. Exit");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowDeliveryMenu();
                        break;
                    case "2":
                        ShowParcelMenu();
                        break;
                    case "3":
                        Console.WriteLine("Exiting Admin Menu.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void ShowDeliveryMenu()
        {
            while (true)
            {
                Console.WriteLine("\nDelivery Menu:");
                Console.WriteLine("1. List Deliveries by Status");
                Console.WriteLine("2. Back to Main Menu");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListDeliveriesByStatus();
                        break;
                    case "2":
                        Console.WriteLine("Returning to the main menu.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void ShowParcelMenu()
        {
            while (true)
            {
                Console.WriteLine("\nParcel Menu:");
                Console.WriteLine("1. List Parcels for a particular Sender");
                Console.WriteLine("2. List Parcels by Status");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListParcelsBySender();
                        break;
                    case "2":
                        ListParcelsByStatus();
                        break;
                    case "3":
                        Console.WriteLine("Returning to the main menu.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void ListParcelsBySender()
        {
            Console.Write("Enter Sender ID: ");
            if (int.TryParse(Console.ReadLine(), out int senderlId))
            {
                var parcels = parcelRepository.GetParcelsForSender(senderlId);

                Console.WriteLine("Parcels delivered by Personnel:");
                foreach (var parcel in parcels)
                {
                    Console.WriteLine($"Parcel ID: {parcel.ParcelId}, Weight: {parcel.Weight}, Status: {parcel.ParcelStatus}, Delivery Date: {parcel.DeliveryDate} ");
                    
                }
            }
            else
            {
                Console.WriteLine("Invalid Sender ID. Please enter a valid ID.");
            }
        }

        private void ListParcelsByStatus()
        {
            Console.Write("Enter Parcel Status (D for Delivered or H for On Hold or T for In Transit): ");
            char opt = Console.ReadLine()[0];
            string parcelStatus = string.Empty;
            if(opt == 'D' || opt == 'd')
            {
                parcelStatus = "Delivered";
            }
            else if(opt == 'H' || opt == 'h')
            {
                parcelStatus = "On Hold";
            }
            else if (opt == 'T' || opt == 't')
            {
                parcelStatus = "In Transit";
            }

            var parcels = parcelRepository.GetParcelsByStatus(parcelStatus);

            Console.WriteLine($"Parcels with status '{parcelStatus}':");
            foreach (var parcel in parcels)
            {
                Console.WriteLine($"Parcel ID: {parcel.ParcelId}, Weight: {parcel.Weight}, Delivery Date: {parcel.DeliveryDate}, Notes= {parcel.AdditionalNotes}");
            }
        }

        private void ListDeliveriesByStatus()
        {
            Console.Write("Enter Delivery Status (C for Completed or I for In Progress or S for Scheduled): ");
            char opt = Console.ReadLine()[0];
            string deliveryStatus = string.Empty;
            if (opt == 'I' || opt == 'i')
            {
                deliveryStatus = "In Progress";
            }
            else if (opt == 'C' || opt == 'c')
            {
                deliveryStatus = "Completed";
            }
            else if (opt == 'S' || opt == 's')
            {
                deliveryStatus = "Scheduled";
            }

            var deliveries = deliveryRepository.GetDeliveriesByStatus(deliveryStatus);

            Console.WriteLine($"Deliveries with status '{deliveryStatus}':");
            foreach (var delivery in deliveries)
            {
                Console.WriteLine($"Delivery ID: {delivery.DeliveryId}, Status: {delivery.DeliveryStatus}");
            }
        }

    }
}
