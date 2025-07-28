using MazeGuidanceSolution.Core.Entities;

namespace MazeGuidanceSolution.Core.Interfaces
{
    public interface IPositionDiscoverer
    {
        Task<List<DiscoverPositionResponse>> ExecuteAsync(string? discoverUrl);
    }
}