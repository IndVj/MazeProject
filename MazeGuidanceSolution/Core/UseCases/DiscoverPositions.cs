using MazeGuidanceSolution.Core.Entities;
using MazeGuidanceSolution.Core.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MazeGuidanceSolution.Core.UseCases
{
    public class DiscoverPositions
    {
        private readonly IMazeApiService _mazeApiService;
        public DiscoverPositions(IMazeApiService mazeApiService)
        {
            _mazeApiService = mazeApiService;
        }
        public async Task<List<DiscoverPositionResponse>> ExecuteAsync(string? discoverUrl)
        {
            if (string.IsNullOrWhiteSpace(discoverUrl))
            {
                throw new ArgumentException("DiscoverUrl name cannot be null or empty.", nameof(discoverUrl));
            }

            var response = await _mazeApiService.DiscoverPositionsGet(discoverUrl);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            return JsonSerializer.Deserialize<List<DiscoverPositionResponse>>(response, options)
                   ?? throw new InvalidOperationException("DiscoverPositions: Failed to deserialize the response.");
        }
    }
}
