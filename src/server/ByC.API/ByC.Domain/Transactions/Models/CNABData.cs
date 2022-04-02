namespace ByC.Domain.Transactions.Models
{
    public class CNABData
    {
        public const int zeroBasedOffset = 1;
        public string Description { get; private set; }
        public int IndexStart { get; private set; }
        public int IndexEnd { get; private set; }
        public int Length { get; private set; }
        public CNABData(string description, int indexStart, int indexEnd)
        {
            Description = description;
            IndexStart = indexStart;
            IndexEnd = indexEnd;
            Length = (indexEnd - indexStart) + zeroBasedOffset;
        }
    }
}
