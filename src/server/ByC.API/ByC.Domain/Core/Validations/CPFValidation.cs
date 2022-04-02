using System;
using System.Collections.Generic;
using System.Text;

namespace ByC.Domain.Core.Validations
{
    public class CPFValidation
    {
		static int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		static int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		
		public static bool CPFIsValid(string cpf)
		{
			
			string tempCPF;
			string digit;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCPF = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCPF[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digit = resto.ToString();
			tempCPF = tempCPF + digit;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCPF[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digit = digit + resto.ToString();
			return cpf.EndsWith(digit);
		}
	}
}
