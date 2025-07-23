using System.ComponentModel.DataAnnotations;

namespace API.Dtos
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

}
