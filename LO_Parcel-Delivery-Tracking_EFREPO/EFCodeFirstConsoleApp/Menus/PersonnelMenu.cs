using EFCodeFirstModelsLib.Models;
using EFCodeFirstRepoLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstConsoleApp.Menus
{
    public class PersonnelMenu
    {

        private readonly PersonnelRepository personnelRepository;

        public PersonnelMenu(PersonnelRepository personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Personnel Menu!");
                Console.WriteLine("1. Display All Personnel");
                Console.WriteLine("2. Add A Personnel");
                Console.WriteLine("3. Find A Personnel By ID");
                Console.WriteLine("4. Update A Personnel");
                Console.WriteLine("5. Delete A Personnle By ID");
                Console.WriteLine("6. Back to Main Menu");

                Console.Write("Enter your selected menu option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllPersonnel();
                        break;
                    case "2":
                        AddNewPersonnel();
                        break;
                    case "3":
                        FindPersonnelById();
                        break;
                    case "4":
                        UpdatePersonnelDetails();
                        break;
                    case "5":
                        DeletePersonnelDetailsById();
                        break;
                    case "6":
                        Console.WriteLine("Returning to the main menu.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }

        public  void GetPersonnelHeading()
        {
            Console.WriteLine($"Personnel Id{"",10} First name:{"",10} Last name{"",10} Phone number{"",10}" +
                $"Email address{"",10} Personnel role{"",10} Availability{"",10}");
        }

        public void ShowAllPersonnel()
        {
            Console.Clear();
            List<Personnel> allPersonnel = personnelRepository.GetAllRows();
            Console.WriteLine("\n All Personnel\n");
            GetPersonnelHeading();
            allPersonnel.ForEach(p => Console.WriteLine($"{p.PersonnelId,-22} {p.FirstName,-21} {p.LastName,-19} {p.PhoneNumber,-22}" +
                    $"{p.EmailAddress,-23} {p.UserName,-24} {p.Availability,-20}"));
        }

        public void FindPersonnelById()
        {
            Console.WriteLine("\n 2 - Get Row By Id - Personnel");
            Console.Write("Find a Personnel. Please enter Personnel ID: ");
            int id = int.Parse(Console.ReadLine());

            Personnel personnel = personnelRepository.GetRowById(id);
            if (personnel != null)
            {
                GetPersonnelHeading();
                Console.WriteLine($"{personnel.PersonnelId,-22} {personnel.FirstName,-21} {personnel.LastName,-19} {personnel.PhoneNumber,-22}" +
                    $"{personnel.EmailAddress,-23} {personnel.UserName,-24} {personnel.Availability,-20}");
            }
            else
            {
                Console.WriteLine("Personnel not found");
            }
        }


        public void AddNewPersonnel()
        {
            Console.WriteLine("\n 3 - Add New Row");
            Console.Write("Enter Personnel first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Personnel last name: ");
            string lastname = Console.ReadLine();
            Console.Write("Enter Personnel phone number (e.g., xxx-xxx-xxxx): ");
            string phoneumber = Console.ReadLine().ToString();
            Console.Write("Enter Personnel email address: ");
            string emailAddress = Console.ReadLine();
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Personnel role (0 for Off Duty or 1 for On Duty):");
            int isOnDuty = int.Parse(Console.ReadLine());
            string availability = string.Empty;
            if (isOnDuty == 0 || isOnDuty == 1)
            {
                if (isOnDuty == 0)
                {
                    availability = "Off Duty";
                }
                else if (isOnDuty == 1)
                {
                    availability = "On Duty";
                }
            }

            Personnel newPersonnel = new Personnel
            {
                FirstName = firstName,
                LastName = lastname,
                PhoneNumber = phoneumber,
                EmailAddress = emailAddress,
                UserName = username,
                Availability = availability


            };
            personnelRepository.CreateNewRow(newPersonnel);
        }

        public void UpdatePersonnelDetails()
        {
            Personnel updPersonnel = new Personnel();

            Console.Write("\n 5) Update Row. UPDATE Personnel's details");
            int id = 0;
            Console.WriteLine("\nPlease enter Personnel ID: ");
            id = int.Parse(Console.ReadLine());


            Personnel personnel = personnelRepository.GetRowById(id);
            if (personnel != null)
            {
                updPersonnel.PersonnelId = id;
                Console.WriteLine("\nPlease enter personnnel's first name: ");
                string firstName = Console.ReadLine();
                updPersonnel.FirstName = firstName;
                Console.WriteLine("\nPlease enter personnnel's first name: ");
                string lastName = Console.ReadLine();
                updPersonnel.LastName = lastName;
                Console.WriteLine("\nPlease enter personnnel's phone number: ");
                string phone_number = Console.ReadLine();
                updPersonnel.PhoneNumber = phone_number;
                Console.WriteLine("\nPlease enter personnnel's email address: ");
                string email_address = Console.ReadLine();
                updPersonnel.EmailAddress = email_address;
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                updPersonnel.UserName = username;
                Console.Write("Enter Personnel role (0 for Off Duty or 1 for On Duty):");
                int isOnDuty = int.Parse(Console.ReadLine());
                string availability = string.Empty;
                if (isOnDuty == 0 || isOnDuty == 1)
                {
                    if (isOnDuty == 0)
                    {
                        availability = "Off Duty";
                    }
                    else if (isOnDuty == 1)
                    {
                        availability = "On Duty";
                    }
                }
                updPersonnel.Availability = availability;
                personnelRepository.UpdateRow(updPersonnel);
            }
            else
            {
                Console.WriteLine($"Personnel with id: {id} not found");
            }
        }

        public void DeletePersonnelDetailsById()
        {
            bool personnelDeleted = false;

            ShowAllPersonnel();
            Console.Write("\nDelete personnel's details by ID");
            int delID = 0;
            Console.WriteLine("\nPlease enter Personnel ID: ");
            delID = int.Parse(Console.ReadLine());

            personnelDeleted = personnelRepository.DeleteRow(delID);

            if (personnelDeleted)
            { Console.WriteLine("Personnel Deleted"); }
            else
            { Console.WriteLine("Personnel Can Not Be Deleted!"); }

            ShowAllPersonnel();

        }

    }
}
