using System.Collections.Generic;
using SimpleSpreadsheet.Console.Action;
using SimpleSpreadsheet.Console.Model;

namespace SimpleSpreadsheet.Console.Command
{
    /// <summary>
    /// base command class
    /// </summary>
    public abstract class BaseCommand
    {
        public string Command { get; protected set; }
        protected BaseCommand(IAction action, Spreadsheet spreadsheet)
        {
            ExecuteAction = action;
            Sheet = spreadsheet;
        }
        protected IAction ExecuteAction { get; set; }
        public Spreadsheet Sheet { get; protected set; }

        /// <summary>
        /// initial command and execute command
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract InitialResult Initial(IList<string> parameters);
        public virtual void Execute()
        {
            ExecuteAction.Execute(Sheet);
        }

    }
}
