using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Wechaty.Module.Filebox;
using Wechaty.Module.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    [Area(OpenApiRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = OpenApiRemoteServiceConsts.RemoteServiceName)]
    [Route("api/room")]
    public class RoomController : OpenApiController, IRoomAppService
    {
        private readonly IRoomAppService _roomAppService;

        public RoomController(IRoomAppService roomAppService)
        {
            _roomAppService = roomAppService;
        }

        [HttpPost]
        [Route("Add")]
        public Task RoomAddAsync(string roomId, string contactId)
        {
            return _roomAppService.RoomAddAsync(roomId, contactId); 
        }

        [HttpGet]
        [Route("announce")]
        public Task<string> RoomAnnounceAsync(string roomId)
        {
            return _roomAppService.RoomAnnounceAsync(roomId);
        }

        [HttpPut]
        [Route("announce")]
        public Task RoomAnnounceAsync(string roomId, string text)
        {
            return _roomAppService.RoomAnnounceAsync(roomId, text);
        }

        [HttpGet]
        [Route("avatar")]
        public Task<FileBox> RoomAvatarAsync(string roomId)
        {
           return _roomAppService.RoomAvatarAsync(roomId);
        }

        [HttpPost]
        [Route("create")]
        public Task<string> RoomCreateAsync(IEnumerable<string> contactIdList, string topic)
        {
            return _roomAppService.RoomCreateAsync(contactIdList, topic);
        }

        [HttpDelete]
        [Route("delete")]
        public Task RoomDelAsync(string roomId, string contactId)
        {
            return _roomAppService.RoomDelAsync(roomId, contactId);
        }

        [HttpPut]
        [Route("accept")]
        public Task RoomInvitationAcceptAsync(string roomInvitationId)
        {
            return _roomAppService.RoomInvitationAcceptAsync(roomInvitationId);
        }

        [HttpGet]
        [Route("invitationPayload")]
        public Task<RoomInvitationPayload> RoomInvitationPayloadAsync(string roomInvitationId)
        {
            return _roomAppService.RoomInvitationPayloadAsync(roomInvitationId);
        }

        [HttpGet]
        [Route("list")]
        public Task<IReadOnlyList<string>> RoomListAsync()
        {
            return _roomAppService.RoomListAsync();
        }

        [HttpGet]
        [Route("members")]
        public Task<string[]> RoomMemberListAsync(string roomId)
        {
            return _roomAppService.RoomMemberListAsync(roomId);
        }

        [HttpGet]
        [Route("memberPayload")]
        public Task<RoomMemberPayload> RoomMemberPayloadAsync(string roomId, string contactId)
        {
           return _roomAppService.RoomMemberPayloadAsync(roomId, contactId);
        }

        [HttpGet]
        [Route("payload")]
        public Task<RoomPayload> RoomPayloadAsync(string roomId)
        {
            return _roomAppService.RoomPayloadAsync(roomId);
        }

        [HttpGet]
        [Route("qrcode")]
        public Task<string> RoomQRCodeAsync(string roomId)
        {
            return _roomAppService.RoomQRCodeAsync(roomId);
        }

        [HttpPut]
        [Route("quit")]
        public Task RoomQuitAsync(string roomId)
        {
            return _roomAppService.RoomQuitAsync(roomId);
        }

        //这个其实也是更新操作，暂时先停用该接口
        //[HttpGet]
        //[Route("topic")]
        //public Task<string> RoomTopicAsync(string roomId)
        //{
        //    return _roomAppService.RoomTopicAsync(roomId);
        //}

        [HttpPut]
        [Route("topic")]
        public Task RoomTopicAsync(string roomId, string topic)
        {
            return _roomAppService.RoomTopicAsync(roomId,topic);
        }
    }
}
