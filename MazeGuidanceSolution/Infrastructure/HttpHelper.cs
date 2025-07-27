namespace MazeGuidanceSolution.Infrastructure
{
    public static class HttpHelper
    {
        public static async Task<string> GetAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> PostAsync(string url, HttpContent content)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(url, content).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }

        }

    }
}
