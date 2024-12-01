
using EngMasterWPF.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngMasterWPF.DTOs
{
    public class CourseDTO : ViewModelBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("courseCode")]
        public string? CourseCode { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("courseName")]
        public string? CourseName { get; set; }

        [JsonProperty("duration")]
        public string? Duration { get; set; }

        [JsonProperty("fee")]
        public int? Fee { get; set; }

        [JsonProperty("discount")]
        public double? Discount { get; set; }

        public double TotalFee => (double)(Fee - (Fee * Discount ?? 0));

        public DateTime? CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("levelId")]
        public int? LevelId { get; set; }

        [JsonProperty("levelName")]
        public string? LevelName { get; set; }


    }
}
