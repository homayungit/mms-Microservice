using BuildingBlocks.CQRS;
using Configure.API.Models;
using Marten;

namespace Configure.API.Features.ConfigureTypeInfo.GetConfigureDatas;

public record GetConfigureTypesQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetConfigureResult>;
public record GetConfigureResult(IEnumerable<ConfigureType> ConfigureTypes);

public class GetConfigureTypeHandler(IDocumentSession session):IQueryHandler<GetConfigureTypesQuery, GetConfigureResult>
{
    public async Task<GetConfigureResult> Handle(GetConfigureTypesQuery request, CancellationToken cancellationToken)
    {
        var query = session.Query<ConfigureType>().AsQueryable();
        if (request.PageNumber.HasValue && request.PageSize.HasValue)
        {
            query = query.Skip((request.PageNumber.Value - 1) * request.PageSize.Value).Take(request.PageSize.Value);
        }
        var configureTypes = await query.ToListAsync(cancellationToken);
        return new GetConfigureResult(configureTypes);
    }
}