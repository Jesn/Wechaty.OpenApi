using System.ComponentModel.DataAnnotations;
using Wechaty.Module.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public class MessageImageInput
    {
        [Required]
        public string MessageId { get; set; }
        public ImageType ImageType { get; set; }
    }
}
