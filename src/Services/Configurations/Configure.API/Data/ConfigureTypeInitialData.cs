using Configure.API.Models;
using Marten;
using Marten.Schema;

namespace Configure.API.Data;

public class ConfigureTypeInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<ConfigureType>().AnyAsync())
            return;

        // Marten UPSERT will cater for existing records
        session.Store<ConfigureType>(GetPreconfigureType());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<ConfigureType> GetPreconfigureType() => new List<ConfigureType>()
    {
       new ConfigureType
        {
            SerialNo = 1,
            Name = "ConfigureType1",
            PowerNumber = 1,
            ChildYesNo = 0,
            ParentId = null,
            ParentGroupType = 0,
            DDLParentId = null,
            Active = 1
        },
    };
    
}

