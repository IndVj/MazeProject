using System.Text.Json.Serialization;

namespace MazeGuidanceSolution.Core.Entities
{
    /// <summary>
    /// Represents the response from the Start Game API.
    /// </summary>
    public class StartGameApiResponse
    {
        [JsonPropertyName("player")]
        public string? Player { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("position_x")]
        public int PositionX { get; set; }

        [JsonPropertyName("position_y")]
        public int PositionY { get; set; }

        [JsonPropertyName("dead")]
        public bool Dead { get; set; }

        [JsonPropertyName("win")]
        public bool Win { get; set; }

        [JsonPropertyName("url_move")]
        public string? UrlMove { get; set; }

        [JsonPropertyName("url_discover")]
        public string? UrlDiscover { get; set; }
    }
}
