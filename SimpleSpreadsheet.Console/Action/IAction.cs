using SimpleSpreadsheet.Console.Model;

namespace SimpleSpreadsheet.Console.Action
{
    /// <summary>
    /// show result interface
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// perform the result
        /// </summary>
        /// <param name="spreadsheet"></param>
        void Execute(Spreadsheet spreadsheet);
    }
}
