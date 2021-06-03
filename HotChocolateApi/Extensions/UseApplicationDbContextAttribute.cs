using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolateApi.Gql.Db;
using System.Reflection;

namespace HotChocolateApi.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseDbContext<AppDbContext>();
        }
    }
}
