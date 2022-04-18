using NUnit.Framework;
using cli;

namespace UnitTests_Cli
{
    public class OptionAttribute

    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ParseCommandName()
        {
            var buyOptions = BuyCommand.GetOptions( typeof(BuyCommand));
            var sellOptions = SellCommand.GetOptions(typeof(SellCommand));
        }
    }
}
