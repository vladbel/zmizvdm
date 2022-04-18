using System.Collections.Generic;
using System;

namespace Models
{
    public class Transaction
    {
        public Transaction(
            string id,
            string ticker,
            decimal price,
            int quantity,
            decimal total,
            DateTime dateTime,
            TransactionType tansactionType,
            List<Transaction> parents)
        {
            Id = id;
            Ticker = ticker;
            Price = price;
            Quantity = quantity;
            Total = total;
            DateTime = dateTime;
            TansactionType = tansactionType;
            Parents = parents;
        }

        public string Id { get; private set; }
        public string Ticker { get; private set; }

        /// <summary>
        /// price per unit
        /// </summary>
        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public decimal Total { get; private set; }

        public DateTime DateTime { get; private set; }

        public TransactionType TansactionType { get; private set; }

        public List<Transaction> Parents { get; set; }
    }
}
