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
            var buyOptions = CommandBase<BuyCommand>.GetCliOptions();

            Assert.IsTrue(buyOptions.ContainsKey("-q"));
            Assert.IsTrue(buyOptions.ContainsKey("-p"));
            Assert.IsTrue(buyOptions.ContainsKey("-t"));
        }

        [Test]
        public void BuyCommand_CliCommands()
        {

            var commands = CommandBase<BuyCommand>.GetCliCommands();

            Assert.IsTrue(commands.Contains("buy"));
            Assert.IsTrue(commands.Contains("b"));
        }

        [Test]
        public void SellCommand_Options()
        {
            var options = CommandBase<SellCommand>.GetCliOptions();

            Assert.IsTrue(options.ContainsKey("-q"));
            Assert.IsTrue(options.ContainsKey("-p"));
            Assert.IsTrue(options.ContainsKey("-t"));
        }

        [Test]
        public void SellCommand_CliCommands()
        {
            var commands = CommandBase<SellCommand>.GetCliCommands();

            Assert.IsTrue(commands.Contains("s"));
            Assert.IsTrue(commands.Contains("sell"));
        }
    }
}
