using API.Dtos;
using AutoMapper;
using DataAccess.Models;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Course mapping
            CreateMap<Course, CourseDto>();
            CreateMap<CreateCourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>();

            // User mapping
            //CreateMap<User, UserDto>();
            //CreateMap<CreateUserDto, User>();
            //CreateMap<UpdateUserDto, User>();

            // Category mapping
            //CreateMap<Category, CategoryDto>();
            //CreateMap<CreateCategoryDto, Category>();
            //CreateMap<UpdateCategoryDto, Category>();

            // Enrollment mapping
            //CreateMap<Enrollment, EnrollmentDto>();
            //CreateMap<CreateEnrollmentDto, Enrollment>();
            //CreateMap<UpdateEnrollmentDto, Enrollment>();
        }
    }
}
