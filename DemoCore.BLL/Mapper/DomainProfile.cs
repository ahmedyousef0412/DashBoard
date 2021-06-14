using AutoMapper;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.BLL.Repository;
using DemoCore.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Mapper
{
    public class DomainProfile : Profile
    {

        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();
        }
    }

}
