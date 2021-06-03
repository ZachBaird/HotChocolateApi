using HotChocolate;
using HotChocolateApi.Extensions;
using HotChocolateApi.Gql.Db;
using HotChocolateApi.Gql.Db.DataLoader;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateApi.Gql.Queries
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] AppDbContext ctx) =>
            ctx.Speakers.ToListAsync();

        public Task<Speaker> GetSpeakerAsync(
            int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
