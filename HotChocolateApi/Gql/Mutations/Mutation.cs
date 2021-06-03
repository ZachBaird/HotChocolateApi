using HotChocolate;
using HotChocolateApi.Extensions;
using HotChocolateApi.Gql.Db;
using HotChocolateApi.Gql.Types;
using System.Threading.Tasks;

namespace HotChocolateApi.Gql.Mutations
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [ScopedService] AppDbContext ctx)
        {
            var speaker = new Speaker()
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            ctx.Speakers.Add(speaker);
            await ctx.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
    }
}
