using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODisconnectedLib.Models
{
    public class Personnel
    {
        public int PersonnelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PersonnelRole { get; set; }
        public string Availability { get; set; }

        public string GetPersonnelDetails()
        {
            string personnelDetails = $"{PersonnelId,-22} {FirstName,-21} {LastName,-19} {PhoneNumber,-22}" +
                $"{EmailAddress,-23} {PersonnelRole,-24} {Availability,-20}";
            return personnelDetails;
        }
    }
}
