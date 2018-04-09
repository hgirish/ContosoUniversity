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
                .ForMember(vm=>vm.Assigned, opt=> opt.UseValue(false));
        }
    }
}
