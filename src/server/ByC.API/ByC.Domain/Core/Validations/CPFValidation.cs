using System.Linq;

namespace ByC.Domain.Core.Validations
{
    public class CPFValidation
    {
		static int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		static int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		
		public static bool CPFIsValid(string cpf)
		{
			if (cpf.Distinct().Count() == 1)
				return false;

			string tempCPF;
			string digit;
			int sum;
			int remainder;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCPF = cpf.Substring(0, 9);
			sum = 0;

			for (int i = 0; i < 9; i++)
				sum += int.Parse(tempCPF[i].ToString()) * multiplier1[i];
			remainder = sum % 11;
			if (remainder < 2)
				remainder = 0;
			else
				remainder = 11 - remainder;
			digit = remainder.ToString();
			tempCPF = tempCPF + digit;
			sum = 0;
			for (int i = 0; i < 10; i++)
				sum += int.Parse(tempCPF[i].ToString()) * multiplier2[i];
			remainder = sum % 11;
			if (remainder < 2)
				remainder = 0;
			else
				remainder = 11 - remainder;
			digit = digit + remainder.ToString();
			return cpf.EndsWith(digit);
		}
	}
}
