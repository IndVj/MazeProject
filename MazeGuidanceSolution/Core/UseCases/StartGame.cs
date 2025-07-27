using MazeGuidanceSolution.Core.Interfaces;

namespace MazeGuidanceSolution.Core.UseCases
{
    public class StartGame
    {
        private readonly IMazeApiService _mazeApiService;
        public StartGame(IMazeApiService mazeApiService)
        {
            _mazeApiService = mazeApiService;
        }
        public async Task<string> ExecuteAsync(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                throw new ArgumentException("Player name cannot be null or empty.", nameof(playerName));
            }
            return await _mazeApiService.StartGamePost(playerName);
        }

    }
}
