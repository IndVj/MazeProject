using System.Text.Json;
using MazeGuidanceSolution.Core.Entities;
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
        public async Task<StartGameApiResponse> ExecuteAsync(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                throw new ArgumentException("Player name cannot be null or empty.", nameof(playerName));
            }

            string response = await _mazeApiService.StartGamePost(playerName);


            return JsonSerializer.Deserialize<StartGameApiResponse>(response)
                   ?? throw new InvalidOperationException("StartGame: Failed to deserialize the response.");
        }
    }
}
