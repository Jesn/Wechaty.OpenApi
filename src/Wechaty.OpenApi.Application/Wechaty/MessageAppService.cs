using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Users;
using Wechaty.Grpc.Client;
using Wechaty.GrpcClient.Factory;
using Wechaty.Module.Filebox;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public class MessageAppService : OpenApiAppService, IMessageAppService
    {
        public MessageAppService(IGrpcClientFactory grpcClientFactory, ICurrentUser currentUser)
            :base(grpcClientFactory,currentUser)
        {
          
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

        public async Task<FileBox> MessageImageAsync(MessageImageInput input)
        {
            var response = await _grpcClient.MessageImageAsync(input.MessageId, input.ImageType);
            return response;
        }

        public async Task<byte[]> MessageImageStreamAsync(MessageImageInput input, CancellationToken cancellationToken = default)
        {
            var response = await _grpcClient.MessageImageStreamAsync(input.MessageId, input.ImageType, cancellationToken);
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

        public async Task<string> MessageSendContactAsync(SendContactInput input)
        {
            var response = await _grpcClient.MessageSendContactAsync(input.ConversationId, input.ContactId);
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

        public async Task<string> MessageSendTextAsync(SendTextInput input)
        {
            var response = await _grpcClient.MessageSendTextAsync(input.ConversationId, input.Text, input.MentionIdList);
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
