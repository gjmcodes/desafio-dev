using ByC.Domain.Transactions.Entities;
using FluentValidation;

namespace ByC.Domain.Transactions.Validations
{
    public class CNABValidation : AbstractValidator<TransactionRoot>
    {
        public CNABValidation()
        {
            RuleFor(p => p.cnab).NotEmpty().WithMessage("CNAB is empty");
            RuleFor(p => p.cnab).Length(80).WithMessage($"CNAB length must be equal to 80 on 0-based index.");
        }
    }
}
