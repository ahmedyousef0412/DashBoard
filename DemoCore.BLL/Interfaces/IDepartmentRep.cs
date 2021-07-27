using DemoCore.DAL.Entity;
using System.Collections.Generic;

namespace DemoCore.BLL.Interfaces
{
    public interface IDepartmentRep
    {
        IEnumerable<Department> Get();

        Department GetById(int id);


        IEnumerable<Department> SearchByName(string name);

        void Create(Department obj);
        void Edit(Department obj);
        void Delete(Department obj);



    }
}
