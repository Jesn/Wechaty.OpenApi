using System;
namespace Wechaty.OpenApi.Handler
{
    public class EventStreamHandlerArgs
    {
        public string UserId { get; set; }
        public string BotName { get; set; }
    
        public EventResponse EventResponse { get; set; }
    }

    public class EventResponse
    {
        public EventType EventType { get; set; }
        public string Payload { get; set; }
    }




    public enum EventType
    {
        Unspecified = 0,
        Heartbeat = 1,
        Message = 2,
        Dong = 3,
        Post = 4,
        Error = 16,
        Friendship = 17,
        RoomInvite = 18,
        RoomJoin = 19,
        RoomLeave = 20,
        RoomTopic = 21,
        Scan = 22,
        Ready = 23,
        Reset = 24,
        Login = 25,
        Logout = 26,
        Dirty = 27,
    }
}
