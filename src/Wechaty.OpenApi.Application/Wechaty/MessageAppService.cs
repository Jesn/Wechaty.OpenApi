using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wechaty.Grpc.Client;
using Wechaty.GrpcClient.Factory;
using Wechaty.Module.Filebox;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public class MessageAppService : OpenApiAppService, IMessageAppService
    {
        private readonly IGrpcClientFactory _grpcClientFactory;
        private readonly WechatyPuppetClient _grpcClient;
        public MessageAppService(IGrpcClientFactory grpcClientFactory)
        {
            _grpcClientFactory = grpcClientFactory;
            _grpcClient = _grpcClientFactory.GetClient("Demo");
        }

        public async Task<string> MessageContactAsync(string messageId)
        {
            var response = await _grpcClient.MessageContactAsync(messageId);
            return response;
        }

        public async Task<FileBox> MessageFileAsync(string messageId)
        {
            var response = await _grpcClient.MessageFileAsync(messageId);
            return response;
        }

        public async Task<FileBox> MessageImageAsync(string messageId, ImageType imageType)
        {
            var response = await _grpcClient.MessageImageAsync(messageId, imageType);
            return response;
        }

        public async Task<byte[]> MessageImageStreamAsync(string messageId, ImageType imageType, CancellationToken cancellationToken = default)
        {
            var response = await _grpcClient.MessageImageStreamAsync(messageId, imageType, cancellationToken);
            return response;
        }

        public async Task<MiniProgramPayload> MessageMiniProgramAsync(string messageId)
        {
            var payload = await _grpcClient.MessageMiniProgramAsync(messageId);
            return payload;
        }

        public async Task<MessagePayload> MessagePayloadAsync(string messageId)
        {
            var payload = await _grpcClient.MessagePayloadAsync(messageId);
            return payload;
        }

        public async Task<bool> MessageRecallAsync(string messageId)
        {
            var result = await _grpcClient.MessageRecallAsync(messageId);
            return result;
        }

        public async Task<string> MessageSendContactAsync(string conversationId, string contactId)
        {
            var response = await _grpcClient.MessageSendContactAsync(conversationId, contactId);
            return response;
        }

        public async Task<string> MessageSendFileAsync(string conversationId, FileBox file)
        {
            var response = await _grpcClient.MessageSendFileAsync(conversationId, file);
            return response;
        }

        public async Task<string> MessageSendMiniProgramAsync(string conversationId, MiniProgramPayload miniProgramPayload)
        {
            var response = await _grpcClient.MessageSendMiniProgramAsync(conversationId, miniProgramPayload);
            return response;
        }

        public async Task<string> MessageSendTextAsync(string conversationId, string text, params string[] mentionIdList)
        {
            var response = await _grpcClient.MessageSendTextAsync(conversationId, text, mentionIdList);
            return response;
        }

        public async Task<string> MessageSendTextAsync(string conversationId, string text, IEnumerable<string> mentionIdList)
        {
            var response = await _grpcClient.MessageSendTextAsync(conversationId, text, mentionIdList);
            return response;
        }

        public async Task<string> MessageSendUrlAsync(string conversationId, UrlLinkPayload urlLinkPayload)
        {
            var response = await _grpcClient.MessageSendUrlAsync(conversationId, urlLinkPayload);
            return response;
        }

        public async Task<UrlLinkPayload> MessageUrlAsync(string messageId)
        {
            var response = await _grpcClient.MessageUrlAsync(messageId);
            return response;
        }
    }
}
