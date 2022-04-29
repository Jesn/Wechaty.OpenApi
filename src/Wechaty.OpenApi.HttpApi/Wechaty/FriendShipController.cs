using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Wechaty.Module.Puppet.Schemas;

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

        [HttpGet]
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
        [Route("SearchByPhone")]
        public Task<string> FriendshipSearchPhoneAsync(string phone)
        {
            return _friendShipAppService.FriendshipSearchPhoneAsync(phone);
        }

        [HttpGet]
        [Route("SearchByWeiXin")]
        public Task<string> FriendshipSearchWeixinAsync(string weixin)
        {
            return _friendShipAppService.FriendshipSearchWeixinAsync(weixin);
        }
    }
}
