using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public interface IFriendShipAppService: IApplicationService
    {
        Task<FriendshipPayload> FriendshipPayloadAsync(string friendshipId);
        Task FriendshipAcceptAsync(string friendshipId);
        Task FriendshipAddAsync(string contactId, string? hello);
        Task<string?> FriendshipSearchPhoneAsync(string phone);
        Task<string?> FriendshipSearchWeixinAsync(string weixin);
    }

}
