using Core.Models;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class CsvParser : ITransactionParser
    {
        private const int SYMBOL_INDEX = 2;
        private const int PRICE_INDEX = 6;
        private const int QUANTITY_INDEX = 5;
        private const int TOTAL_AMOUNT_INDEX = 10;
        private const int RUN_DATE_INDEX = 0;
        private const int TRANSACTION_DESCRIPTION_INDEX = 1;

        /// <summary>
        ///0-     09/06/2022,                                                         Run Date
        ///1-     YOU BOUGHT VANGUARD INDEX FUNDS S&P 500 ETF USD (VOO) (Cash),       Action
        ///2-     VOO,                                                                Symbol
        ///3-     VANGUARD INDEX FUNDS S&P 500 ETF USD,                               Security Description
        ///4-     Cash,                                                               Security Type
        ///5-     1,                                                                  Quantity
        ///6-    357.99,                                                             Price ($)
        ///7-    ,                                                                   Commission
        ///8-    ,                                                                   Fees ($)
        ///9-    ,                                                                   Accrued Interest ($)
        ///10-   -357.99,                                                            Amount ($)
        ///11-   09/08/2022                                                          Settlement Date
        /// </summary>
        /// <param name="transactionRecord"></param>
        /// <returns></returns>
        public TransactionBase Parse(string transactionRecord)
        {
            var parts = transactionRecord.Split(',');
            var transaction = new TransactionBase(
                ticker: parts[SYMBOL_INDEX].Trim(),
                price: decimal.Parse(parts[PRICE_INDEX]),
                quantity: int.Parse(parts[QUANTITY_INDEX]),
                total: decimal.Parse(parts[TOTAL_AMOUNT_INDEX]),
                dateTime: DateTime.Parse(parts[RUN_DATE_INDEX]),
                transactionType: ParseType(parts[TRANSACTION_DESCRIPTION_INDEX])) ;

            return transaction;
        }

        private TransactionType ParseType (string description)
        {
            var transactionType = TransactionType.Undefined;
            if (description.ToUpper().Contains("YOU BOUGHT"))
            {
                transactionType = TransactionType.Buy;
            }

            return transactionType;
        }
    }
}
