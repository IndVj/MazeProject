using System.Net.Http.Headers;
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

            var formData = new FormUrlEncodedContent(new[]
            {
                 new KeyValuePair<string, string>("player", "VJ")
            });

            return await HttpHelper.PostAsync(url, formData);
        }

    }
}
