using MazeGuidanceSolution.Core.UseCases;
using Microsoft.Extensions.DependencyInjection;
using MazeGuidanceSolution.Infrastructure;
using MazeGuidanceSolution.Core.Interfaces;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {

            var services = new ServiceCollection();
            services.AddSingleton<IMazeApiService, MazeApiService>();


            Console.WriteLine("Welcome to the Maze Game!");
            Console.Write("Enter your player name: ");

            var playerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Player name cannot be empty. Exiting the game.");
                return;
            }

            var provider = services.BuildServiceProvider();

            var mazeApiService = provider.GetRequiredService<IMazeApiService>();

            var startGameUseCase = new StartGame(mazeApiService);
            var startGameResponse = await startGameUseCase.ExecuteAsync(playerName);

            var discoverPositionUseCase = new DiscoverPositions(mazeApiService);
            var discoverPositionsResponse = await discoverPositionUseCase.ExecuteAsync(startGameResponse.UrlDiscover);


        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
