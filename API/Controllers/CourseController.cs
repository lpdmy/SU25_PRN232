using API.Dtos;
using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;

        public CourseController(ICourseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
        {
            var courses = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
        }

        // GET: api/Course/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetById(int id)
        {
            var course = await _service.GetByIdAsync(id);
            if (course == null) return NotFound();

            return Ok(_mapper.Map<CourseDto>(course));
        }

        // POST: api/Course
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Create([FromBody] CreateCourseDto dto)
        {
            var course = _mapper.Map<Course>(dto);
            await _service.CreateAsync(course);

            var resultDto = _mapper.Map<CourseDto>(course);
            return CreatedAtAction(nameof(GetById), new { id = course.CourseId }, resultDto);
        }

        // PUT: api/Course/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseDto dto)
        {
            var existingCourse = await _service.GetByIdAsync(id);
            if (existingCourse == null) return NotFound();

            _mapper.Map(dto, existingCourse);
            await _service.UpdateAsync(existingCourse);

            return NoContent();
        }

        // DELETE: api/Course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _service.GetByIdAsync(id);
            if (course == null) return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
