using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClientWeb.Pages
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string? Author { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CoursesModel : PageModel
    {
        public List<CourseDto> Courses { get; set; }

        public async Task OnGetAsync()
        {
            using var httpClient = new HttpClient();
            // Update the API URL as needed
            var apiUrl = "https://localhost:7224/api/course";
            Courses = await httpClient.GetFromJsonAsync<List<CourseDto>>(apiUrl) ?? new List<CourseDto>();
        }
    }
} 