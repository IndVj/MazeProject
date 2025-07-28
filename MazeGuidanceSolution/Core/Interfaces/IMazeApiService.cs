namespace MazeGuidanceSolution.Core.Interfaces
{
    public interface IMazeApiService
    {
        Task<string> StartGamePost(string playerName);
        Task<string> DiscoverPositionsGet(string discoverUrl);
        Task<string> MovePlayerPost(string moveURl, int x, int y);
    }
}