using MazeGuidanceSolution.Core.Entities;
using MazeGuidanceSolution.Core.UseCases;

namespace MazeGuidanceSolution.Tests
{
    public class GetBestPositionToMoveTest
    {

        [Fact]
        public void Should_Return_StopCell_When_Stop_Is_Present()
        {
            // Arrange
            var positions = new List<DiscoverPositionResponse>
            {
                 new DiscoverPositionResponse { X = 1, Y = 2, Move = true, Value = CellType.home },
                 new DiscoverPositionResponse { X = 2, Y = 1, Move = true, Value = CellType.path },
                 new DiscoverPositionResponse { X = 2, Y = 3, Move = true, Value = CellType.stop },
                 new DiscoverPositionResponse { X = 3, Y = 2, Move = true, Value = CellType.path },
            };

            var visited = new HashSet<(int x, int y)> { (1, 0) };

            // Act
            var result = MazeSolver.GetBestPositionToMove(positions, visited);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CellType.stop, result.Value);
            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);

        }

        [Fact]
        public void Should_Return_First_Unvisited_Path_If_No_Stop_Is_Present()
        {
            // Arrange
            var positions = new List<DiscoverPositionResponse>
            {
               new DiscoverPositionResponse { X = 1, Y = 2, Move = true, Value = CellType.wall },
               new DiscoverPositionResponse { X = 2, Y = 1, Move = true, Value = CellType.path },
               new DiscoverPositionResponse { X = 2, Y = 3, Move = true, Value = CellType.wall },
               new DiscoverPositionResponse { X = 3, Y = 2, Move = true, Value = CellType.path },
            };

            var visited = new HashSet<(int x, int y)> { (3, 2) }; 

            // Act
            var result = MazeSolver.GetBestPositionToMove(positions, visited);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CellType.path, result.Value);
            Assert.Equal(2, result.X);
            Assert.Equal(1, result.Y);
        }

        [Fact]
        public void Should_Fallback_To_First_Avaialble_Safe_Cell_When_All_Visited()
        {
            // Arrange
            var positions = new List<DiscoverPositionResponse>
            {
               new DiscoverPositionResponse { X = 1, Y = 2, Move = true, Value = CellType.trap },
               new DiscoverPositionResponse { X = 2, Y = 1, Move = true, Value = CellType.wall },
               new DiscoverPositionResponse { X = 2, Y = 3, Move = true, Value = CellType.path },
               new DiscoverPositionResponse { X = 3, Y = 2, Move = true, Value = CellType.home },
            };

            var visited = new HashSet<(int x, int y)> { (2, 3), (3,2) };

            // Act
            var result = MazeSolver.GetBestPositionToMove(positions, visited);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CellType.path, result.Value);
            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
        }
    }
}