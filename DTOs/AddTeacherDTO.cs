using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.DTOs
{
    public class AddTeacherDTO
    {
        [JsonProperty("imgUrl")]
        public string? ImageUrl { get; set; }

        [JsonProperty("fullName")]
        public string? FullName { get; set; }

        [JsonProperty("gender")]
        public string? Gender { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("dateOfBirth")]
        public string? DateOfBirth { get; set; }

        [JsonProperty("hireDate")]
        public string? HireDate { get; set; }

        [JsonProperty("endDate")]
        public string? EndDate { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
    }
}
