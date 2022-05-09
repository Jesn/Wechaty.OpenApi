using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Wechaty.OpenApi.Handler
{
    public class EventStreamHandler :
         IDistributedEventHandler<EventStreamHandlerArgs>,
         ITransientDependency
    {

        private readonly IHubContext<EventHub> _hubContext;

        public EventStreamHandler(IHubContext<EventHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task HandleEventAsync(EventStreamHandlerArgs eventData)
        {

            Console.WriteLine("SignalR 发送事件触发");

            //await _hubContext.Clients
            //    .User(eventData.UserId.ToString())
            //    .SendAsync("event", eventData.BotName, eventData.EventResponse);
        }
    }
}
