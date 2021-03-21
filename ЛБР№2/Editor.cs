using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class Editor
    {
        //Поле для хранения редактируемого числа
        public string number = "";

        //Точность представления результата
        public int Acc = 0;

        //Разделитель целой и дробной частей
        const string delim = ".";

        //Ноль
        const string zero = "0";

        //Добавить цифру.
        public string AddDigit(int n, int p)
        {
            if (n >= 0 && n < 10)
            {
                number = number.Remove(number.Length - 1);
                number += n;
            }
            switch (n)
            {
                case 10:
                    number = number.Remove(number.Length - 1);
                    number = number.Remove(number.Length - 1);
                    number += 'A';
                    break;
                case 11:
                    number = number.Remove(number.Length - 1);
                    number = number.Remove(number.Length - 1);
                    number += 'B';
                    break;
                case 12:
                    number = number.Remove(number.Length - 1);
                    number = number.Remove(number.Length - 1);
                    number += 'C';
                    break;
                case 13:
                    number = number.Remove(number.Length - 1);
                    number = number.Remove(number.Length - 1);
                    number += 'D';
                    break;
                case 14:
                    number = number.Remove(number.Length - 1);
                    number = number.Remove(number.Length - 1);
                    number += 'E';
                    break;
                case 15:
                    number = number.Remove(number.Length - 1);
                    number = number.Remove(number.Length - 1);
                    number += 'F';
                    break;
            }
            return number;
        }

        //Добавить ноль.
        public string AddZero()
        {
            number += zero;
            return number;
        }
        //Добавить разделитель.
        public string AddDelim()
        {
            number += delim;
            return number;
        }

        //Удалить символ справа.
        public string Bs()
        {
            if (number.Length > 0)
                number = number.Remove(number.Length - 1);
            if (number.Length == 0)
            {
                number += "0";
            }
            return number;
        }

        //Очистить редактируемое число.
        public string Clear()
        {
            number = string.Empty;
            return number;
        }

        //Выполнить команду редактирования.
        public string DoEdit(int j)
        {
            switch (j)
            {
                case 0:
                    if (number != "0")
                        AddZero();
                    if (number.Contains("."))
                        Acc++;
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    if (number != "0")
                        AddDigit(j, 16);
                    if (number.Contains("."))
                        Acc++;
                    break;

                case 16:
                    if (number.Length > 0 && !number.Contains("."))
                    {
                        AddDelim();
                        Acc = 0;
                    }
                    break;

                case 17:
                    if (number != string.Empty)
                        Bs();
                    if (number.Contains("."))
                        Acc--;
                    break;

                case 18:
                    Clear();
                    Acc = 0;
                    break;

                case 19:
                    break;

                case 20:
                    if (number.Length > 0 && (number != "0"))
                    {
                        if (number[0] != '-')
                            number = "-" + number;
                        else
                        {
                            number = number.Split('-')[1];
                        }
                    }
                    break;
                default:
                    break;
            }
            return number;
        }


    }
}
