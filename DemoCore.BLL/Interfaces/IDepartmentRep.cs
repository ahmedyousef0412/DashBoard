using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.Entity;

namespace DemoCore.BLL.Interfaces
{
 public interface IDepartmentRep
 {
     IEnumerable<DepartmentVM> Get();
     DepartmentVM GetById (int id);
     IEnumerable<DepartmentVM> SearchByName(string Name);  
     void Create (DepartmentVM Obj);
     void Edit (DepartmentVM obj); 
     void Delete(int id);
    


 }
}
