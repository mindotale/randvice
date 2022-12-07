using Mapster;
using Randvice.Contracts.V1.Identity;
using Randvice.Core.Identity;

namespace Randvice.Api.Mappings;

public class IdentityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginUserRequest, LoginUserCommand>();
    }
}
