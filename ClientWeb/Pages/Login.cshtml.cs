using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClientWeb.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            var loginDto = new { Email, Password };
            using var httpClient = new HttpClient();
            var apiUrl = "https://localhost:7224/api/user/login";
            var response = await httpClient.PostAsJsonAsync(apiUrl, loginDto);
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserDto>();
                if (user != null && user.UserId > 0)
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    return RedirectToPage("/Courses");
                }
            }
            ErrorMessage = "Invalid email or password.";
            return Page();
        }

        public class UserDto
        {
            public int UserId { get; set; }
            public string Email { get; set; }
        }
    }
} 