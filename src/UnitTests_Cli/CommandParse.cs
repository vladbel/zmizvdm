using NUnit.Framework;
using cli;

namespace UnitTests_Cli
{
    [TestFixture]
    public class CommandParse

    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("commandName")]
        [TestCase("   commandName   ")]
        [Test]
        public void ParseCommandName(string commandName)
        {
            var commandString = commandName + " arg1 arg2";
            var command = new Command(commandString);

            Assert.IsTrue(command.Name == commandName.Trim());
        }

        [Test]
        public void ParseCommandArguments()
        {
            var commandString = "commandName arg1 arg2";
            var command = new Command(commandString);

            Assert.IsTrue(command.Arguments.Count ==2);
        }

        [Test]
        public void ParseCommandOptionArguments()
        {
            var commandString = "commandName -o arg1 arg2";
            var command = new Command(commandString);

            Assert.IsTrue(command.Options.Count == 1);
            Assert.IsTrue(command.Options["-o"].Arguments.Count == 2);
        }

        [Test]
        public void ParseCommandOptionArguments_WithDowleDash()
        {
            var commandString = "commandName --o arg1 arg2";
            var command = new Command(commandString);

            Assert.IsTrue(command.Options.Count == 1);
            Assert.IsTrue(command.Options["--o"].Arguments.Count == 2);
        }

        [Test]
        public void ParseCommandOptions_With_No_Arguments()
        {
            var commandString = "commandName --o1 -o2 -o3";
            var command = new Command(commandString);

            Assert.IsTrue(command.Options.Count == 3);
            Assert.IsTrue(command.Options["--o1"].Arguments.Count == 0);
            Assert.IsTrue(command.Options["-o2"].Arguments.Count == 0);
            Assert.IsTrue(command.Options["-o3"].Arguments.Count == 0);

        }

        [Test]
        public void ParseCommand_With_MultipleOptions()
        {
            var commandString = "commandName --o1 arg1 -o2 -o3 arg2 arg3 arg4 arg5";
            var command = new Command(commandString);

            Assert.IsTrue(command.Options.Count == 3);
            Assert.IsTrue(command.Options["--o1"].Arguments.Count == 1);
            Assert.IsTrue(command.Options["-o2"].Arguments.Count == 0);
            Assert.IsTrue(command.Options["-o3"].Arguments.Count == 4);

        }
    }
}