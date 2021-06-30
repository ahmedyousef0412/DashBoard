using AutoMapper;
using DemoCore.BLL.DTO;
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


            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();
        }
    }

}
