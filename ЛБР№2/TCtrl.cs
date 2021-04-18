using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TCtrl
    {

        public TEditor editor; //Класс Редактор

        public TFractEditor Feditor; //Класс Редактор

        public TComplexEditor Ceditor; //Класс Редактор

        public TProcessor processor; //Класс Процессор

        public TFractProcessor Fprocessor; //Класс Процессор

        public TComplexProcessor Cprocessor; //Класс Процессор

        public TMemory memory; //Класс память

        public TFractMemory Fmemory; //Класс память

        public TComplexMemory Cmemory; //Класс память

        public THistory history; //Класс история

        public int TypeCalculator;//Тип калькулятора

        //Конструктор

        public TCtrl()

        {

            editor = new TEditor();

            Feditor = new TFractEditor();

            Ceditor = new TComplexEditor();

            history = new THistory();

            memory = new TMemory();

            Fmemory = new TFractMemory();

            Cmemory = new TComplexMemory();

            processor = new TProcessor();

            Fprocessor = new TFractProcessor();

            Cprocessor = new TComplexProcessor();

        }

        /*Выполнить команду*/

        public string DoCommand(int n)
        {

            string str = "";

            TNumber buf = new TNumber("0", 10);

            if (n >= 0 && n <= 15)

            {

                str = editor.AddSymbol(n);

                switch (editor.State)
                {
                    case 3: editor.State = 0; break;
                    case 2: editor.State = 1; break;
                }

            }

            switch (n)

            {

                case 16: str = editor.AddDot(TypeCalculator); break;

                case 17: str = editor.AddAndChangeSign(); break;

                case 18: str = editor.Clear(); editor.State = 0; processor.ResetOper(); break;

                case 20: str = "0"; editor.Clear(); editor.State = 0; break;

                /*Работа с памятью*/

                case 21: str = editor.number; memory.Clear(); editor.Clear(); /*Очистить память*/ break;

                case 22: str = TakeOutTheMemory(); /*Копировать из памяти*/ break;

                case 23: str = editor.number; buf.number = str; buf.PInt = processor.LeftOp.PInt; memory.Write(buf); /*Сохранить в память*/ break;

                case 24: str = editor.number; buf.number= str; buf.PInt = processor.LeftOp.PInt; memory.Add(buf); /*Добавить к содержимому памяти*/ break;

                /*Подготовка к выполнению операций*/

                case 25:

                case 26:

                case 27:

                case 28:

                    if (processor.Operation != n - 24 && editor.State == 1)

                        str = ExecOperation(editor.number);

                    str = Preparation(editor.number, n);

                    break;

                /*Выполнение функций*/


                case 31: str = ExecFunc(editor.number, n); break;

                case 32: str = ExecFunc(editor.number, n); break;

                /*Выполнение операций*/

                case 40: str = ExecOperation(editor.number); break;

            }

            return str;

        }

        public string DoCommandFract(int n)

        {

            string str = "";

            TFractNumber buf = new TFractNumber("0", "1", 10);

            if (n >= 0 && n <= 15)

            {

                str = Feditor.AddSymbol(n);

                switch (Feditor.State)

                {

                    case 3: Feditor.State = 0; break;

                    case 2: Feditor.State = 1; break;

                }

            }

            switch (n)

            {

                case 16: str = Feditor.AddDot(TypeCalculator); break;

                case 17: str = Feditor.AddAndChangeSign(); break;

                case 18: str = Feditor.Clear(); Feditor.State = 0; processor.ResetOper(); break;

                case 20: str = "0"; Feditor.Clear(); Feditor.State = 0; break;

                /*Работа с памятью*/

                case 21: str = Feditor.number; memory.Clear(); Feditor.Clear(); /*Очистить память*/ break;

                case 22: str = TakeOutTheMemory(); /*Копировать из памяти*/ break;

                case 23: str = Feditor.number; buf.NumberString = str; buf.PInt = Fprocessor.LeftOp.PInt; Fmemory.Write(buf); /*Сохранить в память*/ break;

                case 24: str = Feditor.number; buf.NumberString = str; buf.PInt = Fprocessor.LeftOp.PInt; Fmemory.Add(buf); /*Добавить к содержимому памяти*/ break;

                /*Подготовка к выполнению операций*/

                case 25:

                case 26:

                case 27:

                case 28:

                    if (processor.Operation != n - 24 && Feditor.State == 1)

                        str = FExecOperation(Feditor.number);

                    str = FPreparation(Feditor.number, n);

                    break;

                /*Выполнение функций*/

                case 30:

                case 31: str = FExecFunc(Feditor.number, n); break;

                case 32: str = FExecFunc(Feditor.number, n); break;

                /*Выполнение операций*/

                case 40: str = FExecOperation(Feditor.number); break;

                case 99: str = Feditor.Numer(); break;

                case 98: str = Feditor.Denom(); break;

            }

            if (n == 19)

                str = Feditor.RemoveLastSymbol();

            return str;

        }

        public string DoCommandComplex(int n)

        {

            string str = "";

            TComplexNumber buf = new TComplexNumber(0, 0, 10);

            if (n >= 0 && n <= 15)

            {

                str = Ceditor.AddSymbol(n);

                switch (Ceditor.State)

                {

                    case 3: Ceditor.State = 0; break;

                    case 2: Ceditor.State = 1; break;

                }

            }

            switch (n)

            {

                case 16: str = Ceditor.AddDot(TypeCalculator); break;

                case 17: str = Ceditor.AddAndChangeSign(); break;

                case 18: str = Ceditor.Clear(); Ceditor.State = 0; processor.ResetOper(); break;

                case 20: str = "0+0i"; Ceditor.Clear(); Ceditor.State = 0; break;

                /*Работа с памятью*/

                case 21: str = Ceditor.number; Cmemory.Clear(); Ceditor.Clear(); /*Очистить память*/ break;

                case 22: str = TakeOutTheMemory(); /*Копировать из памяти*/ break;

                case 23: str = Ceditor.number; buf.NumberString = str; buf.PInt = processor.LeftOp.PInt; Cmemory.Write(buf); /*Сохранить в память*/ break;

                case 24: str = Ceditor.number; buf.NumberString = str; buf.PInt = processor.LeftOp.PInt; Cmemory.Add(buf); /*Добавить к содержимому памяти*/ break;

                /*Подготовка к выполнению операций*/

                case 25:

                case 26:

                case 27:

                case 28:

                    if (processor.Operation != n - 24 && Ceditor.State == 1)

                        str = ExecOperation(Ceditor.number);

                    str = CPreparation(Ceditor.number, n);

                    break;

                /*Выполнение функций*/

                case 30:

                case 31: str = CExecFunc(Ceditor.number, n); break;

                /*Выполнение операций*/

                case 40: str = CExecOperation(Ceditor.number); break;

                case 99: str = Ceditor.Re(); break;

                case 98: str = Ceditor.Im(); break;

            }

            if (n == 19)

                str = Ceditor.RemoveLastSymbol();

            return str;

        }

        //Взять из памяти

        public string TakeOutTheMemory()

        {

            string res = "";

            if (processor.Operation == 0)

            {

                processor.LeftOp = memory.Number;

                //res = processor.LeftOp.NumberString;

                res = processor.LeftOp.getNumber();

                editor.number = res;

            }

            else

            {

                processor.RightOp = memory.Number;

                //res = processor.RightOp.NumberString;

                res = processor.RightOp.getNumber();

                editor.number = res;

            }

            if (editor.State != 0)

                editor.State = 1;

            return res;

        }

        //Выполнить функцию

        public string ExecFunc(string number, int numFunc)
        {

            string res = "";

            string record = "";

            //processor.LeftOp.NumberString = number;

            if (editor.State == 1)

            {

                //processor.RightOp.number = number;

                if (numFunc == 31)

                {

                    record = "Sqr( " + number + " ) = ";

                    processor.CalculateFunction(33);

                }

                else

                {

                    record += "1 / " + number + " = ";

                    processor.CalculateFunction(32);

                }

                res += processor.RightOp.getNumber();

            }

            else

            {

                if (editor.State != 3)

                    processor.LeftOp.number = number;

                if (numFunc == 31)

                {

                    record = "Sqr( " + number + " ) = ";

                    processor.CalculateFunction(31);

                }

                else

                {

                    record += "1 / " + number + " = ";

                    processor.CalculateFunction(30);

                }

                res += processor.LeftOp.getNumber();

            }

            editor.number = res;

            //editor.Clear();

            if (editor.State != 1)

                editor.State = 3;

            record += res;

            history.AddRecord(record);

            //processor.ResetOper();

            return res;

        }

        public string FExecFunc(string number, int numFunc)

        {

            string res = "";

            string record = "";

            //processor.LeftOp.NumberString = number;

            if (Feditor.State == 1)

            {

                Fprocessor.RightOp.NumberString = number;

                if (numFunc == 31)

                {

                    record = "Sqr( " + number + " ) = ";

                    Fprocessor.CalculateFunction(33);

                }

                else

                {

                    record += "1 / " + number + " = ";

                    Fprocessor.CalculateFunction(32);

                }

                res += Fprocessor.RightOp.NumberString;

            }

            else

            {

                if (Feditor.State != 3)

                    Fprocessor.LeftOp.NumberString = number;

                if (numFunc == 31)

                {

                    record = "Sqr( " + number + " ) = ";

                    Fprocessor.CalculateFunction(31);

                }

                else

                {

                    record += "1 / " + number + " = ";

                    Fprocessor.CalculateFunction(30);

                }

                res += Fprocessor.LeftOp.NumberString;

            }

            Feditor.number = res;

            //editor.Clear();

            if (Feditor.State != 1)

                Feditor.State = 3;

            record += res;

            history.AddRecord(record);

            //processor.ResetOper();

            return res;

        }

        public string CExecFunc(string number, int numFunc)

        {

            string res = "";

            string record = "";

            //processor.LeftOp.NumberString = number;

            if (Ceditor.State == 1)

            {

                Cprocessor.RightOp.NumberString = number;

                if (numFunc == 31)

                {

                    record = "Sqr( " + number + " ) = ";

                    Cprocessor.CalculateFunction(33);

                }

                else

                {

                    record += "1 / " + number + " = ";

                    Cprocessor.CalculateFunction(32);

                }

                res += Cprocessor.RightOp.NumberString;

            }

            else

            {

                if (Ceditor.State != 3)

                    Cprocessor.LeftOp.NumberString = number;

                if (numFunc == 31)

                {

                    record = "Sqr( " + number + " ) = ";

                    Cprocessor.CalculateFunction(31);

                }

                else

                {

                    record += "1 / " + number + " = ";

                    Cprocessor.CalculateFunction(30);

                }

                res += Cprocessor.LeftOp.NumberString;

            }

            Ceditor.number = res;

            //editor.Clear();

            if (Ceditor.State != 1)

                Ceditor.State = 3;

            record += res;

            history.AddRecord(record);

            //processor.ResetOper();

            return res;

        }

        //Выполнить операцию

        public string ExecOperation(string number)

        {

            string res = "";

            if (processor.Operation != 0)

            {

                //Convert.ToInt32(number)

                if (processor.Operation == 4 && processor.RightOp.number == "0")/*processor.RightOp.NumberDouble*/

                {

                    editor.State = 0;

                    return "Деление на ноль невозможно!";

                }

                string rec = processor.LeftOp.getNumber();

                switch (editor.State)
                {

                    case 1: if (number != "") processor.RightOp.number = number; else processor.RightOp.number = processor.LeftOp.getNumber(); break;

                    //Для случая 5+=10

                    case 2: processor.RightOp.number = processor.LeftOp.getNumber(); break;

                }

                processor.ExeuteOperation();

                editor.Clear();

                res = processor.LeftOp.getNumber();

                //res = res.Replace(',', '.');

                switch (processor.Operation)

                {

                    case 1: rec += "+"; break;

                    case 2: rec += "-"; break;

                    case 3: rec += "*"; break;

                    case 4: rec += "/"; break;

                }

                rec += processor.RightOp.getNumber();

                rec += " = " + processor.LeftOp.getNumber();

                history.AddRecord(rec);

                editor.number = res;

                editor.State = 3;

            }

            return res;

        }

        public string FExecOperation(string number)

        {

            string res = "";

            if (Fprocessor.Operation != 0)

            {

                //Convert.ToInt32(number)

                if (Fprocessor.Operation == 4 && Fprocessor.RightOp.number.numer == "0")/*processor.RightOp.NumberDouble*/
                {

                    Feditor.State = 0;

                    return "Деление на ноль невозможно!";

                }

                string rec = Fprocessor.LeftOp.NumberString;

                switch (Feditor.State)

                {

                    case 1: if (number != "") Fprocessor.RightOp.NumberString = number; else Fprocessor.RightOp.NumberString = Fprocessor.LeftOp.NumberString; break;

                    //Для случая 5+=10

                    case 2: Fprocessor.RightOp.NumberString = Fprocessor.LeftOp.NumberString; break;

                }

                Fprocessor.ExeuteOperation();

                Feditor.Clear();

                res = Fprocessor.LeftOp.NumberString;

                res = res.Replace(',', '.');

                switch (Fprocessor.Operation)

                {

                    case 1: rec += " + "; break;

                    case 2: rec += " - "; break;

                    case 3: rec += " * "; break;

                    case 4: rec += " / "; break;

                }

                rec += Fprocessor.RightOp.NumberString;

                rec += " = " + Fprocessor.LeftOp.NumberString;

                history.AddRecord(rec);

                Feditor.number = res;

                Feditor.State = 3;

            }

            return res;

        }

        public string CExecOperation(string number)

        {

            string res = "";

            if (Cprocessor.Operation != 0)

            {

                //Convert.ToInt32(number)

                if (Cprocessor.Operation == 4 && number == "0")/*processor.RightOp.NumberDouble*/

                {

                    Ceditor.State = 0;

                    return "Деление на ноль невозможно!";

                }

                string rec = Cprocessor.LeftOp.NumberString;

                switch (Ceditor.State)

                {

                    case 1: if (number != "") Cprocessor.RightOp.NumberString = number; else Cprocessor.RightOp.NumberString = Cprocessor.LeftOp.NumberString; break;

                    //Для случая 5+=10

                    case 2: Cprocessor.RightOp.NumberString = Cprocessor.LeftOp.NumberString; break;

                }

                Cprocessor.ExeuteOperation();

                Ceditor.Clear();

                res = Cprocessor.LeftOp.NumberString;

               // res = res.Replace(',', '.');

                switch (Cprocessor.Operation)

                {

                    case 1: rec += " + "; break;

                    case 2: rec += " - "; break;

                    case 3: rec += " * "; break;

                    case 4: rec += " / "; break;

                }

                rec += Cprocessor.RightOp.NumberString;

                rec += " = " + Cprocessor.LeftOp.NumberString;

                history.AddRecord(rec);

                Ceditor.number = res;

                Ceditor.State = 3;

            }

            return res;

        }

        //Подготовка данных

        public string Preparation(string number, int command)

        {

            string res = "";

            string rec = "";

            if (editor.State != 3)

            {

                if (editor.State == 1)

                {

                    double buf = Convert.ToDouble(processor.LeftOp.getNumber());

                    processor.LeftOp.number = processor.RightOp.getNumber();

                    processor.RightOp.number = buf.ToString();

                    rec += processor.LeftOp.getNumber();

                    switch (processor.Operation)

                    {

                        case 1: rec += " + "; break;

                        case 2: rec += " - "; break;

                        case 3: rec += " * "; break;

                        case 4: rec += " / "; break;

                    }

                    rec += processor.RightOp.getNumber();

                    processor.ExeuteOperation();

                    res = processor.LeftOp.getNumber();

                    editor.State = 2;

                }

                else

                {

                    if (editor.State == 2)

                    {

                        processor.RightOp.number = number;

                        //processor.ExeuteOperation();

                        res = processor.LeftOp.getNumber();

                        editor.State = 1;

                    }

                    else

                    {

                        processor.LeftOp.number = number;

                        res = number;

                        editor.State = 2; // 1 или 2

                    }

                }

            }

            else

            {

                processor.RightOp.number = processor.LeftOp.getNumber();

                res = processor.LeftOp.getNumber();

                //processor.ExeuteOperation();

                //processor.LeftOp.NumberString = number;
                editor.State = 1;
            }

            editor.Clear();

            //processor.ResetOper();

            rec += " = " + res;

            if (rec.Length >= 9)

                history.AddRecord(rec);

            editor.State = 2;

            switch (command)

            {

                case 25: processor.Operation = 1; break;

                case 26: processor.Operation = 2; break;

                case 27: processor.Operation = 3; break;

                case 28: processor.Operation = 4; break;

            }

            return res;

        }

        public string FPreparation(string number, int command)

        {

            string res = "";

            string rec = "";

            if (Feditor.State != 3)

            {

                if (Feditor.State == 1)

                {

                    double buf = Convert.ToDouble(Fprocessor.LeftOp.number.numer);

                    Fprocessor.LeftOp.number.numer = Fprocessor.RightOp.number.numer;

                    Fprocessor.RightOp.number.numer = buf.ToString();

                    rec += Fprocessor.LeftOp.NumberString;

                    switch (Fprocessor.Operation)

                    {

                        case 1: rec += " + "; break;

                        case 2: rec += " - "; break;

                        case 3: rec += " * "; break;

                        case 4: rec += " / "; break;

                    }

                    rec += Fprocessor.RightOp.NumberString;

                    Fprocessor.ExeuteOperation();

                    res = Fprocessor.LeftOp.NumberString;

                    Feditor.State = 2;

                }

                else

                {

                    if (Feditor.State == 2)

                    {

                        Fprocessor.RightOp.NumberString = number;

                        //processor.ExeuteOperation();

                        res = Fprocessor.LeftOp.NumberString;

                        Feditor.State = 1;

                    }

                    else

                    {

                        Fprocessor.LeftOp.NumberString = number;

                        res = number;

                        Feditor.State = 2; // 1 или 2

                    }

                }

            }

            else

            {

                Fprocessor.RightOp.number.numer = Fprocessor.LeftOp.number.numer;

                res = Fprocessor.LeftOp.NumberString;

                //processor.ExeuteOperation();

                //processor.LeftOp.NumberString = number;

                Feditor.State = 1;

            }

            Feditor.Clear();

            //processor.ResetOper();

            rec += " = " + res;

            if (rec.Length >= 9)

                history.AddRecord(rec);

            Feditor.State = 2;

            switch (command)

            {

                case 25: Fprocessor.Operation = 1; break;

                case 26: Fprocessor.Operation = 2; break;

                case 27: Fprocessor.Operation = 3; break;

                case 28: Fprocessor.Operation = 4; break;

            }

            return res;

        }

        public string CPreparation(string number, int command)

        {

            string res = "";

            string rec = "";

            if (Ceditor.State != 3)

            {

                if (Ceditor.State == 1)

                {

                    double buf = Cprocessor.LeftOp.NumberDouble;

                    Cprocessor.LeftOp.NumberDouble = Cprocessor.RightOp.NumberDouble;

                    Cprocessor.RightOp.NumberDouble = buf;

                    rec += Cprocessor.LeftOp.NumberString;

                    switch (Cprocessor.Operation)

                    {

                        case 1: rec += " + "; break;

                        case 2: rec += " - "; break;

                        case 3: rec += " * "; break;

                        case 4: rec += " / "; break;

                    }

                    rec += Cprocessor.RightOp.NumberString;

                    Cprocessor.ExeuteOperation();

                    res = Cprocessor.LeftOp.NumberString;

                    Ceditor.State = 2;

                }

                else

                {

                    if (Ceditor.State == 2)

                    {

                        Cprocessor.RightOp.NumberString = number;

                        //processor.ExeuteOperation();

                        res = Cprocessor.LeftOp.NumberString;

                        Ceditor.State = 1;

                    }

                    else

                    {

                        Cprocessor.LeftOp.NumberString = number;

                        res = number;

                        Ceditor.State = 2; // 1 или 2

                    }

                }

            }

            else

            {

                Cprocessor.RightOp.NumberDouble = Cprocessor.LeftOp.NumberDouble;

                res = Cprocessor.LeftOp.NumberString;

                //processor.ExeuteOperation();

                //processor.LeftOp.NumberString = number;

                Ceditor.State = 1;

            }

            Ceditor.Clear();

            //processor.ResetOper();

            rec += " = " + res;

            if (rec.Length >= 9)

                history.AddRecord(rec);

            Ceditor.State = 2;

            switch (command)

            {

                case 25: Cprocessor.Operation = 1; break;

                case 26: Cprocessor.Operation = 2; break;

                case 27: Cprocessor.Operation = 3; break;

                case 28: Cprocessor.Operation = 4; break;

            }

            return res;

        }

    }
}
