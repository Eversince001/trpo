using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class Conver_10_p
    {

        //Преобразовать целое в символ.
        public static char Int_to_Char(double n)
        {
			string temp = "";
			if (n > -1 && n < 10)
				temp = n.ToString();
			else
				switch (n)
				{
					case 10:
						temp = "A";
						break;
					case 11:
						temp = "B";
						break;
					case 12:
						temp = "C";
						break;
					case 13:
						temp = "D";
						break;
					case 14:
						temp = "E";
						break;
					case 15:
						temp = "F";
						break;
				}
			return temp[0];
		}

        //Преобразовать десятичное целое в с.сч. с основанием р.
        public static string Int_to_P(double N, int p) 
        {
			string result = "";

			// целая часть 
			double whole = Math.Truncate(N);
			double H;
			
			while (whole >= p)
			{
				double f = whole / p;
				H = Math.Truncate(f);
				whole = whole - (H * p);
				result += Int_to_Char(Math.Truncate(whole));
				whole = H;
			}

			result += Int_to_Char(Math.Truncate(whole));
			string resultTemp = "";
			for (int i = result.Length; i > 0; i--)
				resultTemp += result[i - 1];

			return resultTemp;
		}


        //Преобразовать десятичную дробь в с.сч. с основанием р.
        public static string Flt_to_P(double N, int p, int c) 
		{
			string result = ".";

			// целая часть 
			int whole = (int)N;

			//дробная часть
			double fractional = N - whole;
			double N3 = N;

			for (int j = 0; j < c; j++)
			{
				double temp = fractional * p;
				whole = (int)temp;
				N3 = fractional * p - whole;
				result += Int_to_Char(whole);
				fractional = N3;
			}
			return result;
		}


        //Преобразовать десятичное 
        //действительное число в с.сч. с осн. р.
        public static string Do(double N, int p, int c)
        {
			string result = "";
			bool isPositive = true;
			if (N < 0)
            {
				N *= -1;
				result = "-";
			}


			// целая часть 
			double whole = Math.Truncate(N);

			//дробная часть
			double fractional = N - whole;

			result += Int_to_P(whole, p);

			if (fractional != 0)
			{
				result += Flt_to_P(fractional, p, c);
			}



			return result;
		}
    }
}
