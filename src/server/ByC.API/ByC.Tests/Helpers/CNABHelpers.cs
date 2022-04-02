namespace ByC.Tests.Helpers
{
    public static class CNABHelpers
    {
        const string cnabTemplate = "{0}{1}{2}{3}{4}{5}{6}{7}";

        const string typeDefault = "1";
        const string dateDefault = "20190301";
        const string valueDefault = "0000014200";
        const string docDefault = "09620676017";
        const string cardDefault = "4753****3153";
        const string hourDefault = "153453";
        const string ownerNameDefault = "JOÃO MACEDO   ";
        const string storeNameDefault = "BAR DO JOÃO       ";

        public static string GetCNAB(string type = typeDefault,
            string date = dateDefault, string value = valueDefault,
            string doc = docDefault, string card = cardDefault,
            string hour = hourDefault, string owner = ownerNameDefault,
            string store = storeNameDefault)
        {
            return string.Format(cnabTemplate,
                type, date, value, doc, card, hour, owner, store);
        }
    }
}
