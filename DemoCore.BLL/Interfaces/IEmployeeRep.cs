using DemoCore.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Interfaces
{
    public interface IEmployeeRep
    {


        IEnumerable<EmployeeVM> Get();


        /// <summary>
        /// i'm Not Using IEnumerable because i wont return [Just one Row ]
        /// </summary>

        EmployeeVM GetById(int id);


        /// <summary>
        /// i'm  Using IEnumerable because i wont return [Just one Row ] but may be i Have
        /// [one or more Employee have the same name work in one Department]
        /// </summary>

        IEnumerable<EmployeeVM> SearchByName(string name);


        void Create(EmployeeVM obj);
        void Edit(EmployeeVM obj);
        void Delete(int id);



    }

}
