using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TFractNumber

    {

        //Число

        //double number;

        //Основание системы счисления

        int p;

        //Конвертер

        TConverter conv;

        public struct NUMBER

        {

            public string numer;

            public string denom;

        }

        public NUMBER number = new NUMBER();

        //Конструктор

        public TFractNumber(string num, string den, int bas)

        {

            //Сист. сч.

            p = bas;

            //Число

            number.numer = num;

            number.denom = den;

            //Конвертер

            conv = new TConverter(bas);

        }

        //Сложить

        public TFractNumber Summ(TFractNumber num)

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            res.number.numer = (Convert.ToInt32(number.numer) * Convert.ToInt32(num.number.denom) + Convert.ToInt32(num.number.numer) * Convert.ToInt32(number.denom)).ToString();

            res.number.denom = (Convert.ToInt32(number.denom) * Convert.ToInt32(num.number.denom)).ToString();

            int nod = (int)Nod(Convert.ToInt32(res.number.numer), Convert.ToInt32(res.number.denom));

            if (nod != 0)

            {

                res.number.numer = (Convert.ToInt32(res.number.numer) / nod).ToString();

                res.number.denom = (Convert.ToInt32(res.number.denom) / nod).ToString();

            }

            return res;

        }

        long Nod(long a, long b)

        {

            while (a != 0 && b != 0)

                if (a >= b)

                    a %= b;

                else

                    b %= a;

            return a | b;

        }

        //Умножить

        public TFractNumber Mult(TFractNumber num)

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            res.number.numer = (Convert.ToInt32(number.numer) * Convert.ToInt32(num.number.numer)).ToString();

            res.number.denom = (Convert.ToInt32(number.denom) * Convert.ToInt32(num.number.denom)).ToString();

            int nod = (int)Nod(Convert.ToInt32(res.number.numer), Convert.ToInt32(res.number.denom));

            if (nod != 0)

            {
                res.number.numer = (Convert.ToInt32(res.number.numer) / nod).ToString();

                res.number.denom = (Convert.ToInt32(res.number.denom) / nod).ToString();

            }

            return res;

        }

        //Вычесть

        public TFractNumber Sub(TFractNumber num)

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            res.number.numer = (Convert.ToInt32(number.numer) * Convert.ToInt32(num.number.denom) - Convert.ToInt32(num.number.numer) * Convert.ToInt32(number.denom)).ToString();

            res.number.denom = (Convert.ToInt32(number.denom) * Convert.ToInt32(num.number.denom)).ToString();

            int nod = (int)Nod(Math.Abs(Convert.ToInt32(res.number.numer)), Math.Abs(Convert.ToInt32(res.number.denom)));

            if (nod > 0)

            {
                res.number.numer = (Convert.ToInt32(res.number.numer) / nod).ToString();

                res.number.denom = (Convert.ToInt32(res.number.denom) / nod).ToString();

            }

            return res;

        }

        //Делить

        public TFractNumber Div(TFractNumber num)

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            res.number.numer = (Convert.ToInt32(number.numer) * Convert.ToInt32(num.number.denom)).ToString();

            res.number.denom = (Convert.ToInt32(number.denom) * Convert.ToInt32(num.number.numer)).ToString();

            int nod = (int)Nod(Convert.ToInt32(res.number.numer), Convert.ToInt32(res.number.denom));

            if (nod != 0)

            {

                res.number.numer = (Convert.ToInt32(res.number.numer) / nod).ToString();

                res.number.denom = (Convert.ToInt32(res.number.denom) / nod).ToString();

            }

            return res;

        }

        //Обратить

        public TFractNumber Pay()

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            int denom = Convert.ToInt32(number.denom);

            res.number.denom = number.numer;

            res.number.numer = number.denom;

            int nod = (int)Nod(Convert.ToInt32(res.number.numer), Convert.ToInt32(res.number.denom));

            if (nod != 0)

            {

                res.number.numer = (Convert.ToInt32(res.number.numer) / nod).ToString();

                res.number.denom = (Convert.ToInt32(res.number.denom) / nod).ToString();
            }

            return res;

        }

        //Квадрат

        public TFractNumber Sqr()

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            res.number.numer = (Convert.ToInt32(number.numer) * Convert.ToInt32(number.numer)).ToString();

            res.number.denom = (Convert.ToInt32(number.denom) * Convert.ToInt32(number.denom)).ToString();

            int nod = (int)Nod(Convert.ToInt32(res.number.numer), Convert.ToInt32(res.number.denom));

            if (nod != 0)

            {
                res.number.numer = (Convert.ToInt32(res.number.numer) / nod).ToString();

                res.number.denom = (Convert.ToInt32(res.number.denom) / nod).ToString();

            }

            return res;

        }

        //Копия числа

        public TFractNumber Copy()

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            return res;

        }


        public string NumberString
        {
            set

            {

                var str = value.Split('|');

                number.numer = str[0];

                number.denom = str[1];

            }
            get
            {

                return number.numer.ToString() + "|" + number.denom.ToString();

            }

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
