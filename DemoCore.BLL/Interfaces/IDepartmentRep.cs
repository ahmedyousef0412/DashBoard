using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCore.BLL.DTO;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.Entity;

namespace DemoCore.BLL.Interfaces
{
 public interface IDepartmentRep
 {
        IEnumerable<Department> Get();

        Department GetById (int id);


        IEnumerable<Department> SearchByName(string name);  
        
          void Create (Department obj);
          void Edit (Department obj); 
          void Delete(Department obj);
    


 }
}
