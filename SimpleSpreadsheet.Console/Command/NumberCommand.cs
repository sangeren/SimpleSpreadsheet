using System.Collections.Generic;
using SimpleSpreadsheet.Console.Action;
using SimpleSpreadsheet.Console.Model;

namespace SimpleSpreadsheet.Console.Command
{
    public class NumberCommand : BaseCommand
    {
        public NumberCommand(IAction action, Spreadsheet spreadsheet) : base(action, spreadsheet)
        {
            Command = "N";
        }

        public override InitialResult Initial(IList<string> parameters)
        {
            var result = new InitialResult() { IsOk = false, Msg = "initial error" };

            if (Sheet.Shape.Equals(new Shape()))
            {
                result.Msg = "Please create a spreadsheet first!";
                return result;
            }

            if (parameters.Count != 3)
            {
                result.Msg = "The number of parameters is not correct!";
                return result;
            }

            var parametersInt = new List<int>();
            foreach (string parameter in parameters)
            {
                if (int.TryParse(parameter, out int value))
                {
                    parametersInt.Add(value);
                }
                else
                {
                    result.Msg = $"The parameter:'{parameter}' is not correct!";
                    return result;
                }
            }



            if (parametersInt[0] > Sheet.Shape.Width)
            {
                result.Msg = $"The parameter:'{parametersInt[0]}' should be less then {Sheet.Shape.Width}!";
                return result;
            }

            if (parametersInt[1] > Sheet.Shape.Height)
            {
                result.Msg = $"The parameter:'{parametersInt[1]}' should be less then {Sheet.Shape.Height}!";
                return result;
            }

            var key1 = new Coordinate() { X = parametersInt[1] - 1, Y = parametersInt[0] - 1 };
            var value1 = parametersInt[2];
            Sheet.Cells[key1] = value1;

            result.IsOk = true;
            result.Msg = "ok";
            return result;
        }
    }
}
