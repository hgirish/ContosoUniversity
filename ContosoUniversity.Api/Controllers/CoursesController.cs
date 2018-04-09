using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Api.Core;
using ContosoUniversity.Data.Abstract;
using ContosoUniversity.Model;
using ContosoUniversity.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Api.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly ICoursesRepository _coursesRepository;
        int page = 1;
        int pageSize = 4;
        public CoursesController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task<IActionResult> Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }
            int currentPage = page;
            int currentPageSize = pageSize;
            var totalCourses = await _coursesRepository.CountsAsync();
            var totalPages = (int)Math.Ceiling((double)totalCourses / pageSize);

            IEnumerable<Course> courses = _coursesRepository
                .AllIncluding(c => c.Department)
                .OrderBy(c => c.CourseID)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            Response.AddPagination(page, pageSize, totalCourses, totalPages);

            IEnumerable<CourseViewModel> coursesVM =
                Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return Ok(coursesVM);

        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            IEnumerable<Course> courses = _coursesRepository.GetAll();
            var coursesVM = Mapper.Map<IEnumerable<Course>,
                IEnumerable<CourseViewModel>>(courses);

            return Ok(coursesVM);
        }

        [HttpGet("{id}", Name ="GetCourse")]
        public IActionResult Get(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            var course = _coursesRepository.GetSingle(c => c.CourseID == id,
                c=>c.Department);

            if (course != null) {
                var courseVM = Mapper.Map<Course, CourseViewModel>(course);
                return Ok(courseVM);
            }
            return NotFound();

        }
        [HttpGet("departments")]
        public IActionResult GetDepartments()
        {
            var department = _coursesRepository.PopulateDepartmentDropdownList();
            if (department != null) {
                return Ok(department);
            }
            return StatusCode(500);
        }
    }
}
