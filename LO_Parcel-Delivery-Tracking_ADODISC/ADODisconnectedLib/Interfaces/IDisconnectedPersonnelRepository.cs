using ADODisconnectedLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODisconnectedLib.Interfaces
{
    internal interface IDisconnectedPersonnelRepository
    {
        void CreatePersonnel(Personnel personnel);
        Personnel GetPersonnelById(int id);
        List<Personnel> GetAllPersonnel();
    }
}
