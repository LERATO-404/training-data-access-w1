using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstRepoLib.Interfaces
{
    internal interface IRepository<T>
    {
        void CreateNewRow(T entity);
        List<T> GetAllRows();
        T GetRowById(int id);
        void UpdateRow(T entity);
        bool DeleteRow(int id);
    }
}
