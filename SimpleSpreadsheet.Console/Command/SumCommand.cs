using System.Collections.Generic;
using SimpleSpreadsheet.Console.Action;
using SimpleSpreadsheet.Console.Model;

namespace SimpleSpreadsheet.Console.Command
{
    public class SumCommand : BaseCommand
    {
        public SumCommand(IAction action, Spreadsheet spreadsheet) : base(action, spreadsheet)
        {
            Command = "S";
        }

        public override InitialResult Initial(IList<string> parameters)
        {
            var result = new InitialResult() { IsOk = false, Msg = "initial error" };

            if (Sheet.Shape.Equals(new Shape()))
            {
                result.Msg = "Please create a spreadsheet first!";
                return result;
            }

            if (parameters.Count != 6)
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

            if (parametersInt[4] > Sheet.Shape.Width)
            {
                result.Msg = $"The parameter:'{parametersInt[4]}' should be less then {Sheet.Shape.Width}!";
                return result;
            }

            if (parametersInt[5] > Sheet.Shape.Height)
            {
                result.Msg = $"The parameter:'{parametersInt[5]}' should be less then {Sheet.Shape.Height}!";
                return result;
            }


            var key1 = new Coordinate() { X = parametersInt[1] - 1, Y = parametersInt[0] - 1 };
            var value1 = 0;
            var key2 = new Coordinate() { X = parametersInt[3] - 1, Y = parametersInt[2] - 1 };
            var value2 = 0;
            var key3 = new Coordinate() { X = parametersInt[5] - 1, Y = parametersInt[4] - 1 };
            var value3 = 0;


            if (!Sheet.Cells.TryGetValue(key1, out value1))
            {
                result.Msg = $"The position {key1} should be a number!";
                return result;
            }

            if (!Sheet.Cells.TryGetValue(key2, out value2))
            {
                result.Msg = $"The position {key2} should be a number!";
                return result;
            }

            value3 = value1 + value2;
            Sheet.Cells[key3] = value3;

            result.IsOk = true;
            result.Msg = "ok";
            return result;
        }
    }
}
