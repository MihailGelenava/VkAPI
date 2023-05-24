
using Newtonsoft.Json;

namespace VkAPI.Models
{
    public class UploadServerUrlModel
    {
        [JsonProperty("album_id")]
        public string? AlbumId { get; set; }

        [JsonProperty("upload_url")]
        public string? UploadUrl { get; set; }

        [JsonProperty("user_id")]
        public string? UserId { get; set; }
    }
}
