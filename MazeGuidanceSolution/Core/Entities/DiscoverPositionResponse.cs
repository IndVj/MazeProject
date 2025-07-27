using System.Text.Json.Serialization;

namespace MazeGuidanceSolution.Core.Entities
{

    public class DiscoverPositionResponse
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Move { get; set; }
        public CellType Value { get; set; }
    }
}
