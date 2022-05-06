using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Wechaty.Grpc.Client;
using Wechaty.GrpcClient.Factory;

namespace Wechaty.OpenApi;

public abstract class OpenApiAppService : ApplicationService
{
    protected readonly IGrpcClientFactory _grpcClientFactory;
    protected readonly WechatyPuppetClient _grpcClient;

    //protected OpenApiAppService()
    //{
    //    ObjectMapperContext = typeof(OpenApiApplicationModule);
    //}

    protected OpenApiAppService(IGrpcClientFactory grpcClientFactory)
    {
        ObjectMapperContext = typeof(OpenApiApplicationModule);

        _grpcClientFactory = grpcClientFactory;
        _grpcClient = _grpcClientFactory.GetClient(WechatyPuppetConst.DefaultPuppetClientName);
    }

}
