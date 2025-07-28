using MazeGuidanceSolution.Core.Entities;

namespace MazeGuidanceSolution.Core.Interfaces
{
    public interface IPlayerMover
    {
        Task<MovePlayerResponse> ExecuteAsync(string? moveUrl, int x, int y);
    }
}