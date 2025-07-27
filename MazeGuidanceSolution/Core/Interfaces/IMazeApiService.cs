namespace MazeGuidanceSolution.Core.Interfaces
{
    public interface IMazeApiService
    {
        Task<string> StartGamePost(string playerName);
        Task<string> DiscoverPositionsGet(string discoverUrl);
    }
}