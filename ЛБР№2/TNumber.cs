using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TNumber

    {

        //Число

        public string number;

        //Основание системы счисления

        int p;

        //Конвертер

        TConverter conv;

        //Конструктор

        public TNumber(string num, int bas)

        {

            //Сист. сч.

            p = bas;

            //Число

            number = num;

            //Конвертер

            conv = new TConverter(bas);

        }


        private string deleteZero(string str)
        {
            if (str.Contains("."))
            if (str[str.Length - 1] == 'S' || str[str.Length - 1] == '0')
            {
                str = str.Remove(str.Length - 1);
                str = deleteZero(str);
            }

            return str;
        }


        //Сложить

        public TNumber Summ(TNumber num)

        {

            TNumber res = new TNumber(number, p);

            res.number = conv.P10_To_P((conv.P_To_10(number) + conv.P_To_10(num.number)));

            res.number = res.number.Replace(',', '.');

            res.number = deleteZero(res.number);

            return res;

        }

        //Умножить

        public TNumber Mult(TNumber num)

        {

            TNumber res = new TNumber(number, p);

            res.number = conv.P10_To_P((conv.P_To_10(number) * conv.P_To_10(num.number))).ToString();

            res.number = res.number.Replace(',', '.');

            res.number = deleteZero(res.number);

            return res;

        }

        //Вычесть

        public TNumber Sub(TNumber num)

        {

            TNumber res = new TNumber(number, p);

            res.number = conv.P10_To_P((conv.P_To_10(number) - conv.P_To_10(num.number))).ToString();

            res.number = res.number.Replace(',', '.');

            res.number = deleteZero(res.number);

            return res;

        }

        //Делить

        public TNumber Div(TNumber num)

        {

            TNumber res = new TNumber(number, p);

            res.number = conv.P10_To_P((conv.P_To_10(number) / conv.P_To_10(num.number))).ToString();

            res.number = res.number.Replace(',', '.');

            res.number = deleteZero(res.number);

            return res;

        }

        //Обратить

        public TNumber Pay()

        {

            TNumber res = new TNumber(number, p);

            res.number = conv.P10_To_P((1 / conv.P_To_10(number))).ToString();

            res.number = res.number.Replace(',', '.');

            res.number = deleteZero(res.number);

            return res;

        }

        //Квадрат

        public TNumber Sqr()

        {

            TNumber res = new TNumber(number, p);

            res.number = conv.P10_To_P(Math.Pow(conv.P_To_10(number), 2)).ToString();

            res.number = res.number.Replace(',', '.');

            res.number = deleteZero(res.number);

            return res;

        }

        //Копия числа

        public TNumber Copy()

        {

            TNumber res = new TNumber(number, p);

            return res;

        }

        //Установить и получить число числом


        //Установить и получить число строкой

        public string getNumber()
        {
            return number;
        }

        //Установить и получить основание строкой

        public string PString

        {

            set { this.p = Convert.ToInt32(value); }

            get { return Convert.ToString(p); }

        }

        //Установить и получить основание числом

        public int PInt

        {

            set { this.p = value; }

            get { return p; }

        }

    }
}
