using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TFractEditor

    {

        /*Число в строчном представлении*/

        public string number;

        public string numer, denom;

        /*Максимальное количество символов в числе*/

        public int MaxLength = 15;

        /*Состояние редактора. 0 - редактирование 1 числа, 1 - редактирование 2 числа, 2 - режим выбора операции, 3 - вывод результата*/

        private int state;

        /*Состояние редактора комплексного числа: true - действительная часть, false - мнимая часть*/

        private bool stateComplex;

        public TFractEditor()

        {

            number = "0/0";

            numer = "0";

            denom = "0";

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

            if (numer.Length + denom.Length < MaxLength)

            {

                if (stateComplex == true)

                {

                    if (numer == "0")

                    {

                        if (n >= 10)

                            numer = IntToHex(n);

                        else

                        if (n != 0)

                            numer = Convert.ToString(n);

                    }

                    else

                    {

                        if (n >= 10)

                            numer += IntToHex(n);

                        else

                        {

                            if (n != 0)

                                numer += Convert.ToString(n);

                            else

                                numer += Convert.ToString(n);

                        }

                    }

                }

                else

                {

                    if (denom == "0")

                    {

                        if (n >= 10)

                            denom = IntToHex(n);

                        else

                        if (n != 0)

                            denom = Convert.ToString(n);

                    }

                    else

                    {

                        if (n >= 10)

                            denom += IntToHex(n);

                        else

                        {

                            if (n != 0)

                                denom += Convert.ToString(n);

                            else

                                denom += Convert.ToString(n);

                        }

                    }

                }

            }

            number = numer + "/" + denom;

            return number;

        }

        /*Добавление и изменение знака*/

        public string AddAndChangeSign()

        {

            if (numer[0] != '-')

                numer = '-' + numer;

            else

                numer = numer.Remove(0, 1);

            number = numer + "/" + denom;

            return number;

        }

        /*Добавление разделителя целой и дробной частей*/

        public string AddDot(int type)

        {

            if (stateComplex)

            {

                if (numer.Length == 0)

                    numer = "0.";

                else

                {

                    int ind = numer.IndexOf('.');

                    if (ind == -1)

                        numer = numer + ',';

                }

            }

            else

            {

                if (denom.Length == 0)

                    denom = "0.";

                else

                {

                    int ind = denom.IndexOf('.');

                    if (ind == -1)

                        denom = denom + ',';

                }

            }

            if (numer != "")

                number = numer;

            else

                number = "0";

            if (denom == "")

                denom = "0";

            if (Convert.ToDouble(denom) >= 0)

                number += "+" + denom + "i";

            else

                number += denom + "i";

            return number;

        }

        /*Удаление символа, стоящего справа*/

        public string RemoveLastSymbol()

        {

            if (number.Length != 0)

            {

                if (!stateComplex)

                {

                    if (denom.Length != 0)

                        denom = denom.Remove(denom.Length - 1);

                    if (denom.Length == 0)

                        denom = "0";

                }

                else

                {

                    if (numer.Length != 0)

                        numer = numer.Remove(numer.Length - 1);

                    if (numer.Length == 0)

                        numer = "0";

                }

            }

            number = numer + "/" + denom;

            return number;

        }

        /*Очищение*/

        public string Clear()

        {

            numer = "0";

            denom = "0";

            number = "0/1";

            return number;

        }

        /*Смена состояния редактора*/

        public int State

        {

            set { this.state = value; }

            get { return this.state; }

        }

        public string Numer()

        {

            if (stateComplex == false)

                stateComplex = true;

            return number;

        }

        public string Denom()

        {

            if (stateComplex == true)

                stateComplex = false;

            return number;

        }

    }
}
