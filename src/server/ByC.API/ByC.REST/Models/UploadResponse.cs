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

    public class InvalidCNABs
    {
        public string Cnab { get; set; }
        public string[] Validations { get; set; }

        public InvalidCNABs(string cnab, string[] validations)
        {
            Cnab = cnab;
            Validations = validations;
        }
    }
}
