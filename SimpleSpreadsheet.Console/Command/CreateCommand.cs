using System.Collections.Generic;
using SimpleSpreadsheet.Console.Action;
using SimpleSpreadsheet.Console.Model;

namespace SimpleSpreadsheet.Console.Command
{
    public class CreateCommand : BaseCommand
    {
        public CreateCommand(IAction action, Spreadsheet spreadsheet) : base(action, spreadsheet)
        {
            Command = "C";
        }

        public override InitialResult Initial(IList<string> parameters)
        {
            var result = new InitialResult() { IsOk = false, Msg = "initial error" };
            if (parameters.Count != 2)
            {
                result.Msg = "The number of parameters is not correct!";
                return result;
            }
            int p0 = 0;
            int p1 = 0;
            if (!int.TryParse(parameters[0], out p0))
            {
                result.Msg = "The first parameter should be integer!";
                return result;
            }
            if (!int.TryParse(parameters[1], out p1))
            {
                result.Msg = "The second parameter should be integer!";
                return result;
            }
            if (p0 < 1 || p1 < 1)
            {
                result.Msg = "The two parameters should be greater than 0 !";
                return result;
            }

            Sheet.Shape = new Shape() { Width = p0, Height = p1 };
            Sheet.Cells = new Dictionary<Coordinate, int>();

            result.IsOk = true;
            result.Msg = "ok";
            return result;
        }
    }
}
