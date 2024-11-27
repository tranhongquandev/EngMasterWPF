using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.DTOs
{
    public class UpdateCourseDTO : AddCourseDTO
    {
        [JsonProperty("courseCode")]
        public string? CourseCode { get; set; }
    }
}
