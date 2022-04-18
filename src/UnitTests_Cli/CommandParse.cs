using NUnit.Framework;
using cli;

namespace UnitTests_Cli
{
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
        public void ParseCommandOption()
        {
            var commandString = "commandName -o arg1 arg2";
            var command = new Command(commandString);

            Assert.IsTrue(command.Options.Count == 1);
            Assert.IsTrue(command.Options["-o"].Arguments.Count == 2);
        }
    }
}