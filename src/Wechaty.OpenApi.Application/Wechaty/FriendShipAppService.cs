using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Volo.Abp.Users;
using Wechaty.Grpc.Client;
using Wechaty.GrpcClient.Factory;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public class FriendShipAppService : OpenApiAppService, IFriendShipAppService
    {
        public FriendShipAppService(IGrpcClientFactory grpcClientFactory, ICurrentUser currentUser)
            :base(grpcClientFactory,currentUser)
        {
           
        }

        public async Task FriendshipAcceptAsync(string friendshipId)
        {
            await _grpcClient.FriendshipAcceptAsync(friendshipId);
        }

        public async Task FriendshipAddAsync(AddFriendShipInput input)
        {
            await _grpcClient.FriendshipAddAsync(input.ContactId, input.Hello);
        }

        public async Task<FriendshipPayload> FriendshipPayloadAsync(string friendshipId)
        {
            var response = await _grpcClient.FriendshipPayloadAsync(friendshipId);
            return response;
        }

        public async Task<string> FriendshipSearchPhoneAsync(string phone)
        {
            var response = await _grpcClient.FriendshipSearchPhoneAsync(phone);
            return response;
        }

        public async Task<string> FriendshipSearchWeixinAsync(string weixin)
        {
            var response = await _grpcClient.FriendshipSearchWeixinAsync(weixin);
            return response;
        }
    }
}
