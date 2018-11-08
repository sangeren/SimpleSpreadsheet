using Autofac;
using SimpleSpreadsheet.Console.Action;
using SimpleSpreadsheet.Console.Command;
using System;
using System.Linq;
using System.Reflection;
using SimpleSpreadsheet.Console.Model;

namespace SimpleSpreadsheet.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DI Register & resolve
            var container = InitializationContainer();
            var commandRoute = container.Resolve<CommandRoute>();


            while (true)
            {
                System.Console.Write("enter command:");
                var input = System.Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    System.Console.WriteLine("please input correct command!");
                    continue;
                }

                input = input.Trim();
                if (input.Equals("Q"))
                {
                    break;
                }

                var commandInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var commandWord = commandInput.First();
                commandInput.RemoveAt(0);


                //core
                try
                {
                    var command = commandRoute.Find(commandWord);
                    if (command is null)
                    {
                        System.Console.WriteLine("doesn't support '{0}' command, please input correct command!", commandWord);
                        continue;
                    }

                    var result = command.Initial(commandInput);
                    if (result.IsOk)
                    {
                        command.Execute();
                    }
                    else
                    {
                        System.Console.WriteLine(result.Msg);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        public static IContainer InitializationContainer()
        {
            // Create your builder.
            var builder = new ContainerBuilder();

            builder.RegisterType<ConsoleAction>().As<IAction>();

            var type = typeof(BaseCommand);
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract).As<BaseCommand>();
            builder.RegisterType<CommandRoute>();

            var spreadsheet = new Spreadsheet();
            builder.RegisterInstance(spreadsheet).As<Spreadsheet>();

            var container = builder.Build();
            return container;
        }
    }
}
