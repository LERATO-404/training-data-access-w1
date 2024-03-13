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
    public class PersonnelRepository : IRepository<Personnel>
    {
        private readonly ParcelDeliveryTrackingDBEntities context = new ParcelDeliveryTrackingDBEntities();  


        public void CreateNewRow(Personnel entity)
        {
            if (entity.FirstName is null) { }
            else
            {
                context.personnel.Add(entity);
                context.SaveChanges();
            }
        }

        public bool DeleteRow(int id)
        {
            bool rowDeleted = false;

            try
            {
                var personnelToDelete = context.personnel.Where(ps => ps.PersonnelId == id);

                foreach (var delPersonnel in personnelToDelete)
                {
                    if (delPersonnel.PersonnelId == id)
                    {
                        context.personnel.Remove(delPersonnel);
                        rowDeleted = true;
                    }
                }
                context.SaveChanges();
                return rowDeleted;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Personnel with id {id} Not deleted!");
                Console.WriteLine($"Exception: {ex} ");
                return false;
            }
        }

        public List<Personnel> GetAllRows()
        {
            List<Personnel> allPersonnel = new List<Personnel>();

            foreach (var item in context.personnel)
            {
                allPersonnel.Add(item);
            }

            return allPersonnel;
        }

        public Personnel GetRowById(int id)
        {
            Personnel personnelById = new Personnel();
            var personnel = context.personnel.FirstOrDefault(ps => ps.PersonnelId == id);

            if (personnel != null)
            {
                personnelById.PersonnelId = personnel.PersonnelId;
                personnelById.FirstName = personnel.FirstName;
                personnelById.LastName = personnel.LastName;
                personnelById.PhoneNumber = personnel.PhoneNumber;
                personnelById.EmailAddress= personnel.EmailAddress;
                personnelById.UserName = personnel.UserName;
                personnelById.Availability= personnel.Availability;
            }

            return personnelById;
        }

        public void UpdateRow(Personnel entity)
        {
            try
            {
                var personnel = context.Set<Personnel>().Find(entity.PersonnelId);
                if (personnel != null)
                {
                    personnel.FirstName= entity.FirstName;
                    personnel.LastName = entity.LastName;
                    personnel.PhoneNumber = entity.PhoneNumber;
                    personnel.EmailAddress= entity.EmailAddress;
                    personnel.UserName = entity.UserName;
                    personnel.Availability= entity.Availability;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Personnel with id {entity.PersonnelId} Not found!");
                Console.WriteLine($"Exception: {ex} ");
            }
        }
    }
}
