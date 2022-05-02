using NUnit.Framework;
using cli;

namespace UnitTests_Cli
{
    [TestFixture]
    public class MatchCommand
    {
        [TestCase("buy")]
        [TestCase("b")]
        public void BuyCommand_Match( string commandText)
        {
            var command = new Command(commandText);
            var result = CommandBase<BuyCommand>.Match( command);

            Assert.IsTrue(result);
        }

        [TestCase("abc")]
        public void BuyCommand_Do_Not_Match(string commandText)
        {
            var command = new Command(commandText);
            var result = CommandBase< BuyCommand>.Match(command);

            Assert.IsFalse(result);
        }
    }
}
