using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Interfaces
{
    public interface IEmployeeRep
    {


        IEnumerable<Employee> Get();


        /// <summary>
        /// i'm Not Using IEnumerable because i won't return [Just one Row ]
        /// </summary>

        Employee GetById(int id);


        /// <summary>
        /// i'm  Using IEnumerable because i won't return [Just one Row ] but may be i Have
        /// [one or more Employee have the same name work in one Department]
        /// </summary>

        IEnumerable<Employee> SearchByName(string name);


        void Create(Employee obj);
        void Edit(Employee obj);
        void Delete(Employee obj);



    }

}
