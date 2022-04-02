using ByC.Domain.Transactions.Entities;
using FluentValidation;

namespace ByC.Domain.Transactions.Validations
{
    public class TransactionValidation : AbstractValidator<TransactionRoot>
    {
        public TransactionValidation()
        {
            RuleFor(p => p.Type).NotNull();
            RuleFor(p => p.Date).NotNull();
            RuleFor(p => p.Value).NotNull();
            RuleFor(p => p.Document).NotNull().NotEmpty();
            RuleFor(p => p.Card).NotNull().NotEmpty();
            RuleFor(p => p.Hour).NotNull().NotEmpty();
            RuleFor(p => p.StoreOwnerName).NotNull().NotEmpty();
            RuleFor(p => p.StoreName).NotNull().NotEmpty();
        }
    }
}
