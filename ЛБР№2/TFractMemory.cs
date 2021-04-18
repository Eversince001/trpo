using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TFractMemory

    {

        //Число, хранящееся в памяти

        TFractNumber number;

        //Состояние памяти

        public int state;

        //Конструктор

        public TFractMemory()

        {

            number = new TFractNumber("0", "1", 10);

            state = 0;

        }

        //Записать

        public void Write(TFractNumber E)

        {

            number = E.Copy();

            state = 1;

        }

        //Взять

        public TFractNumber Take()

        {

            TFractNumber res = number.Copy();

            return res;

        }

        //Добавить

        public void Add(TFractNumber E)

        {

            if (state == 1)

                number = number.Summ(E);

            else

                Write(E);

        }

        //Очистить

        public void Clear()

        {

            number.number.numer = "0";

            number.PInt = 10;

            state = 0;

        }

        //Читать состояние памяти

        public int State

        {

            get { return this.state; }

        }

        //Читать число

        public TFractNumber Number

        {

            get { return this.number; }

        }

    }
}
