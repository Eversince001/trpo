using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TMemory

    {

        //Число, хранящееся в памяти

        TNumber number;

        //Состояние памяти

        public int state;

        //Конструктор

        public TMemory()

        {

            number = new TNumber("0", 10);

            state = 0;

        }

        //Записать

        public void Write(TNumber E)

        {

            number = E.Copy();

            state = 1;

        }

        //Взять

        public TNumber Take()

        {

            TNumber res = number.Copy();

            return res;

        }

        //Добавить

        public void Add(TNumber E)

        {

            if (state == 1)

                number = number.Summ(E);

            else

                Write(E);

        }

        //Очистить

        public void Clear()

        {

            number.number = "0";

            number.PInt = 10;

            state = 0;

        }

        //Читать состояние памяти

        public int State

        {

            get { return this.state; }

        }

        //Читать число

        public TNumber Number

        {

            get { return this.number; }

        }

    }
}
