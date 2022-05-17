using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wechaty.Module.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public interface IFriendShipAppService: IApplicationService
    {
        Task<FriendshipPayload> FriendshipPayloadAsync(string friendshipId);
        Task FriendshipAcceptAsync(string friendshipId);
        Task FriendshipAddAsync(AddFriendShipInput input);
        Task<string?> FriendshipSearchPhoneAsync(string phone);
        Task<string?> FriendshipSearchWeixinAsync(string weixin);
    }

}
