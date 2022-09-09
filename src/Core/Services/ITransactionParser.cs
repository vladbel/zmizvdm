using Core.Models;

namespace Core.Services
{
    public interface ITransactionParser
    {
        TransactionBase Parse(string transactionRecord);
    }
}
