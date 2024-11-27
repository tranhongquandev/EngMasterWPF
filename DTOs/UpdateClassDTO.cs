using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.DTOs
{
    public class UpdateClassDTO : AddClassDTO
    {
        [JsonProperty("classCode")]
        public string? ClassCode { get; set; }
    }
}
