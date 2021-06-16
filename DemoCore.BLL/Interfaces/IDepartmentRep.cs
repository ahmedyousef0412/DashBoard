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


        /// <summary>
        /// i'm Not Using IEnumerable because i wont return [Just one Row ]
        /// </summary>
        
        DepartmentVM GetById (int id);


        /// <summary>
        /// i'm  Using IEnumerable because i wont return [Just one Row ] but may be i Have
        /// [one or more Employee have the same name work in one Department]
        /// </summary>
        
        IEnumerable<DepartmentVM> SearchByName(string name);  


        /// <summary>
        /// i'm Using [Void] because in [Create  ,  Delete , Edit]  I'm Not Return AnyThin
        /// </summary>
        
          void Create (DepartmentVM obj);
          void Edit (DepartmentVM obj); 
          void Delete(int id);
    


 }
}
