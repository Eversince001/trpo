using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TComplexMemory

    {

        //Число, хранящееся в памяти

        TComplexNumber number;

        //Состояние памяти

        public int state;

        //Конструктор

        public TComplexMemory()

        {

            number = new TComplexNumber("0", "0", 10);

            state = 0;

        }

        //Записать

        public void Write(TComplexNumber E)

        {

            number = E.Copy();

            state = 1;

        }

        //Взять

        public TComplexNumber Take()

        {

            TComplexNumber res = number.Copy();

            return res;

        }

        //Добавить

        public void Add(TComplexNumber E)

        {

            if (state == 1)

                number = number.Summ(E);

            else

                Write(E);

        }

        //Очистить

        public void Clear()

        {

            number.NumberDouble = 0;

            number.PInt = 10;

            state = 0;

        }

        //Читать состояние памяти

        public int State

        {

            get { return this.state; }

        }

        //Читать число

        public TComplexNumber Number

        {

            get { return this.number; }

        }

    }
}
