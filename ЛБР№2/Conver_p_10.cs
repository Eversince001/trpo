using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class Conver_p_10
    {
        //Преобразовать цифру в число.
        static double char_To_num(char ch) 
        {
            if (ch < 58)
                return ch - '0';
            else
                return ch - 'A' + 10;
        }


        //Преобразовать строку в число
        private static double Convert(string P_num, int P, double weight) 
        {
            if (P_num == "0")
            {
                return 0;
            }
            else
            {
                double result = 0;
                int i = 0;
                while (i < P_num.Length)
                {
                    result += char_To_num(P_num[i]) * weight;
                    weight /= P;
                    i++;
                }
                return result;
            }
        }


        //Преобразовать из с.сч. с основанием р 
        //в с.сч. с основанием 10.
        public static double dval(string P_num, int P) 
        {
            if (P_num.Length == 0)
                return 0;
            if (P_num == "0")
            {
                return 0;
            }
            else
            {
                double result, weight = 1;

                bool isPositive = true;

                int i = 0;

                string number = string.Empty;

                if (P_num[i] == '-')
                {
                    isPositive = false;
                    i++;
                }
                if (P_num[i] != '0')
                {
                    for (; i < P_num.Length && P_num[i] != '.'; i++)
                    {
                        number += P_num[i];
                    }
                    weight = isPositive ? Math.Pow(P, i - 1) : Math.Pow(P, i - 2);
                    if (i < P_num.Length)
                    {
                        if (P_num[i] == '.')
                        {
                            for (i = i + 1; i < P_num.Length; i++)
                            {
                                number += P_num[i];
                            }
                        }
                    }
                }
                else
                {
                    bool isNotMet = true;
                    for (i = i + 2; i < P_num.Length; i++)
                    {
                        if (isNotMet && P_num[i] != '0')
                        {
                            isNotMet = false;
                            weight = isPositive ? Math.Pow(P, -(i - 1)) : Math.Pow(P, -(i - 2));
                        }
                        if (!isNotMet)
                            number += P_num[i];
                    }
                }
                result = isPositive ? Convert(number, P, weight) : -Convert(number, P, weight);
                return result;
            }

        }
    }


}
