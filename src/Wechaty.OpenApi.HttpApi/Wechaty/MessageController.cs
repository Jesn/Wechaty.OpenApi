using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Wechaty.Module.Filebox;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    [Area(OpenApiRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = OpenApiRemoteServiceConsts.RemoteServiceName)]
    [Route("api/message")]
    public class MessageController : OpenApiController, IMessageAppService
    {
        private readonly IMessageAppService _messageAppService;
        public MessageController(IMessageAppService messageAppService)
        {
            _messageAppService = messageAppService;
        }


        [HttpGet]
        [Route("messageContact")]
        public Task<string> MessageContactAsync(string messageId)
        {
            return _messageAppService.MessageContactAsync(messageId);
        }

        [HttpGet]
        [Route("messageFile")]
        public Task<FileBox> MessageFileAsync(string messageId)
        {
            return _messageAppService.MessageFileAsync(messageId);
        }

        [HttpGet]
        [Route("messageImage")]
        public Task<FileBox> MessageImageAsync(MessageImageInput input)
        {
            return _messageAppService.MessageImageAsync(input);
        }

        [HttpGet]
        [Route("messageImageStream")]
        public Task<byte[]> MessageImageStreamAsync(MessageImageInput input, CancellationToken cancellationToken = default)
        {
            return _messageAppService.MessageImageStreamAsync(input, cancellationToken);
        }

        [HttpGet]
        [Route("messageMiniProgram")]
        public Task<MiniProgramPayload> MessageMiniProgramAsync(string messageId)
        {
            return _messageAppService.MessageMiniProgramAsync(messageId);
        }

        [HttpGet]
        [Route("payload")]
        public Task<MessagePayload> MessagePayloadAsync(string messageId)
        {
            return _messageAppService.MessagePayloadAsync(messageId);
        }

        [HttpPut]
        [Route("recall")]
        public Task<bool> MessageRecallAsync(string messageId)
        {
            return _messageAppService.MessageRecallAsync(messageId);
        }

        [HttpPost]
        [Route("sendContact")]
        public Task<string> MessageSendContactAsync(SendContactInput input)
        {
            return _messageAppService.MessageSendContactAsync(input);
        }

        [HttpPost]
        [Route("sendFile")]
        public Task<string> MessageSendFileAsync(string conversationId, FileBox file)
        {
            return _messageAppService.MessageSendFileAsync(conversationId, file);
        }

        [HttpPost]
        [Route("sendMiniProgram")]
        public Task<string> MessageSendMiniProgramAsync(string conversationId, MiniProgramPayload miniProgramPayload)
        {
            return _messageAppService.MessageSendMiniProgramAsync(conversationId, miniProgramPayload);
        }

        [HttpPost]
        [Route("sendText")]
        public Task<string> MessageSendTextAsync(SendTextInput input)
        {
            return _messageAppService.MessageSendTextAsync(input);
        }

        [HttpPost]
        [Route("SendUrl/{conversationId}")]
        public Task<string> MessageSendUrlAsync(string conversationId, UrlLinkPayload urlLinkPayload)
        {
            return _messageAppService.MessageSendUrlAsync(conversationId, urlLinkPayload);
        }

        [HttpGet]
        [Route("messageUrl")]
        public Task<UrlLinkPayload> MessageUrlAsync(string messageId)
        {
            return _messageAppService.MessageUrlAsync(messageId);
        }
    }
}
