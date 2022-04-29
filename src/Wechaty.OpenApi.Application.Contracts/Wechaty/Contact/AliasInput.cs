using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechaty.OpenApi.Wechaty
{
    public class AliasInput
    {
        [Required]
        public string ContactId { get; set; }
        public string? Alias { get; set; }

    }
}
