using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.DTOs
{
    public class UpdateStudentDTO : AddStudentDTO
    {
        [JsonProperty("studentCode")]
        public string? StudentCode { get; set; }

        [JsonProperty("enrollmentDate")]
        public string? EnrollmentDate { get; set; }

    }
}
