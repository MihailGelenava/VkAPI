
using Newtonsoft.Json;

namespace VkAPI.Models
{
    public class WallPostModel
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("author_id")]
        public string? AuthorId { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("attachments")]
        public List<string>? Attachments { get; set; }
    }
}
