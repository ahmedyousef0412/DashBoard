using DemoCore.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Interfaces
{
  public  interface IDistricRep
    {

        IEnumerable<District> Get();

        District GetById(int id);
    }
}
