using NUnit.Framework;
using cli;

namespace UnitTests_Cli
{
    public class CliCommandAttributes

    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void BuyCommand_Options()
        {
            var buyCommand = new BuyCommand();
            var buyOptions = buyCommand.GetCliOptions();

            Assert.IsTrue(buyOptions.ContainsKey("-q"));
            Assert.IsTrue(buyOptions.ContainsKey("-p"));
            Assert.IsTrue(buyOptions.ContainsKey("-t"));
        }

        [Test]
        public void BuyCommand_CliCommands()
        {
            var command = new BuyCommand();
            var commands = command.GetCliCommands();

            Assert.IsTrue(commands.Contains("buy"));
            Assert.IsTrue(commands.Contains("b"));
        }

        [Test]
        public void SellCommand_Options()
        {
            var command = new SellCommand();
            var options = command.GetCliOptions();

            Assert.IsTrue(options.ContainsKey("-q"));
            Assert.IsTrue(options.ContainsKey("-p"));
            Assert.IsTrue(options.ContainsKey("-t"));
        }

        [Test]
        public void SellCommand_CliCommands()
        {
            var command = new SellCommand();
            var commands = command.GetCliCommands();

            Assert.IsTrue(commands.Contains("s"));
            Assert.IsTrue(commands.Contains("sell"));
        }
    }
}
