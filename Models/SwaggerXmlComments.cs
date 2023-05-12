using Swashbuckle.AspNetCore.SwaggerGen;

namespace API2.Models
{
    public class SwaggerXmlComments : IOperationFilter
    {
        public void Apply(Microsoft.OpenApi.Models.OpenApiOperation operation, OperationFilterContext context)
        {
            var xmlComments = context.ApiDescription
                .ActionDescriptor
                .EndpointMetadata
                .OfType<XmlCommentsOperationFilter>()
                .SingleOrDefault();

        }
    }
}
