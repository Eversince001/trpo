using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TConverter

    {

        /*Основание с. сч.*/

        public int Fp;

        /*Защита от зацикливания*/

        public int MaxIter = 10;

        public TConverter(int n)

        {

            Fp = n;

        }

        /*Установить новое основание с. сч.*/

        /*Получить основание с. сч.*/

        public int SetP

        {

            set { this.Fp = value; }

            get { return this.Fp; }

        }

        /*Перевод из 10 с.с. в p*/

        public string P10_To_P(double ch)

        {

            string res = "";

            bool flag = false; //Отрицательное число

            if (ch < 0)

            {

                flag = true;

                ch *= -1;

            }

            long cel = (long)ch;

            double ost = ch - cel;

            long ost1 = 0;

            /*Перевод целой части*/

            while (cel >= Fp)

            {

                /*Берем остаток*/

                ost1 = (long)(cel % Fp);

                /*Перевод в символ и запись в строку*/

                if (ost1 >= 10)

                    res += IntToChar((long)ost1);

                else

                    res += Convert.ToString(ost1);

                /*Считаем*/

                cel = (long)(cel / Fp);

            }

            /*Запись последнего символа*/

            if (cel >= 10)

                res += IntToChar((long)cel);

            else

                res += Convert.ToString(cel);

            /*Переворот строки*/

            char[] buf = res.Reverse().ToArray();

            res = "";

            for (long i = 0; i < buf.Length; i++)

                res += buf[i];

            double os = 0.0;

            /*Перевод дробной части*/

            if (ost != 0.0)

            {

                long i;

                res += '.';

                for (i = 0; i < MaxIter && ost != 0.0; i++)

                {

                    os = ost * Fp;

                    cel = (long)os;

                    if (cel >= 10)

                        res += IntToChar((long)cel);

                    else

                        res += cel;

                    ost = os - cel;

                }

                if (i == MaxIter)

                    res += 'S';

            }

            if (flag)

                res = '-' + res;

            return res;

        }

        /*Перевод числа в символ*/

        public string IntToChar(long n)

        {

            string S = "";

            switch (n)

            {

                case 10: S = "A"; break;

                case 11: S = "B"; break;

                case 12: S = "C"; break;

                case 13: S = "D"; break;

                case 14: S = "E"; break;

                case 15: S = "F"; break;

                default: break;

            }

            return S;

        }

        /*Преобразовать символ в число*/

        public long CharToInt(char sym)

        {

            long n = 0;

            switch (sym)

            {

                case 'A': n = 10; break;

                case 'B': n = 11; break;

                case 'C': n = 12; break;

                case 'D': n = 13; break;

                case 'E': n = 14; break;

                case 'F': n = 15; break;

                default: break;

            }

            return n;

        }

        /*Преобразовать строку в число в 10 с. сч.*/

        public double P_To_10(string str)

        {

            double res = 0.0;

            string[] te = str.Split('.'); //Деление на целую и дробную части

            long len = te[0].Length; //Длина целой части

            long sym = 0;

            char s;

            long flag = 0; //Отрицательное число

            //Перевод целой части

            for (int i = 0; i < len; i++)

            {

                if (te[0].ElementAt(i) == '-')

                {

                    i++;

                    flag = 1;

                }

                //Взятие символа строки

                s = te[0].ElementAt(i);

                //Если это буква, то перевести в число

                if (s >= 'A')

                    sym = CharToInt(s);

                else

                    sym = Convert.ToInt32(te[0].ElementAt(i)) - '0';

                //Считаем

                res += sym * Math.Pow(Fp, len - 1 - i);

            }

            //Если есть дробная часть

            if (te.Length > 1)

            {

                len = te[1].Length;

                //Перевод дробной части

                for (int i = 0; i < te[1].Length; i++)

                {

                    //Взятие символа строки

                    s = te[1].ElementAt(i);

                    //Если это буква, то перевести в число

                    if (s >= 'A')

                        sym = CharToInt(s);

                    else

                        sym = Convert.ToInt32(te[1].ElementAt(i)) - '0';

                    //Считаем

                    res += sym * Math.Pow(Fp, -i - 1);

                }

            }

            if (flag == 1)

                res *= -1;

            return res;

        }

    }
}
