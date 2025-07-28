using MazeGuidanceSolution.Core.Entities;
using MazeGuidanceSolution.Core.Interfaces;

namespace MazeGuidanceSolution.Core.UseCases
{
    public class MazeSolver : IMazeSolver
    {

        private readonly IGameStarter startGameUseCase;
        private readonly IPlayerMover movePlayerUseCase;
        private readonly IPositionDiscoverer discoverPositionUseCase;

        public MazeSolver(IGameStarter startGameUseCase, IPlayerMover movePlayerUseCase, IPositionDiscoverer discoverPositionUseCase)
        {
            this.startGameUseCase = startGameUseCase;
            this.movePlayerUseCase = movePlayerUseCase;
            this.discoverPositionUseCase = discoverPositionUseCase;
        }

        public async Task ExecuteAsync(string playerName)
        {

            try
            {
                var startGameResponse = await startGameUseCase.ExecuteAsync(playerName);

                bool isWon = false;
                bool isDead = false;
                var visitedPaths = new HashSet<(int X, int Y)>() { (startGameResponse.PositionX, startGameResponse.PositionY) };

                while (!isWon && !isDead)
                {

                    var discoverPositionsResponse = await discoverPositionUseCase.ExecuteAsync(startGameResponse.UrlDiscover);

                    var positionToMove = GetBestPositionToMove(discoverPositionsResponse, visitedPaths);

                    if (positionToMove == null)
                    {
                        Console.WriteLine("No valid moves available. Exiting the game.");
                        break;
                    }

                    var movePlayerResponse = await movePlayerUseCase.ExecuteAsync(startGameResponse.UrlMove, positionToMove.X, positionToMove.Y);
                    visitedPaths.Add((movePlayerResponse.PositionX, movePlayerResponse.PositionY));

                    isWon = movePlayerResponse.Win;
                    isDead = movePlayerResponse.Dead;

                    Console.WriteLine($"{playerName} Moved to position ({movePlayerResponse.PositionX}, {movePlayerResponse.PositionY}).");

                }

                Console.WriteLine(isWon ? $"Congratulations! {playerName} has won!" : isDead ? $"Sorry! {playerName} is dead" : "Unknown State");

                if (isWon)
                    Console.WriteLine($"It took {visitedPaths.Count - 1} steps for {playerName} steps to reach the exit");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exiting the game with failure: " + ex);
            }
        }

        public static DiscoverPositionResponse? GetBestPositionToMove(List<DiscoverPositionResponse> discoverPositionsResponse,
                                                                   HashSet<(int x, int y)> visitedPaths)
        {
            var exit = discoverPositionsResponse.FirstOrDefault(p => p.Value == CellType.stop);
            if (exit != null) return exit;

            var unVisitedPosition = discoverPositionsResponse
                .Where(p => p.Move && p.Value != CellType.trap && p.Value != CellType.wall && !visitedPaths.Contains((p.X, p.Y)))
                .FirstOrDefault();
            if (unVisitedPosition != null) return unVisitedPosition;


            //fallback to avoid trap and walls
            return discoverPositionsResponse.FirstOrDefault(p => p.Move && p.Value != CellType.trap && p.Value != CellType.wall);
        }


    }
}
