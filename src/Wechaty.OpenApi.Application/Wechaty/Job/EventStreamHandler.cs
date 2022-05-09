using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Wechaty.OpenApi.Handler;

namespace Wechaty.OpenApi.Wechaty
{
    public class EventStreamHandler :
        IDistributedEventHandler<EventStreamHandlerArgs>,
        ITransientDependency
    {
        public async Task HandleEventAsync(EventStreamHandlerArgs eventStream)
        {
            Console.WriteLine(eventStream.ToString());
        }
    }

    public class EventStreamHandlerV2 :
        IDistributedEventHandler<EventStreamHandlerArgs>,
        ITransientDependency
    {
        public async Task HandleEventAsync(EventStreamHandlerArgs eventStream)
        {
            Console.WriteLine($"当前时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},Event:${eventStream.ToString()}");
        }
    }

    public class EventStreamHandlerV3 :
        IDistributedEventHandler<EventStreamHandlerArgs>,
        ITransientDependency
    {
        public async Task HandleEventAsync(EventStreamHandlerArgs eventStream)
        {
            Console.WriteLine($"中国时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},Event:${eventStream.ToString()}");
        }
    }
}
