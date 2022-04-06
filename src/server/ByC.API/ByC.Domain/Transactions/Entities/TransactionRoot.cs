using ByC.Domain.Transactions.Factories;
using ByC.Domain.Transactions.Models;
using ByC.Domain.Transactions.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ByC.Domain.Transactions.Entities
{
    public class TransactionRoot
    {
        const int cnabLengthZeroBased = 80;

        public Guid Id { get; private set; }
        public int? Type { get; private set; }
        public DateTime? Date { get; private set; }
        public decimal? Value { get; private set; }
        public string Document { get; private set; }
        public string Card { get; private set; }
        public TimeSpan? Hour { get; private set; }
        public string StoreOwnerName { get; private set; }
        public string StoreName { get; private set; }

        public string CnabId { get; private set; }
        public virtual CnabRoot Cnab { get; private set; } 
        //For EF use
        protected TransactionRoot() { }

        public TransactionRoot(string cnab)
        {
            this.Id = Guid.NewGuid();
            this.CnabId = cnab;

            if (this.CnabId.Length == cnabLengthZeroBased)
            {
                this.Type = ParseInt(CNABDataFactory.Type.ParseCnabString(CnabId));
                this.Date = ParseDate(CNABDataFactory.Date.ParseCnabString(CnabId));
                this.Document = CNABDataFactory.Document.ParseCnabString(CnabId);
                this.Card = CNABDataFactory.Card.ParseCnabString(CnabId);
                this.Hour = ParseTimeSpan(CNABDataFactory.Hour.ParseCnabString(CnabId));
                this.StoreOwnerName = CNABDataFactory.StoreOwnerName.ParseCnabString(CnabId);
                this.StoreName = CNABDataFactory.StoreName.ParseCnabString(CnabId);

                this.Value = ParseValue(CNABDataFactory.Value.ParseCnabString(CnabId));
                if (Value.HasValue)
                    this.Value = GetTransactionFixedValue(this.Value);
            }
        }

        #region VALIDATIONS
        public ValidationResult IsValid()
        {


            ValidationResult result = new CNABValidation().Validate(this);
            if (!result.IsValid)
                return result;

            result = new TransactionValidation().Validate(this);

            return result;
        }
        #endregion

        static decimal? GetTransactionFixedValue(decimal? value)
        {
            if (!value.HasValue)
                return null;

            return value / 100;
        }

        public static int? ParseInt(string substringIntCnab)
        {
            int value;
            if (int.TryParse(substringIntCnab, out value))
                return value;

            return null;
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
