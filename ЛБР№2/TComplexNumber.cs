using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TComplexNumber

    {

        //Число

        //double number;

        //Основание системы счисления

        int p;

        //Конвертер

        TConverter conv;

        public struct NUMBER

        {

            public string re;

            public string im;

        };

        public NUMBER number;

        //Конструктор

        public TComplexNumber(string re, string im, int bas)

        {

            //Сист. сч.

            p = bas;

            //Число

            number.re = re;

            number.im = im;

            //number = num;

            //Конвертер

            conv = new TConverter(bas);

        }

        //Сложить

        public TComplexNumber Summ(TComplexNumber num)

        {

            TComplexNumber res = new TComplexNumber(number.re, number.im, p);

            res.number.re = (Convert.ToDouble(number.re) + Convert.ToDouble(num.number.re)).ToString();

            res.number.im = (Convert.ToDouble(number.im) + Convert.ToDouble(num.number.im)).ToString();

            return res;

        }

        //Умножить

        public TComplexNumber Mult(TComplexNumber num)

        {

            TComplexNumber res = new TComplexNumber(number.re, number.im, p);

            res.number.re = (Convert.ToDouble(number.re) * Convert.ToDouble(num.number.re) - Convert.ToDouble(number.im) * Convert.ToDouble(num.number.im)).ToString();

            res.number.im = (Convert.ToDouble(number.re) * Convert.ToDouble(num.number.im) + Convert.ToDouble(number.im) * Convert.ToDouble(num.number.re)).ToString();

            return res;

        }

        //Вычесть

        public TComplexNumber Sub(TComplexNumber num)

        {

            TComplexNumber res = new TComplexNumber(number.re, number.im, p);

            res.number.re = (Convert.ToDouble(number.re) - Convert.ToDouble(num.number.re)).ToString();

            res.number.im = (Convert.ToDouble(number.im) - Convert.ToDouble(num.number.im)).ToString();

            return res;

        }

        //Делить

        public TComplexNumber Div(TComplexNumber num)

        {

            TComplexNumber res = new TComplexNumber(number.re, number.im, p);

            res.number.re = ((Convert.ToDouble(number.re) * Convert.ToDouble(num.number.re) + Convert.ToDouble(number.im) * Convert.ToDouble(num.number.im)) / (Convert.ToDouble(num.number.re) * Convert.ToDouble(num.number.re) + Convert.ToDouble(num.number.im) * Convert.ToDouble(num.number.im))).ToString();

            res.number.im = ((Convert.ToDouble(number.im) * Convert.ToDouble(num.number.re) - Convert.ToDouble(number.re) * Convert.ToDouble(num.number.im)) / (Convert.ToDouble(num.number.re) * Convert.ToDouble(num.number.re) + Convert.ToDouble(num.number.im) * Convert.ToDouble(num.number.im))).ToString();

            return res;

        }

        //Обратить

        public TComplexNumber Pay()

        {

            TComplexNumber res = new TComplexNumber(number.re, number.im, p);

            res.number.re = ((Convert.ToDouble(number.re) / (Convert.ToDouble(number.re) * Convert.ToDouble(number.re) + Convert.ToDouble(number.im) * Convert.ToDouble(number.im)))).ToString();

            res.number.im = ((Convert.ToDouble(number.im) * (-1)) / (Convert.ToDouble(number.re) * Convert.ToDouble(number.re) + Convert.ToDouble(number.im) * Convert.ToDouble(number.im))).ToString();

            return res;

        }

        //Квадрат

        public TComplexNumber Sqr()

        {

            TComplexNumber res = new TComplexNumber(number.re, number.im, p);

            res.number.re = (Convert.ToDouble(number.re) * Convert.ToDouble(number.re) - Convert.ToDouble(number.im) * Convert.ToDouble(number.im)).ToString();

            res.number.im = (Convert.ToDouble(number.re) * Convert.ToDouble(number.im) + Convert.ToDouble(number.im) * Convert.ToDouble(number.re)).ToString();

            return res;

        }

        //Копия числа

        public TComplexNumber Copy()

        {

            TComplexNumber res = new TComplexNumber(number.re, number.im, p);

            return res;

        }

        //Установить и получить число числом

        public double NumberDouble

        {

            set { this.number.re = value.ToString(); }

            get { return Convert.ToDouble(this.number.re); }

        }

        //Установить и получить число строкой

        public string NumberString

        {

            set

            {

                conv.SetP = p;

                if (p != 10)

                    number.re = conv.P_To_10(value).ToString();

                else

                {

                    var str = value.Split('+');

                    if (str.Length < 2)

                    {

                        str = value.Split('-');

                        if (str[0] == "")

                        {

                            str[0] = "-" + str[1];

                            str[1] = str[2];

                        }

                        str[1] = "-" + str[1];

                    }

                    else

                    {

                        if (str[0] == "")

                        {

                            str[0] = "-" + str[1];

                            str[1] = str[2];

                        }

                    }

                    number.re = str[0];

                    str[1] = str[1].Remove(str[1].Length - 1, 1);

                    number.im = str[1];

                    if (value == "")

                        value = "0";

                }

            }

            get

            {

                conv.SetP = p;

                if (number.im.Length > 0)
                {
                    if (Convert.ToDouble(number.im) >= 0)
                        return number.re + "+" + number.im + "i";
                }

                else

                    return number.re + number.im + "i";


                return "";

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
