using System.Collections.Generic;

namespace SimpleSpreadsheet.Console.Model
{
    public class Spreadsheet
    {
        public Spreadsheet()
        {
            Cells = new Dictionary<Coordinate, int>();  
        }
        public Shape Shape { get; set; }
        public Dictionary<Coordinate, int> Cells { get; set; }
    }

    public struct Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
