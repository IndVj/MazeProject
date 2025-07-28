using System.Text.Json;
using MazeGuidanceSolution.Core.Entities;
using MazeGuidanceSolution.Core.Interfaces;

namespace MazeGuidanceSolution.Core.UseCases
{
    public class PlayerMover : IPlayerMover
    {
        private readonly IMazeApiService _mazeApiService;
        public PlayerMover(IMazeApiService mazeApiService)
        {
            _mazeApiService = mazeApiService;
        }
        public async Task<MovePlayerResponse> ExecuteAsync(string? moveUrl, int x, int y)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(moveUrl))
                {
                    throw new ArgumentException("Failed in PlayerMover: Move URL cannot be null or empty.", nameof(moveUrl));
                }

                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException("Failed in PlayerMover: X Coordinates cannot be negative.", nameof(x));
                }

                if (y < 0)
                {
                    throw new ArgumentOutOfRangeException("Failed in PlayerMover: Y Coordinates cannot be negative.", nameof(y));
                }

                var response = await _mazeApiService.MovePlayerPost(moveUrl, x, y);

                return JsonSerializer.Deserialize<MovePlayerResponse>(response)
                    ?? throw new InvalidOperationException("Failed in PlayerMover: Failed to deserialize the response.");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed in PlayerMover: " + ex);
            }

        }
    }
}
