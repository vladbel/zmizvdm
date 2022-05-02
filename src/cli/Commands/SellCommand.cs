using System;
using System.Collections.Generic;
using System.Text;

namespace cli
{

    [CliCommand("sell")]
    [CliCommand("s")]
    [CliCommand("sl")]
    public class SellCommand : TransactionCommandBase<SellCommand>
    {
    }
}
