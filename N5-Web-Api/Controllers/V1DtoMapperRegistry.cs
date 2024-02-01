using Common.Utils;
using Mapster;
using N5_Web_Api.Controllers.Dtos;
using N5_Web_Api.Controllers.Dtos.Permissions;

namespace N5_Web_Api.Controllers;

public class V1DtoMapperRegistry : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType(typeof(CollectionResult<>), typeof(ListResult<>));

        PermissionDto.ConfigureMapper(config);
    }
}
