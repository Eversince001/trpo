using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TEditor

    {

        /*Число в строчном представлении*/

        public string number;

        /*Максимальное количество символов в числе*/

        public int MaxLength = 15;

        /*Состояние редактора. 0 - редактирование 1 числа, 1 - редактирование 2 числа, 2 - режим выбора операции, 3 - вывод результата*/

        private int state;

        /*Состояние редактора комплексного числа: true - действительная часть, false - мнимая часть*/

        private bool stateComplex;

        public TEditor()

        {

            number = "";

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

            if (number.Length < MaxLength)

            {

                if (number == "0")

                {

                    if (n >= 10)

                        number = IntToHex(n);

                    else

                    if (n != 0)

                        number = Convert.ToString(n);

                }

                else

                {

                    if (n >= 10)

                        number += IntToHex(n);

                    else

                    {

                        if (n != 0)
                            number += Convert.ToString(n);
                        else

                            number += Convert.ToString(n);

                    }

                }

            }

            return number;

        }

        /*Добавление и изменение знака*/

        public string AddAndChangeSign()

        {

            if (number.Length != 0)

                if (number[0] != '-')

                    number = '-' + number;

                else

                    number = number.Remove(0, 1);

            return number;

        }

        /*Добавление разделителя целой и дробной частей*/

        public string AddDot(int type)

        {

            if (type == 2)

            {

                if (number.Length == 0)

                    number = "0.";

                else

                {

                    int ind = number.IndexOf('/');

                    if (ind == -1)

                        number = number + '/';

                }

            }

            else

            {

                if (number.Length == 0)

                    number = "0.";

                else

                {

                    int ind = number.IndexOf('.');

                    if (ind == -1)

                        number = number + '.';

                }

            }

            return number;

        }

        /*Удаление символа, стоящего справа*/

        public string RemoveLastSymbol()

        {

            if (number.Length != 0)

                number = number.Remove(number.Length - 1);

            return number;

        }

        /*Очищение*/

        public string Clear()

        {

            number = "";

            return number;

        }

        /*Смена состояния редактора*/

        public int State

        {

            set { this.state = value; }

            get { return this.state; }

        }

        public void Re()

        {

            if (stateComplex == false)

                stateComplex = true;

        }

        public void Im()

        {

            if (stateComplex == true)

                stateComplex = false;

        }

    }
}
