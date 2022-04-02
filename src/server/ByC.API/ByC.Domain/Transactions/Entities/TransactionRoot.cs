using System;

namespace ByC.Domain.Transactions.Entities
{
    public class TransactionRoot
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }
        public DateTime? Date { get; private set; }
        public decimal? Value { get; private set; }
        public string Document { get; private set; }
        public string Card { get; private set; }
        public TimeSpan? Hour { get; private set; }
        public string StoreOwnerName { get; private set; }
        public string StoreName { get; private set; }

    }
}
