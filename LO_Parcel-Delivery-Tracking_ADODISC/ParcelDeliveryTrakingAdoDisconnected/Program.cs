using ADODisconnectedLib.Models;
using ADODisconnectedLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDeliveryTrakingAdoDisconnected
{
    internal class Program
    {
        public static void GetPersonnelHeading()
        {
            Console.WriteLine("Personnel Table:");
            Console.WriteLine($"Personnel Id{"",10} First name:{"",10} Last name{"",10} Phone number{"",10}" +
                $"Email address{"",10} Personnel role{"",10} Availability{"",10}");
        }

        public static void GetPersonnelInAList(DisconnetedPersonnelRepository _repo)
        {
            List<Personnel> personnel = _repo.GetAllPersonnel();
            Console.WriteLine("\nPersonnel Table.");
            Console.Write("Do you want to view all Personnel (y/n): ");
            char choose = Console.ReadLine()[0];

            if (choose == 'Y' || choose == 'y')
            {
                Console.WriteLine("\nGet all Personnel.");
                if (personnel.Count == 0)
                {
                    Console.WriteLine("No personnel found.");
                    return;
                }
                GetPersonnelHeading();
                personnel.ForEach(p => Console.WriteLine($"{p.PersonnelId,-22} {p.FirstName,-21} {p.LastName,-19} {p.PhoneNumber,-22}" +
                    $"{p.EmailAddress,-23} {p.PersonnelRole,-24} {p.Availability,-20}"));
            }
        }

        public static void CreateNewPersonnel(DisconnetedPersonnelRepository _repo)
        {
            Console.WriteLine("\nCreate new personnel.");
            Console.Write("Enter Personnel first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Personnel last name: ");
            string lastname = Console.ReadLine();
            Console.Write("Enter Personnel phone number (e.g., xxx-xxx-xxxx): ");
            string phoneumber = Console.ReadLine().ToString();
            Console.Write("Enter Personnel email address: ");
            string emailAddress = Console.ReadLine();
            Console.Write("Enter Personnel role (M for Manager or D for Driver):");
            char personnelRole = Console.ReadLine()[0];
            string role = string.Empty;
            if (personnelRole == 'M' || personnelRole == 'D')
            {
                if (personnelRole == 'M')
                {
                    role = "Manager";
                }
                else if (personnelRole == 'D')
                {
                    role = "Delivery Driver";
                }
            }
            Console.Write("Enter Personnel role (0 for Off Duty or 1 for On Duty):");
            int isOnDuty = int.Parse(Console.ReadLine());
            string availability = string.Empty;
            if(isOnDuty == 0 || isOnDuty == 1)
            {
                if(isOnDuty == 0)
                {
                    availability = "Off Duty";
                }else if(isOnDuty == 1)
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
                PersonnelRole = role,
                Availability = availability
               

            };
            _repo.CreatePersonnel(newPersonnel);
        }

        public static void GetPersonnelById(DisconnetedPersonnelRepository _repo)
        {
            Console.WriteLine("\nGet Personnel by personnel id.");
            Console.Write("Enter personnel id: ");
            int id = int.Parse(Console.ReadLine());
            Personnel _personnel = _repo.GetPersonnelById(id);

            if (_personnel != null)
            {
                GetPersonnelHeading();
                Console.WriteLine($"{_personnel.GetPersonnelDetails()}");
            }
        }

        static void Main(string[] args)
        {
            string _connectionString = @"Server=localhost; Database=lo_parceldeliverytracking_db; uid=root; pwd=10RelationalDatabasesAreVeryUseful!;";
            DisconnetedPersonnelRepository _repository = new DisconnetedPersonnelRepository(_connectionString);
           
            // Get Personnel By Id
            GetPersonnelById(_repository);

            // Create new personnel
            CreateNewPersonnel(_repository);

            // Get a list of Personnel
            GetPersonnelInAList(_repository);

            Console.ReadLine();

        }
    }
}
