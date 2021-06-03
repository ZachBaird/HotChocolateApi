using HotChocolateApi.Gql.Db;

namespace HotChocolateApi.Gql.Types
{
    public class AddSpeakerPayload
    {
        public AddSpeakerPayload(Speaker speaker)
        {
            Speaker = speaker;
        }

        public Speaker Speaker { get; }
    }
}
