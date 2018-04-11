using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

            CreateMap<Instructor, InstructorViewModel>()
                .ForMember(vm => vm.Office, opt => opt.MapFrom(i => i.OfficeAssignment.Location))
                .ForMember(vm => vm.SelectedCourses, opt => opt.MapFrom(
                    i => i.CourseAssignments.Select(ca => ca.Course.Title)))
                .ForMember(vm => vm.Courses, opt => opt.MapFrom(
                      i => i.CourseAssignments.Select(ca => new CourseViewModel
                      {
                          CourseID = ca.CourseID,
                          Title = ca.Course.Title
                      }  
                          )));

            CreateMap<Instructor, InstructorEditViewModel>()
                .ForMember(vm=>vm.AssignedCourses, opt=>opt.Ignore())
                .ForMember(vm => vm.Office, opt => opt.MapFrom(i => i.OfficeAssignment.Location));
        }
    }
}
