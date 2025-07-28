namespace MazeGuidanceSolution.Core.Interfaces
{
    public interface IMazeSolver
    {
        Task ExecuteAsync(string playerName);
    }
}