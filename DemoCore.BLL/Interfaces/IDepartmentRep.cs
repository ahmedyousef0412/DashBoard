using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCore.BLL.Models.ViewModels;

namespace DemoCore.BLL.Interfaces
{
 public interface IDepartmentRep
 {
     IEnumerable<DepartmentVM> Get();
 }
}
