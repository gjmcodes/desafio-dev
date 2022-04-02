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

    public static class CNABExtensions
    {
        public static string ParseCnabString(this CNABData data, string cnab)
        {
            var index = data.IndexStart - CNABData.zeroBasedOffset;
            var length = data.Length;

            if ((index + length) >= cnab.Length)
                length -= CNABData.zeroBasedOffset;

            var value = cnab.Substring(index, length);
            return value;
        }
    }
}
