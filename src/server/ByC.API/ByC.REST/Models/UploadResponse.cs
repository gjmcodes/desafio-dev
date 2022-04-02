using FluentValidation.Results;

namespace ByC.REST.Models
{
    public class UploadResponse
    {
        public List<string> ValidCNABs { get; set; }
        public List<InvalidCNABs> InvalidCNABs { get; set; }

        public void AddValidCnab(string cnab)
        {
            ValidCNABs = ValidCNABs ?? new List<string>();
            ValidCNABs.Add(cnab);
        }
        public void AddInvalidCnab(string cnab, ValidationResult validation)
        {
            InvalidCNABs = InvalidCNABs ?? new List<InvalidCNABs>();

            InvalidCNABs.Add(new InvalidCNABs(cnab, 
                validation.Errors.Select(x => x.ErrorMessage).ToArray()));
        }
    }

    public struct InvalidCNABs
    {
        public string cnab;
        public string[] validations;

        public InvalidCNABs(string cnab, string[] validations)
        {
            this.cnab = cnab;
            this.validations = validations;
        }
    }
}
