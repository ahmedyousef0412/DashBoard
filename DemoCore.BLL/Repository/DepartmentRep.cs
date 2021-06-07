using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace DemoCore.BLL.Repository
{
    public   class DepartmentRep : IDepartmentRep
    {
        private readonly DataContext _context = new DataContext();
       public IEnumerable<DepartmentVM> Get()
       {
           var Data = _context.Departments
               .Select(a => new DepartmentVM
               {
                   Id = a.Id,
                   DepartmentName = a.DepartmentName,
                   Departmentcode = a.Departmentcode
               });
           return Data;
       }
    }
}
