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
        [JsonProperty("classCode")]
        public string? ClassCode { get; set; }

        [JsonProperty("className")]
        public string? ClassName { get; set; }

        [JsonProperty("startDate")]
        public string? StartDate { get; set; }


        [JsonProperty("endDate")]
        public string? EndDate { get; set; }

        [JsonProperty("courseId")]
        public long? CourseId { get; set; }

        [JsonProperty("teacherId")]
        public long? TeacherId { get; set; }

        public override string ToString()
        {
            return $"ClassCode: {ClassCode}, ClassName: {ClassName}, StartDate: {StartDate}, EndDate: {EndDate}, CourseId: {CourseId}, TeacherId: {TeacherId}";
        }
    }
}
