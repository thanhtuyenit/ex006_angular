using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace server.Models
{
    public class CRUDCommon
    {
        [Key]
        public long ID { get; set; }

        [JsonIgnore]
        public bool DeleteFlag { get; set; }
    }
}
