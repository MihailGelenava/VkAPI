
using Newtonsoft.Json;

namespace VkAPI.Models
{
    public class UploadPhotoServerModel
    {
        [JsonProperty("server")]
        public string? Server { get; set; }

        [JsonProperty("photo")]
        public string? Photo { get; set; }

        [JsonProperty("hash")]
        public string? Hash { get; set; }
    }
}
