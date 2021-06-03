namespace HotChocolateApi.Gql.Types
{
    public record AddSpeakerInput(
        string Name,
        string? Bio,
        string? WebSite);
}
