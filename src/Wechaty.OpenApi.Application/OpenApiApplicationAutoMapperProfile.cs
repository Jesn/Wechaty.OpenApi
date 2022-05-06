﻿using AutoMapper;
using Wechaty.Grpc.Client;
using Wechaty.OpenApi.Wechaty;

namespace Wechaty.OpenApi;

public class OpenApiApplicationAutoMapperProfile : Profile
{
    public OpenApiApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<WechatyOption, GrpcPuppetOption>();
    }
}
