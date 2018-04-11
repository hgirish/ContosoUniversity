using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Api.Core;
using ContosoUniversity.Data.Abstract;
using ContosoUniversity.Model;
using ContosoUniversity.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoUniversity.Api.Controllers
{
   
    [Route("api/[controller]")]
    public class InstructorsController : Controller
    {
        private readonly IInstructorsRepository _instructorsRepository;
        
        int page = 1;
        int pageSize = 4;
        public InstructorsController(IInstructorsRepository instructorsRepository
            )
        {
            _instructorsRepository = instructorsRepository;
           
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination)) {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);

            }

            int currentPage = page;
            int currentPageSize = pageSize;

            var totalInstructors = await _instructorsRepository.CountsAsync();
            var totalPages = (int)Math.Ceiling((double)totalInstructors / pageSize);

            IEnumerable<Instructor> instructors = _instructorsRepository
                .GetAllInstructors()
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            Response.AddPagination(page, pageSize, totalInstructors, totalPages);

            IEnumerable<InstructorViewModel> vm = Mapper.Map<IEnumerable<Instructor>, IEnumerable<InstructorViewModel>>(instructors);

            return Ok(vm);
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="GetInstuctor")]
        public IActionResult Get(int id)
        {
            Instructor instructor = _instructorsRepository
                .GetSingle(i => i.InstructorID == id, i => i.CourseAssignments, 
                i => i.OfficeAssignment);

            if (instructor != null)
            {
                InstructorEditViewModel vm = Mapper.Map<Instructor, InstructorEditViewModel>(instructor);
                vm.AssignedCourses = _instructorsRepository.GetAssignedCourses(instructor);

                return Ok(vm);

            }
            return NotFound();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
