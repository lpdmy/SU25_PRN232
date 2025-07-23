namespace API.Dtos
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

}
