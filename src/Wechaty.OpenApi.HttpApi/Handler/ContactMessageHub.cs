using System.Threading.Tasks;
using Volo.Abp.AspNetCore.SignalR;
using Wechaty.Module.Puppet.Schemas;
using Wechaty.OpenApi.Wechaty;

namespace Wechaty.OpenApi.Handler
{
    public class ContactMessageHub : AbpHub
    {
        private readonly IMessageAppService _messageAppService;

        public ContactMessageHub(IMessageAppService messageAppService)
        {
            _messageAppService = messageAppService;
        }

        /// <summary>
        /// 发送文本
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> SendText(SendTextInput input)
        {
            var text = await _messageAppService.MessageSendTextAsync(input);
            return text;
        }

        /// <summary>
        /// 发送小程序
        /// </summary>
        /// <param name="conversationId"></param>
        /// <param name="miniProgramPayload"></param>
        /// <returns></returns>
        public async Task SendMiniProgram(string conversationId, MiniProgramPayload miniProgramPayload)
        {
            await _messageAppService.MessageSendMiniProgramAsync(conversationId, miniProgramPayload);
        }
    }
}
