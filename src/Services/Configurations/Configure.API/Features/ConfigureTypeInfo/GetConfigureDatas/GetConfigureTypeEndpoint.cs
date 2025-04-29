using Carter;
using Configure.API.Models;
using MediatR;

namespace Configure.API.Features.ConfigureTypeInfo.GetConfigureDatas;

public record GetConfigureTypesRequest(int? PageNumber = 1, int? PageSize = 10);
public record GetConfigureTypesResponse(IEnumerable<ConfigureType>ConfigureTypes);

public class GetConfigureTypeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/configuretypes", async ([AsParameters] GetConfigureTypesRequest request, ISender queryProcessor) =>
        {
            var result = await queryProcessor.Send(new GetConfigureTypesQuery(request.PageNumber, request.PageSize));
            return Results.Ok(result);
        })
        .WithName("GetConfigureTypes")
        .Produces<GetConfigureTypesResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithTags("ConfigureTypeEndpoints");
    }
}

