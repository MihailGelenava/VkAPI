
using Newtonsoft.Json;

namespace VkAPI.Models
{
    public class PhotoInfoModel
    {
        [JsonProperty("album_id")]
        public string? AlbumId { get; set; }

        [JsonProperty("date")]
        public string? Date { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("owner_id")]
        public string? OwnerId { get; set; }

    }
}
