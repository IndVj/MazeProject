using System.Text.Json;
using MazeGuidanceSolution.Core.Entities;
using MazeGuidanceSolution.Core.Interfaces;

namespace MazeGuidanceSolution.Core.UseCases
{
    public class GameStarter : IGameStarter
    {
        private readonly IMazeApiService _mazeApiService;
        public GameStarter(IMazeApiService mazeApiService)
        {
            _mazeApiService = mazeApiService;
        }
        public async Task<StartGameApiResponse> ExecuteAsync(string playerName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    throw new ArgumentException("Failed in GameStarter: Player name cannot be null or empty.", nameof(playerName));
                }

                string response = await _mazeApiService.StartGamePost(playerName);

                return JsonSerializer.Deserialize<StartGameApiResponse>(response)
                       ?? throw new InvalidOperationException("Failed in GameStarter: Failed to deserialize the response.");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed in GameStarter: "+ ex);
            }
        }
    }
}
