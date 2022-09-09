using System;
using System.Collections.Generic;
using Core.Enums;

namespace Core.Models
{
    public class TransactionBase
    {
        public TransactionBase(
            string ticker,
            decimal price,
            int quantity,
            decimal total,
            DateTime dateTime,
            TransactionType transactionType)
        {
            Ticker = ticker;
            Price = price;
            Quantity = quantity;
            Total = total;
            DateTime = dateTime;
            TansactionType = transactionType;
        }
        public string Ticker { get; private set; }

        /// <summary>
        /// price per unit
        /// </summary>
        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public decimal Total { get; private set; }

        public DateTime DateTime { get; private set; }

        public TransactionType TansactionType { get; private set; }

    }
}
