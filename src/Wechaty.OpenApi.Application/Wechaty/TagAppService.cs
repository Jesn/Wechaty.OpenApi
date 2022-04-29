using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wechaty.Grpc.Client;
using Wechaty.GrpcClient.Factory;

namespace Wechaty.OpenApi.Wechaty
{
    public class TagAppService : OpenApiAppService, ITagAppService
    {
        private readonly IGrpcClientFactory _grpcClientFactory;
        private readonly WechatyPuppetClient _grpcClient;
        public TagAppService(IGrpcClientFactory grpcClientFactory)
        {
            _grpcClientFactory = grpcClientFactory;
            _grpcClient = _grpcClientFactory.GetClient("Demo");
        }

        public async Task TagContactAddAsync(string tagId, string contactId)
        {
           await _grpcClient.TagContactAddAsync(tagId, contactId);
        }

        public async Task TagContactDeleteAsync(string tagId)
        {
            await _grpcClient.TagContactDeleteAsync(tagId);
        }

        public async Task<List<string>> TagContactListAsync(string contactId)
        {
            var list = await _grpcClient.TagContactListAsync(contactId);
            return list;
        }

        public async Task<List<string>> TagContactListAsync()
        {
            var list = await _grpcClient.TagContactListAsync();
            return list;
        }

        public async Task TagContactRemoveAsync(string tagId, string contactId)
        {
            await _grpcClient.TagContactRemoveAsync(tagId, contactId);
        }
    }
}
