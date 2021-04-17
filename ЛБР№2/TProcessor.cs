using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TProcessor

    {

        //Первое и второе число

        private TNumber Lop_Res;

        private TNumber Rop;

        //Операция. 0 - ничего, 1 - "+", 2 - "-", 3 - "*", 4 - "/"

        private int operation;

        //Конструктор

        public TProcessor()

        {

            Lop_Res = new TNumber("0", 10);

            Rop = new TNumber("0", 10);

            operation = 0;

        }

        //Выполнить операцию

        public void ExeuteOperation()
        {
            switch (operation)
            {

                case 1: Lop_Res = Lop_Res.Summ(Rop); break;

                case 2: Lop_Res = Lop_Res.Sub(Rop); break;

                case 3: Lop_Res = Lop_Res.Mult(Rop); break;

                case 4: Lop_Res = Lop_Res.Div(Rop); break;

                default: break;

            }

        }

        //вычислить функцию

        public void CalculateFunction(int n)

        {

            switch (n)

            {

                // Обратная функция

                case 30: Lop_Res = Lop_Res.Pay(); break;

                case 32: Rop = Rop.Pay(); break;

                // Функция корень

                case 31: Lop_Res = Lop_Res.Sqr(); break;

                case 33: Rop = Rop.Sqr(); break;

            }

        }

        //Записать и вернуть первое число

        public TNumber LeftOp

        {

            set { this.Lop_Res = value; }

            get { return this.Lop_Res; }

        }

        //Записать и вернуть второе число

        public TNumber RightOp

        {

            set { this.Rop = value; }

            get { return this.Rop; }

        }

        //Сброс операции

        public void ResetOper()

        {

            operation = 0;

        }

        //Сброс процессора

        public void ResetProc()

        {

            Lop_Res.number = "0";

            Lop_Res.PInt = 10;

            Rop.number = "0";

            Rop.PInt = 10;

            ResetOper();

        }

        //Изменение состояния

        public int Operation

        {

            set { this.operation = value; }

            get { return this.operation; }

        }

    }

    class TComplexProcessor

    {

        //Первое и второе число

        private TComplexNumber Lop_Res;

        private TComplexNumber Rop;

        //Операция. 0 - ничего, 1 - "+", 2 - "-", 3 - "*", 4 - "/"

        private int operation;

        //Конструктор

        public TComplexProcessor()

        {

            Lop_Res = new TComplexNumber(0, 0, 10);

            Rop = new TComplexNumber(0, 0, 10);

            operation = 0;

        }

        //Выполнить операцию

        public void ExeuteOperation()

        {

            switch (operation)

            {

                case 1: Lop_Res = Lop_Res.Summ(Rop); break;

                case 2: Lop_Res = Lop_Res.Sub(Rop); break;

                case 3: Lop_Res = Lop_Res.Mult(Rop); break;

                case 4: Lop_Res = Lop_Res.Div(Rop); break;

                default: break;

            }

        }

        //вычислить функцию

        public void CalculateFunction(int n)

        {

            switch (n)

            {

                // Обратная функция

                case 30: Lop_Res = Lop_Res.Pay(); break;

                // Функция корень

                case 31: Lop_Res = Lop_Res.Sqr(); break;

                case 32: Rop = Rop.Pay(); break;

                case 33: Rop = Rop.Sqr(); break;

            }

        }

        //Записать и вернуть первое число

        public TComplexNumber LeftOp

        {

            set { this.Lop_Res = value; }

            get { return this.Lop_Res; }

        }

        //Записать и вернуть второе число

        public TComplexNumber RightOp

        {

            set { this.Rop = value; }

            get { return this.Rop; }

        }

        //Сброс операции

        public void ResetOper()

        {

            operation = 0;

        }

        //Сброс процессора

        public void ResetProc()

        {

            Lop_Res.NumberDouble = 0;

            Lop_Res.PInt = 10;

            Rop.NumberDouble = 0;

            Rop.PInt = 10;

            ResetOper();

        }

        //Изменение состояния

        public int Operation

        {

            set { this.operation = value; }

            get { return this.operation; }

        }

    }

    class TFractProcessor

    {

        //Первое и второе число

        private TFractNumber Lop_Res;

        private TFractNumber Rop;

        //Операция. 0 - ничего, 1 - "+", 2 - "-", 3 - "*", 4 - "/"

        private int operation;

        //Конструктор

        public TFractProcessor()

        {

            Lop_Res = new TFractNumber(0, 1, 10);

            Rop = new TFractNumber(0, 1, 10);

            operation = 0;

        }

        //Выполнить операцию

        public void ExeuteOperation()

        {

            switch (operation)

            {

                case 1: Lop_Res = Lop_Res.Summ(Rop); break;

                case 2: Lop_Res = Lop_Res.Sub(Rop); break;

                case 3: Lop_Res = Lop_Res.Mult(Rop); break;

                case 4: Lop_Res = Lop_Res.Div(Rop); break;

                default: break;

            }

        }

        //вычислить функцию

        public void CalculateFunction(int n)

        {

            switch (n)

            {

                // Обратная функция

                case 30: Lop_Res = Lop_Res.Pay(); break;

                // Функция корень

                case 31: Lop_Res = Lop_Res.Sqr(); break;

                case 32: Rop = Rop.Pay(); break;

                case 33: Rop = Rop.Sqr(); break;

            }

        }

        //Записать и вернуть первое число

        public TFractNumber LeftOp

        {

            set { this.Lop_Res = value; }

            get { return this.Lop_Res; }

        }

        //Записать и вернуть второе число

        public TFractNumber RightOp

        {

            set { this.Rop = value; }

            get { return this.Rop; }

        }

        //Сброс операции

        public void ResetOper()

        {

            operation = 0;

        }

        //Сброс процессора

        public void ResetProc()

        {

            Lop_Res.NumberDouble = 0;

            Lop_Res.PInt = 10;

            Rop.NumberDouble = 0;

            Rop.PInt = 10;

            ResetOper();

        }

        //Изменение состояния

        public int Operation

        {

            set { this.operation = value; }

            get { return this.operation; }

        }

    }
}
