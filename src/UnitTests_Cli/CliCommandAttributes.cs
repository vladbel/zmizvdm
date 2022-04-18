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
        public void BuyCommand_Name_Options()
        {
            var buyCommand = new BuyCommand();
            var buyOptions = buyCommand.GetCliOptions();

            Assert.IsTrue(buyOptions.ContainsKey("-n"));
            Assert.IsTrue(buyOptions.ContainsKey("-name"));
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
        public void SellCommand_Name_Options()
        {
            var sellCommand = new SellCommand();
            var options = sellCommand.GetCliOptions();

            Assert.IsTrue(options.ContainsKey("-n"));
            Assert.IsTrue(options.ContainsKey("-name"));
            Assert.IsTrue(options.ContainsKey("--name"));
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
