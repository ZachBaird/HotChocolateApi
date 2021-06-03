using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateApi.Gql.Db.DataLoader
{
    public class SpeakerByIdDataLoader : BatchDataLoader<int, Speaker>
    {
        private readonly IDbContextFactory<AppDbContext> _dbCtxFactory;

        public SpeakerByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<AppDbContext> dbCtxFactory)
            : base (batchScheduler)
        {
            _dbCtxFactory = dbCtxFactory ??
                throw new ArgumentNullException(nameof(dbCtxFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Speaker>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using AppDbContext dbCtx = _dbCtxFactory.CreateDbContext();

            return await dbCtx.Speakers
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
