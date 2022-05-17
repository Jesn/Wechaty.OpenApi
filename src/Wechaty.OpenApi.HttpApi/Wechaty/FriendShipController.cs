using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Wechaty.Module.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    [Area(OpenApiRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = OpenApiRemoteServiceConsts.RemoteServiceName)]
    [Route("api/friendship")]
    public class FriendShipController : OpenApiController, IFriendShipAppService
    {
        private IFriendShipAppService _friendShipAppService;
        public FriendShipController(IFriendShipAppService friendShipAppService)
        {
            _friendShipAppService = friendShipAppService;
        }

        [HttpPut]
        [Route("accept")]
        public Task FriendshipAcceptAsync(string friendshipId)
        {
            return _friendShipAppService.FriendshipAcceptAsync(friendshipId);
        }

        [HttpPut]
        [Route("addFriend")]
        public Task FriendshipAddAsync(AddFriendShipInput input)
        {
            return _friendShipAppService.FriendshipAddAsync(input);
        }

        [HttpGet]
        [Route("payload")]
        public Task<FriendshipPayload> FriendshipPayloadAsync(string friendshipId)
        {
            return _friendShipAppService.FriendshipPayloadAsync(friendshipId);
        }

        [HttpGet]
        [Route("searchByPhone")]
        public Task<string> FriendshipSearchPhoneAsync(string phone)
        {
            return _friendShipAppService.FriendshipSearchPhoneAsync(phone);
        }

        [HttpGet]
        [Route("searchByWeiXin")]
        public Task<string> FriendshipSearchWeixinAsync(string weixin)
        {
            return _friendShipAppService.FriendshipSearchWeixinAsync(weixin);
        }
    }
}
