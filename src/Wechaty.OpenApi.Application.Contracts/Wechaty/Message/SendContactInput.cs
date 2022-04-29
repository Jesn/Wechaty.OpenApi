using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechaty.OpenApi.Wechaty
{
    public class SendContactInput
    {
        public string ConversationId { get; set; }

        public string ContactId { get; set; }
    }
}
