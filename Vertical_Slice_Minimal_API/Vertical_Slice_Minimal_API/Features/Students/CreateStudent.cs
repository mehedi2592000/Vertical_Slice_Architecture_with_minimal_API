using Carter;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Vertical_Slice_Minimal_API.Features.Students
{
    //public class CreateStudent : ICarterModule
    //{
    //    public void AddRoutes(IEndpointRouteBuilder app)
    //    {
    //        app.MapPost("api/Students", Handle);
    //    }

    //    public record Request(int Id, string Name, string? Address, string? Remarks);
    //    public record Response(int Id, bool? MessageType);

    //    public async Task<Results<Ok<Response>,NotFound<Response>>> Handle(Request request)
    //    {
    //        List<Request> routes = new List<Request>();
    //        routes.Add(request);


    //        return TypedResults.Ok(new Response(request.Id, true));
    //    }
    //}

    public class CreateStudent : ICarterModule
    {
        private readonly handledata handleDataInstance = new handledata(); // Instantiate handler data class

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            // Map POST route to handle student creation
            app.MapPost("api/Students", handleDataInstance.Handle).WithTags("Students");
        }
    }

    public class handledata
    {
        public record Request(int Id, string Name, string? Address, string? Remarks);
        public record Response(int Id, bool? MessageType);

        // Handler to process student creation
        public async Task<Results<Ok<Response>, NotFound<Response>>> Handle(Request request)
        {
            // Handle the request and return a response
            return TypedResults.Ok(new Response(request.Id, true));
        }
    }
}
