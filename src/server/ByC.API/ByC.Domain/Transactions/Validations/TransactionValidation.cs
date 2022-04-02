using ByC.Domain.Transactions.Entities;
using FluentValidation;

namespace ByC.Domain.Transactions.Validations
{
    public class TransactionValidation : AbstractValidator<TransactionRoot>
    {
        public TransactionValidation()
        {
            RuleFor(p => p.Type).NotNull().WithErrorCode(ValidationCodes.Type.ToString());
            RuleFor(p => p.Type).GreaterThan(0).LessThanOrEqualTo(9).WithErrorCode(ValidationCodes.Type.ToString());
            RuleFor(p => p.Date).NotNull().WithErrorCode(ValidationCodes.Date.ToString());
            RuleFor(p => p.Value).NotNull().WithErrorCode(ValidationCodes.Value.ToString());
            RuleFor(p => p.Document).NotNull().NotEmpty().WithErrorCode(ValidationCodes.Document.ToString());
            RuleFor(p => p.Card).NotNull().NotEmpty().WithErrorCode(ValidationCodes.Card.ToString());
            RuleFor(p => p.Hour).NotNull().NotEmpty().WithErrorCode(ValidationCodes.Hour.ToString());
            RuleFor(p => p.StoreOwnerName).NotNull().NotEmpty().WithErrorCode(ValidationCodes.StoreOwnerName.ToString());
            RuleFor(p => p.StoreName).NotNull().NotEmpty().WithErrorCode(ValidationCodes.StoreName.ToString());
        }
    }
}
