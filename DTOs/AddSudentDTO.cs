using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.DTOs
{
    public class AddStudentDTO
    {

        [JsonProperty("fullName")]
        public string? FullName { get; set; }

        [JsonProperty("gender")]
        public string? Gender { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonProperty("dateOfBirth")]
        public string? DateOfBirth { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }
    }
}
