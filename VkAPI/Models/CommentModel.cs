
using Newtonsoft.Json;

namespace VkAPI.Models
{
    public class CommentModel
    {
        [JsonProperty("comment_id")]
        public string? CommentId { get; set; }

        [JsonProperty("post_id")]
        public string? PostId { get; set; }

        [JsonProperty("author_id")]
        public string? AuthorId { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
