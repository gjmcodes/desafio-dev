using System.Linq;
using System.Text.RegularExpressions;

namespace ByC.Domain.Core.Validations
{
    public static class CardValidation
    {
        static Regex numberOnlyRegex = new Regex(@"^-?[0-9][0-9,\.]+$");

        public static bool CardHasHiddenCharacters(string card)
        {
            var firstThird = card.Substring(0, 4).Trim();
            var secondThird = card.Substring(4, 4).Trim();
            var thirdThird = card.Substring(8, 4).Trim();

            var firstThirdMatch = numberOnlyRegex.Match(firstThird).Success;
            var secondThirdMatch = secondThird.All(x => x == '*');
            var thirdThirdMatch = numberOnlyRegex.Match(thirdThird).Success;

            return firstThirdMatch && secondThirdMatch && thirdThirdMatch;
        }
    }
}
