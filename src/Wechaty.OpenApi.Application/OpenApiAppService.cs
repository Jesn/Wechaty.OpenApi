using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;
using Wechaty.Grpc.Client;
using Wechaty.GrpcClient.Factory;

namespace Wechaty.OpenApi;

[Authorize]
public abstract class OpenApiAppService : ApplicationService
{
    protected readonly IGrpcClientFactory _grpcClientFactory;
    protected readonly WechatyPuppetClient _grpcClient;
    protected readonly ICurrentUser _currentUser;

    //protected OpenApiAppService()
    //{
    //    ObjectMapperContext = typeof(OpenApiApplicationModule);
    //}

    protected OpenApiAppService(IGrpcClientFactory grpcClientFactory, ICurrentUser currentUser)
    {
        ObjectMapperContext = typeof(OpenApiApplicationModule);

        _currentUser = currentUser;

        _grpcClientFactory = grpcClientFactory;
        _grpcClient = _grpcClientFactory.GetClient(WechatyPuppetConst.DefaultPuppetClientName);
    }

}
