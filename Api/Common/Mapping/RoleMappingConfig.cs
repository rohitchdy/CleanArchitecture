using Api.Requests.Authentication;
using Api.Requests.Role;
using Application.Roles.Common;
using Mapster;

namespace Api.Common.Mapping;
public class RoleMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RoleResult, RoleResponse>()
            .Map(dest => dest, src => src);
    }
}
