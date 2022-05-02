using System;
using System.Collections.Generic;
using System.Text;

namespace cli
{
    public class TransactionCommandBase<T> : CommandBase<T>
    {
        [CliOption("-t")]
        [CliOption("-ticker")]
        public string Ticker { get; private set; }

        [CliOption("-p")]
        [CliOption("-price")]
        public string Price { get; private set; }

        [CliOption("-q")]
        [CliOption("-qnt")]
        [CliOption("-quantity")]
        public string Quantity { get; private set; }
    }
}
