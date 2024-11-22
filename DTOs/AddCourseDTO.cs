using Newtonsoft.Json;

namespace EngMasterWPF.DTOs
{
    class AddCourseDTO
    {


        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("courseName")]
        public string? CourseName { get; set; }

        [JsonProperty("duration")]
        public string? Duration { get; set; }

        [JsonProperty("fee")]
        public double? Fee { get; set; }

        [JsonProperty("discount")]
        public double? Discount { get; set; }

        [JsonProperty("totalFee")]
        public double? TotalFee { get; set; }


        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("levelId")]
        public int? LevelId { get; set; }
    }
}
