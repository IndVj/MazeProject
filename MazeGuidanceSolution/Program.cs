using MazeGuidanceSolution.Core.Interfaces;
using MazeGuidanceSolution.Core.UseCases;
using MazeGuidanceSolution.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IMazeApiService, MazeApiService>();
        services.AddTransient<IGameStarter, GameStarter>();
        services.AddTransient<IPositionDiscoverer, PositionDiscoverer>();
        services.AddTransient<IPlayerMover, PlayerMover>();
        services.AddTransient<IMazeSolver, MazeSolver>();


        Console.WriteLine("Welcome to the  Game!");
        Console.Write("Enter your player name: ");

        var playerName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(playerName))
        {
            Console.WriteLine("Player name cannot be empty. Exiting the game.");
            return;
        }

        var provider = services.BuildServiceProvider();
        var mazeSolver = provider.GetRequiredService<IMazeSolver>();
        
        await mazeSolver.ExecuteAsync(playerName);

    }

}
