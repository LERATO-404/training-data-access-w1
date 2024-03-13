using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstRepoLib;
using EFCodeFirstRepoLib.Repositories;
using EFCodeFirstModelsLib.Models;
using EFCodeFirstConsoleApp.Menus;
using System.Xml.Linq;
using EFCodeFirstModelsLib;


namespace EFCodeFirstConsoleApp
{
    internal class Program
    {
        static readonly PersonnelRepository personnelRepository = new PersonnelRepository();
        static readonly ParcelRepository parcelRepository = new ParcelRepository();
        static readonly DeliveryRepository deliveryRepository = new DeliveryRepository();
        
        static void Main(string[] args)
        {
            Console.Title = "Parcel Delivery Tracking System";
            AdminMenu adminTab = new AdminMenu(parcelRepository, deliveryRepository);
            PersonnelMenu personnelTab = new PersonnelMenu(personnelRepository);

            string exitMenu = "x";
            string menuOption = string.Empty;

            while (menuOption != exitMenu)
            {
                Console.WriteLine("1. Admin menu");
                Console.WriteLine("2. Personnel menu");
                Console.Write("x. Exit\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        adminTab.Run();
                        break;
                    case "2":
                        personnelTab.Run();
                        break;
                    case "x":
                        Console.WriteLine("\nGoodBye");
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }

                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();

            }

        }
    }
}
