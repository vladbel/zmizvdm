using NUnit.Framework;
using cli;

namespace UnitTests_Cli
{
    [TestFixture]
    public class MatchCommand
    {
        [TestCase("buy")]
        public void BuyCommand_Match( string commandText)
        {
            var command = new Command(commandText);
            var result = CommandBase.Match(typeof(BuyCommand), command);

            Assert.IsTrue(result);
        }

        [TestCase("abc")]
        public void BuyCommand_Do_Not_Match(string commandText)
        {
            var command = new Command(commandText);
            var result = CommandBase.Match(typeof(BuyCommand), command);

            Assert.IsFalse(result);
        }
    }
}
