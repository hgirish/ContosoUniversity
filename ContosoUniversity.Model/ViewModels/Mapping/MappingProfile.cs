using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Model.ViewModels.Mapping
{
  public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseViewModel>()
                .ForMember(vm=>vm.Department, opt=> opt.MapFrom(c=>c.Department.Name))
                .ForMember(vm=>vm.DepartmentID, opt=> opt.MapFrom(c=>c.DepartmentID))
                .ForMember(vm=>vm.Assigned, opt=> opt.UseValue(false));
        }
    }
}
