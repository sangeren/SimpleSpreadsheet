using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpreadsheet.Console;
using SimpleSpreadsheet.Console.Command;
using System.Collections.Generic;
using SimpleSpreadsheet.Console.Model;

namespace SimpleSpreadsheet.UnitTest
{
    [TestClass]
    public class CommandTest
    {
        public Autofac.IContainer Container { get; set; }

        private string createCommandWord = "C";
        private string numberCommandWord = "N";
        private string sumCommandWord = "S";

        public CommandTest()
        {
            Container = Program.InitializationContainer();
        }

        [TestMethod]
        public void TestCommandRoute()
        {
            //arrange


            //act
            var commandRoute = Container.Resolve<CommandRoute>();
            var createCommand = commandRoute.Find(createCommandWord);
            var numberCommand = commandRoute.Find(numberCommandWord);
            var sumCommand = commandRoute.Find(sumCommandWord);


            //assert
            Assert.IsInstanceOfType(createCommand, typeof(CreateCommand));
            Assert.IsInstanceOfType(numberCommand, typeof(NumberCommand));
            Assert.IsInstanceOfType(sumCommand, typeof(SumCommand));

        }

        [TestMethod]
        public void TestCreateCommand()
        {
            //arrange
            var commandRoute = Container.Resolve<CommandRoute>();
            var createCommand = commandRoute.Find(createCommandWord);

            var list = new List<string>() { "20", "4" };
            var shape = new Shape() { Width = 20, Height = 4 };
            //act
            createCommand.Initial(list);

            //assert
            Assert.AreEqual<int>(createCommand.Sheet.Shape.Width, shape.Width);
            Assert.AreEqual<int>(createCommand.Sheet.Shape.Height, shape.Height);
        }

        [TestMethod]
        public void TestNumberCommand()
        {
            //arrange
            var commandRoute = Container.Resolve<CommandRoute>();
            var createCommand = commandRoute.Find(createCommandWord);
            createCommand.Initial(new List<string>() { "20", "4" });

            var numberCommand = commandRoute.Find(numberCommandWord);
            var list = new List<string>() {"1", "2", "2" };

            var key1 = new Coordinate() { X = 1, Y = 0 };
            var value1 = 2;
            //act
            numberCommand.Initial(list);

            //assert
            Assert.AreEqual(numberCommand.Sheet.Cells[key1], value1);
        }

        [TestMethod]
        public void TestSumCommand()
        {
            //arrange
            var commandRoute = Container.Resolve<CommandRoute>();
            var createCommand = commandRoute.Find(createCommandWord);
            createCommand.Initial(new List<string>() { "20", "4" });

            var numberCommand = commandRoute.Find(numberCommandWord);
            numberCommand.Initial(new List<string>() { "1", "2", "2" });
            numberCommand.Initial(new List<string>() { "1", "3", "4" });

            var sumCommand = commandRoute.Find(sumCommandWord);
            var list = new List<string>() { "1", "2", "1","3","1","4" };

            var key1 = new Coordinate() { X = 3, Y = 0 };
            var value1 = 6;
            //act
            sumCommand.Initial(list);

            //assert
            Assert.AreEqual(sumCommand.Sheet.Cells[key1], value1);
        }
    }
}
