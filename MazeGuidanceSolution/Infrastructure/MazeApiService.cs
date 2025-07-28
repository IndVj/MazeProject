using MazeGuidanceSolution.Core.Interfaces;

namespace MazeGuidanceSolution.Infrastructure
{

    public class MazeApiService : IMazeApiService
    {
        private readonly string _baseUrl;

        public MazeApiService()
        {
            this._baseUrl = "https://hire-game-maze.pertimm.dev";
        }

        public async Task<string> StartGamePost(string playerName)
        {
            var url = $"{_baseUrl}/start-game/";

            var formData = new FormUrlEncodedContent(
            new[]
            {
                     new KeyValuePair<string, string>("player", playerName)
            });

            return await HttpHelper.PostAsync(url, formData);
        }

        public async Task<string> DiscoverPositionsGet(string discoverUrl)
        {
            if (string.IsNullOrWhiteSpace(discoverUrl))
            {
                throw new ArgumentException("DiscoverUrl name cannot be null or empty.", nameof(discoverUrl));
            }

            return await HttpHelper.GetAsync(discoverUrl);
        }

        public async Task<string> MovePlayerPost(string moveURl, int x, int y)
        {
            var formData = new FormUrlEncodedContent(
            new[]
            {
                     new KeyValuePair<string, string>("position_x", x.ToString()),
                     new KeyValuePair<string, string>("position_y", y.ToString())
            });

            return await HttpHelper.PostAsync(moveURl, formData);
        }
    }
}
