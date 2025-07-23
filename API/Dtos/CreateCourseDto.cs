﻿namespace API.Dtos
{
    public class CreateCourseDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }

}
