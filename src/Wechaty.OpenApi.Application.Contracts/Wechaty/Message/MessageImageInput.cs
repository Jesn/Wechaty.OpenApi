using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public class MessageImageInput
    {
        [Required]
        public string MessageId { get; set; }
        public ImageType ImageType { get; set; }
    }
}
