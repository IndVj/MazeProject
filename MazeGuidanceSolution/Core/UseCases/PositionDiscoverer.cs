using System.Text.Json;
using System.Text.Json.Serialization;
using MazeGuidanceSolution.Core.Entities;
using MazeGuidanceSolution.Core.Interfaces;

namespace MazeGuidanceSolution.Core.UseCases
{
    public class PositionDiscoverer : IPositionDiscoverer
    {
        private readonly IMazeApiService _mazeApiService;
        public PositionDiscoverer(IMazeApiService mazeApiService)
        {
            _mazeApiService = mazeApiService;
        }
        public async Task<List<DiscoverPositionResponse>> ExecuteAsync(string? discoverUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(discoverUrl))
                {
                    throw new ArgumentException("Failed in PositionDiscoverer: DiscoverUrl name cannot be null or empty.", nameof(discoverUrl));
                }

                var response = await _mazeApiService.DiscoverPositionsGet(discoverUrl);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                };

                return JsonSerializer.Deserialize<List<DiscoverPositionResponse>>(response, options)
                       ?? throw new InvalidOperationException("Failed in PositionDiscoverer: Failed to deserialize the response.");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed in PositionDiscoverer: " + ex);
            }
        }
    }
}
