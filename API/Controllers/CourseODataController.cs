using API.Dtos;
using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Services.Interfaces;

namespace API.Controllers.OData
{
    [ApiExplorerSettings(IgnoreApi = true)] 
    public class CourseODataController : ODataController
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseODataController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courses = await _courseService.GetAllAsync();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(courseDtos);
        }
    }
}
