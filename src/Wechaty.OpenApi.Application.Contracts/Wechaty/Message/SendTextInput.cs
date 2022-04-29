using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechaty.OpenApi.Wechaty
{
    public class SendTextInput
    {
        [Required]
        public string ConversationId { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> MentionIdList { get; set; }
    }
}
