using Mapster;
using N5_Web_Api.Controllers.Dtos;

namespace N5_Web_Api.Controllers;

public class V1DtoMapperRegistry : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType(typeof(CollectionResult<>), typeof(ListResult<>));
    }
}
