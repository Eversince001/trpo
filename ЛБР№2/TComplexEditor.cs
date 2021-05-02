using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TComplexEditor

    {

        /*Число в строчном представлении*/

        public string number;

        public string re, im;

        /*Максимальное количество символов в числе*/

        public int MaxLength = 15;

        /*Состояние редактора. 0 - редактирование 1 числа, 1 - редактирование 2 числа, 2 - режим выбора операции, 3 - вывод результата*/

        private int state;

        /*Состояние редактора комплексного числа: true - действительная часть, false - мнимая часть*/

        private bool stateComplex;

        public TComplexEditor()

        {

            number = "0+0i";

            re = "0";

            im = "0";

            state = 0;

            stateComplex = true;

        }

        /*Перевод числа в символ*/

        public string IntToHex(int n)

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

        /*Добавление символов*/

        public string AddSymbol(int n)

        {

            if (re.Length + im.Length < MaxLength)

            {

                if (stateComplex == true)

                {

                    if (re == "0")

                    {

                        if (n >= 10)

                            re = IntToHex(n);

                        else

                        if (n != 0)

                            re = Convert.ToString(n);

                    }

                    else

                    {

                        if (n >= 10)

                            re += IntToHex(n);

                        else

                        {

                            if (n != 0)

                                re += Convert.ToString(n);

                            else

                                re += Convert.ToString(n);

                        }

                    }

                }

                else

                {

                    if (im == "0")

                    {

                        if (n >= 10)

                            im = IntToHex(n);

                        else

                        if (n != 0)

                            im = Convert.ToString(n);

                    }

                    else

                    {

                        if (n >= 10)

                            im += IntToHex(n);

                        else

                        {

                            if (n != 0)

                                im += Convert.ToString(n);

                            else

                                im += Convert.ToString(n);

                        }

                    }

                }

            }

            if (re != "")

                number = re;

            else

                number = "0";

            if (im == "")

                im = "0";

            if (Convert.ToDouble(im) >= 0)

                number += "+" + im + "i";

            else

                number += im + "i";

            return number;

        }

        /*Добавление и изменение знака*/

        public string AddAndChangeSign()

        {

            if (stateComplex)

            {

                if (re != "0")

                    if (re[0] != '-')

                        re = '-' + re;

                    else

                        re = re.Remove(0, 1);

            }

            else

            {

                if (im != "0")

                    if (im[0] != '-')

                        im = '-' + im;

                    else

                        im = im.Remove(0, 1);

            }

            if (re != "")

                number = re;

            else

                number = "0";

            if (im == "")

                im = "0";

            if (Convert.ToDouble(im) >= 0)

                number += "+" + im + "i";

            else

                number += im + "i";

            return number;

        }

        /*Добавление разделителя целой и дробной частей*/

        public string AddDot(int type)

        {

            if (stateComplex)

            {

                if (re.Length == 0)

                    re = "0.";

                else

                {

                    int ind = re.IndexOf('.');

                    if (ind == -1)

                        re = re + ',';

                }

            }
            else

            {

                if (im.Length == 0)

                    im = "0.";

                else

                {

                    int ind = im.IndexOf('.');

                    if (ind == -1)

                        im = im + ',';

                }

            }

            if (re != "")

                number = re;

            else

                number = "0";

            if (im == "")

                im = "0";

            if (Convert.ToDouble(im) >= 0)

                number += "+" + im + "i";

            else

                number += im + "i";

            return number;

        }

        /*Удаление символа, стоящего справа*/

        public string RemoveLastSymbol()

        {

            if (stateComplex)

            {

                re = re.Remove(re.Length - 1, 1);

            }

            else

            {

                im = im.Remove(im.Length - 1, 1);

            }

            if (re == "")

                re = "0";

            if (im == "")

                im = "0";

            number = re;

            if (Convert.ToDouble(im) >= 0)

                number += "+" + im + "i";

            else

                number += im + "i";

            return number;

        }

        /*Очищение*/

        public string Clear()

        {

            re = "0";

            im = "0";

            number = "0+0i";

            return number;

        }

        /*Смена состояния редактора*/

        public int State

        {

            set { this.state = value; }

            get { return this.state; }

        }

        public string Re()

        {

            if (stateComplex == false)

                stateComplex = true;

            number = re;

            if (Convert.ToDouble(im) >= 0)

                number += "+" + im + "i";

            else

                number += im + "i";

            return number;

        }

        public string Im()

        {

            if (stateComplex == true)

                stateComplex = false;

            number = re;

            if (Convert.ToDouble(im) >= 0)

                number += "+" + im + "i";

            else

                number += im + "i";

            return number;

        }

    }
}
