using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSpreadsheet.Console.Command
{
    public class CommandRoute
    {
        public CommandRoute(IEnumerable<BaseCommand> baseCommands)
        {
            Commands = baseCommands;
        }

        public IEnumerable<BaseCommand> Commands { get; set; }

        public BaseCommand Find(string command)
        {
            if (string.IsNullOrEmpty(command)) throw new ArgumentNullException("command");
            command = command.Trim().ToUpper();

            foreach (var baseCommand in Commands)
            {
                if (baseCommand.Command.Equals(command))
                {
                    return baseCommand;
                }
            }

            return null;
        }
    }
}
