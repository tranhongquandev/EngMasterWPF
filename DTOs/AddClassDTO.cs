using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.DTOs
{
    public class AddClassDTO
    {
        [JsonProperty("className")]
        public string? ClassName { get; set; }

        [JsonProperty("startDate")]
        public string? StartDate { get; set; }

        [JsonProperty("endDate")]
        public string? EndDate { get; set; }

        [JsonProperty("courseId")]
        public int? CourseId { get; set; }

        [JsonProperty("teacherId")]
        public int? TeacherId { get; set; }
    }
}
