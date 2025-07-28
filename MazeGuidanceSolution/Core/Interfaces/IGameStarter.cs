using MazeGuidanceSolution.Core.Entities;

namespace MazeGuidanceSolution.Core.Interfaces
{
    public interface IGameStarter
    {
        Task<StartGameApiResponse> ExecuteAsync(string playerName);
    }
}