using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace API.Dtos
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<CourseDto>("CourseOData");
            builder.EntityType<CourseDto>().HasKey(c => c.CourseId);

            return builder.GetEdmModel();
        }
    }
}
