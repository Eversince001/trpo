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

            public int numer;

            public int denom;

        }

        NUMBER number = new NUMBER();

        //Конструктор

        public TFractNumber(int num, int den, int bas)

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

            res.number.numer = number.numer * num.number.denom + num.number.numer * number.denom;

            res.number.denom = number.denom * num.number.denom;

            int nod = (int)Nod(res.number.numer, res.number.denom);

            if (nod != 0)

            {

                res.number.numer /= nod;

                res.number.denom /= nod;

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

            res.number.numer = number.numer * num.number.numer;

            res.number.denom = number.denom * num.number.denom;

            int nod = (int)Nod(res.number.numer, res.number.denom);

            if (nod != 0)

            {

                res.number.numer /= nod;

                res.number.denom /= nod;

            }

            return res;

        }

        //Вычесть

        public TFractNumber Sub(TFractNumber num)

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            res.number.numer = number.numer * num.number.denom - num.number.numer * number.denom;

            res.number.denom = number.denom * num.number.denom;

            int nod = (int)Nod(Math.Abs(res.number.numer), Math.Abs(res.number.denom));

            if (nod > 0)

            {

                res.number.numer /= nod;

                res.number.denom /= nod;

            }

            return res;

        }

        //Делить

        public TFractNumber Div(TFractNumber num)

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            res.number.numer = number.numer * num.number.denom;

            res.number.denom = number.denom * num.number.numer;

            int nod = (int)Nod(res.number.numer, res.number.denom);

            if (nod != 0)

            {

                res.number.numer /= nod;

                res.number.denom /= nod;

            }

            return res;

        }

        //Обратить

        public TFractNumber Pay()

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            int denom = number.denom;

            res.number.denom = number.numer;

            res.number.numer = number.denom;

            int nod = (int)Nod(res.number.numer, res.number.denom);

            if (nod != 0)

            {

                res.number.numer /= nod;

                res.number.denom /= nod;

            }

            return res;

        }

        //Квадрат

        public TFractNumber Sqr()

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            res.number.numer = number.numer * number.numer;

            res.number.denom = number.denom * number.denom;

            int nod = (int)Nod(res.number.numer, res.number.denom);

            if (nod != 0)

            {

                res.number.numer /= nod;

                res.number.denom /= nod;

            }

            return res;

        }

        //Копия числа

        public TFractNumber Copy()

        {

            TFractNumber res = new TFractNumber(number.numer, number.denom, p);

            return res;

        }

        //Установить и получить число числом

        public double NumberDouble

        {

            set { this.number.numer = (int)value; }

            get { return this.number.numer; }

        }

        //Установить и получить число строкой

        public string NumberString

        {

            set

            {

                var str = value.Split('/');

                number.numer = Convert.ToInt32(str[0]);

                number.denom = Convert.ToInt32(str[1]);

            }

            get

            {

                return number.numer.ToString() + "/" + number.denom.ToString();

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
