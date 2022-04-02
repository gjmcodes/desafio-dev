using ByC.Domain.Transactions.Factories;
using ByC.Domain.Transactions.Models;
using System;
using System.Globalization;

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

        //For EF use
        protected TransactionRoot() { }

        public TransactionRoot(string cnab)
        {
            this.Id = Guid.NewGuid();
            this.Type = CNABDataFactory.Type.ParseCnabString(cnab);
            this.Date = ParseDate(CNABDataFactory.Date.ParseCnabString(cnab));
            this.Document = CNABDataFactory.Document.ParseCnabString(cnab);
            this.Card = CNABDataFactory.Card.ParseCnabString(cnab);
            this.Hour = ParseTimeSpan(CNABDataFactory.Hour.ParseCnabString(cnab));
            this.StoreOwnerName = CNABDataFactory.StoreOwnerName.ParseCnabString(cnab);
            this.StoreName = CNABDataFactory.StoreName.ParseCnabString(cnab);

            this.Value = ParseValue(CNABDataFactory.Value.ParseCnabString(cnab));
            if (Value.HasValue)
                this.Value = GetTransactionFixedValue(this.Value);
        }

        static decimal? GetTransactionFixedValue(decimal? value)
        {
            if (!value.HasValue)
                return null;

            return value / 100;
        }
        public static DateTime? ParseDate(string substringDateCnab)
        {
            DateTime date;
            if (DateTime.TryParseExact(substringDateCnab, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;

            return null;
        }
        public static TimeSpan? ParseTimeSpan(string substringTimespan)
        {
            TimeSpan timeSpan;
            if (TimeSpan.TryParseExact(substringTimespan, "hms", CultureInfo.InvariantCulture, out timeSpan))
                return timeSpan;

            return null;
        }
        public static decimal? ParseValue(string substringValueCnab)
        {
            decimal value;
            if (decimal.TryParse(substringValueCnab, out value))
                return value;

            return null;
        }

    }
}
