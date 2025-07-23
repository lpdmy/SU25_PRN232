using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ClientWeb.Pages
{
    public class CourseDetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public CourseDto? Course { get; set; }
        public string? SuccessMessage { get; set; }

        public async Task OnGetAsync()
        {
            using var httpClient = new HttpClient();
            var apiUrl = $"https://localhost:7224/api/course/{Id}";
            Course = await httpClient.GetFromJsonAsync<CourseDto>(apiUrl);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Try to get UserId from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                // Not logged in, redirect to login or show error
                SuccessMessage = "You must be logged in to register.";
                await OnGetAsync();
                return Page();
            }
            var enrollment = new { UserId = userId.Value, CourseId = Id };
            using var httpClient = new HttpClient();
            var enrollUrl = "https://localhost:7224/api/enrollment";
            var response = await httpClient.PostAsJsonAsync(enrollUrl, enrollment);
            if (response.IsSuccessStatusCode)
            {
                SuccessMessage = "Successfully enrolled!";
                await OnGetAsync(); // Refresh course details
            }
            else
            {
                SuccessMessage = "Registration failed.";
            }
            return Page();
        }
    }
} 