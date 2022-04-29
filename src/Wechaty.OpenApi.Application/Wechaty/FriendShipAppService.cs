using System.Threading.Tasks;
using Wechaty.Grpc.Client;
using Wechaty.GrpcClient.Factory;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public class FriendShipAppService:OpenApiAppService,IFriendShipAppService
    {
        private readonly IGrpcClientFactory _grpcClientFactory;
        private readonly WechatyPuppetClient _grpcClient;
        public FriendShipAppService(IGrpcClientFactory grpcClientFactory)
        {
            _grpcClientFactory = grpcClientFactory;
            _grpcClient = _grpcClientFactory.GetClient("Demo");
        }

        public async Task FriendshipAcceptAsync(string friendshipId)
        {
            await _grpcClient.FriendshipAcceptAsync(friendshipId);
        }

        public async Task FriendshipAddAsync(string contactId, string hello)
        {
            await _grpcClient.FriendshipAddAsync(contactId, hello);
        }

        public async Task<FriendshipPayload> FriendshipPayloadAsync(string friendshipId)
        {
            var response = await _grpcClient.FriendshipPayloadAsync(friendshipId);
            return response;
        }

        public async Task<string> FriendshipSearchPhoneAsync(string phone)
        {
           var response=await _grpcClient.FriendshipSearchPhoneAsync(phone);
            return response;
        }

        public async Task<string> FriendshipSearchWeixinAsync(string weixin)
        {
            var response=await _grpcClient.FriendshipSearchWeixinAsync(weixin);
            return response;
        }
    }
}
