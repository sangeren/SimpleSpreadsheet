using System;
using SimpleSpreadsheet.Console.Model;

namespace SimpleSpreadsheet.Console.Action
{
    /// <summary>
    /// console result 
    /// </summary>
    public class ConsoleAction : IAction
    {
        public void Execute(Spreadsheet spreadsheet)
        {
            Coordinate coordinate = new Coordinate();
            if (spreadsheet.Shape.Height < 1 || spreadsheet.Shape.Width < 1)
            {
                throw new ArgumentException("spreadsheet size is not correct! ");
            }

            //head
            System.Console.Write("-");
            for (int i = 0; i < spreadsheet.Shape.Width; i++)
            {
                System.Console.Write("---" + " ");
            }
            System.Console.WriteLine("-");

            //rows
            for (int i = 0; i < spreadsheet.Shape.Height; i++)
            {
                System.Console.Write("|");
                for (int j = 0; j < spreadsheet.Shape.Width; j++)
                {
                    coordinate.X = i;
                    coordinate.Y = j;
                    if (spreadsheet.Cells.TryGetValue(coordinate, out int value))
                    {
                        System.Console.Write($"{value,3}");
                    }
                    else
                    {
                        System.Console.Write("   ");
                    }
                    System.Console.Write(" ");
                }
                System.Console.WriteLine("|");
            }

            //end
            System.Console.Write("-");
            for (int i = 0; i < spreadsheet.Shape.Width; i++)
            {
                System.Console.Write("---" + " ");
            }
            System.Console.WriteLine("-");

            System.Console.WriteLine();
        }
    }
}
