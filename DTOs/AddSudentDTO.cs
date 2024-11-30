using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.DTOs
{
    public class AddStudentDTO : UpdateStudentDTO
    {

        [JsonProperty("enrollmentDate")]
        public string? EnrollmentDate { get; set; }
    }
}
