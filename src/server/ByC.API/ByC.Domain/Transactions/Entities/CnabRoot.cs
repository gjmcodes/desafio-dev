namespace ByC.Domain.Transactions.Entities
{
    public class CnabRoot
    {
        public string Value { get; private set; }

        //For EF Core
        protected CnabRoot()
        {
        }

        public CnabRoot(string cnab)
        {
            this.Value = cnab;
        }
    }
}
