using Carter;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Vertical_Slice_Minimal_API.Features.Students
{
    public class GetStudent : ICarterModule
    {
        private readonly listdata data = new listdata(); // Instantiate the data handler

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            // Map GET route to handle fetching all students
            app.MapGet("api/Students/data", data.HandleAll).WithTags("Students");
        }
    }
    public class listdata
    {
        public record Request(int Id, string Name, string? Address, string? Remarks);
        public record Response(int Id, bool? MessageType, string? Message);

        private readonly List<Request> Students = new()
        {
            new Request(1, "John Doe", "123 Main St", "No remarks"),
            new Request(2, "Jane Smith", "456 Elm St", "Excellent student")
        };

        // Handler to fetch all students
        public async Task<Results<Ok<IEnumerable<Request>>, NotFound<Response>>> HandleAll()
        {
            if (Students.Any())
            {
                return TypedResults.Ok((IEnumerable<Request>)Students);
            }

            return TypedResults.NotFound(new Response(0, false, "No students found"));
        }
    }
}
