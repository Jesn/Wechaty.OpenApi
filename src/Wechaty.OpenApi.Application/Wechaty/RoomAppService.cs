using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wechaty.Grpc.Client;
using Wechaty.GrpcClient.Factory;
using Wechaty.Module.Filebox;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public class RoomAppService : OpenApiAppService, IRoomAppService
    {
        public RoomAppService(IGrpcClientFactory grpcClientFactory)
            :base(grpcClientFactory)
        {

        }

        public async Task RoomAddAsync(string roomId, string contactId)
        {
            await _grpcClient.RoomAddAsync(roomId, contactId);
        }

        public async Task<string> RoomAnnounceAsync(string roomId)
        {
            var response = await _grpcClient.RoomAnnounceAsync(roomId);
            return response;
        }

        public async Task RoomAnnounceAsync(string roomId, string text)
        {
            await _grpcClient.RoomAnnounceAsync(roomId, text);
        }

        public async Task<FileBox> RoomAvatarAsync(string roomId)
        {
            var response = await _grpcClient.RoomAvatarAsync(roomId);
            return response;
        }

        public async Task<string> RoomCreateAsync(IEnumerable<string> contactIdList, string topic)
        {
            var response = await _grpcClient.RoomCreateAsync(contactIdList, topic);
            return response;
        }

        public async Task RoomDelAsync(string roomId, string contactId)
        {
            await _grpcClient.RoomDelAsync(roomId, contactId);
        }

        public async Task RoomInvitationAcceptAsync(string roomInvitationId)
        {
            await _grpcClient.RoomInvitationAcceptAsync(roomInvitationId);
        }

        public async Task<RoomInvitationPayload> RoomInvitationPayloadAsync(string roomInvitationId)
        {
            var payload = await _grpcClient.RoomInvitationPayloadAsync(roomInvitationId);
            return payload;
        }

        public async Task<IReadOnlyList<string>> RoomListAsync()
        {
            var list = await _grpcClient.RoomListAsync();
            return list;
        }

        public async Task<string[]> RoomMemberListAsync(string roomId)
        {
            var members = await _grpcClient.RoomMemberListAsync(roomId);
            return members;
        }

        public async Task<RoomMemberPayload> RoomMemberPayloadAsync(string roomId, string contactId)
        {
            var payload = await _grpcClient.RoomMemberPayloadAsync(roomId, contactId);
            return payload;
        }

        public async Task<RoomPayload> RoomPayloadAsync(string roomId)
        {
            var payload = await _grpcClient.RoomPayloadAsync(roomId);
            return payload;
        }

        public async Task<string> RoomQRCodeAsync(string roomId)
        {
            var qrCode = await _grpcClient.RoomQRCodeAsync(roomId);
            return qrCode;
        }

        public async Task RoomQuitAsync(string roomId)
        {
            await _grpcClient.RoomQuitAsync(roomId);
        }

        public async Task<string> RoomTopicAsync(string roomId)
        {
            var topic = await _grpcClient.RoomTopicAsync(roomId);
            return topic;
        }

        public async Task RoomTopicAsync(string roomId, string topic)
        {
            await _grpcClient.RoomTopicAsync(roomId, topic);
        }
    }
}
