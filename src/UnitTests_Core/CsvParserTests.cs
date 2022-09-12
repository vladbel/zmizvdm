using NUnit.Framework;
using Core.Services;
using Core.Enums;
using Core.Models;

namespace UnitTests_Core
{
    public class CsvParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 09/06/2022,                                                         Run Date
        /// YOU BOUGHT VANGUARD INDEX FUNDS S&P 500 ETF USD (VOO) (Cash),       Action
        /// VOO,                                                                Symbol
        /// VANGUARD INDEX FUNDS S&P 500 ETF USD,                               Security Description
        /// Cash,                                                               Security Type
        /// 1,                                                                  Quantity
        /// 357.99,                                                             Price ($)
        /// ,                                                                   Commission
        /// ,                                                                   Fees ($)
        /// ,                                                                   Accrued Interest ($)
        /// -357.99,                                                            Amount ($)
        /// 09/08/2022                                                          Settlement Date
        /// </summary>
        [Test]
        public void Buy_VOO()
        {
            var parser = new CsvParser();
            var record = " 09/06/2022, YOU BOUGHT VANGUARD INDEX FUNDS S&P 500 ETF USD (VOO) (Cash), VOO, VANGUARD INDEX FUNDS S&P 500 ETF USD,Cash,1,357.99,,,,-357.99,09/08/2022";
            var transaction = parser.Parse(record);
            Assert.IsTrue(transaction.Ticker == "VOO");
            Assert.IsTrue(transaction.DateTime.Year == 2022);
        }
    }
}