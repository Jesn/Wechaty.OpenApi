using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wechaty.Module.Filebox;
using Wechaty.Module.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public interface  IMessageAppService: IApplicationService
    {
        Task<MessagePayload> MessagePayloadAsync(string messageId);
        Task<string> MessageContactAsync(string messageId);
        Task<FileBox> MessageFileAsync(string messageId);
        Task<FileBox> MessageImageAsync(MessageImageInput input);
        Task<byte[]> MessageImageStreamAsync(MessageImageInput  input, CancellationToken cancellationToken = default);
        Task<MiniProgramPayload> MessageMiniProgramAsync(string messageId);
        Task<bool> MessageRecallAsync(string messageId);
        Task<string?> MessageSendContactAsync(SendContactInput input);
        Task<string?> MessageSendFileAsync(string conversationId, FileBox file);
        Task<string?> MessageSendMiniProgramAsync(string conversationId, MiniProgramPayload miniProgramPayload);
        Task<string?> MessageSendTextAsync(SendTextInput input);
        Task<string?> MessageSendUrlAsync(string conversationId, UrlLinkPayload urlLinkPayload);
        Task<UrlLinkPayload> MessageUrlAsync(string messageId);
    }
}
