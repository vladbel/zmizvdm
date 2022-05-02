using System;
using System.Collections.Generic;
using System.Text;

namespace cli
{
    [CliCommand("b")]
    [CliCommand("buy")]
    public class BuyCommand : TransactionCommandBase<BuyCommand>
    {
    }

}
