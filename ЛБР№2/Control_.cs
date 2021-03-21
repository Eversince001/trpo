using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class Control_
    {
        //Основание системы сч. исходного числа. 
        const int pin = 10;
        //Основание системы сч. результата. 
        const int pout = 16;
        //Число разрядов в дробной части результата. 
        const int accuracy = 10;

        public History his = new History();

        public enum State { Editing, Converted }

        //Свойство для чтения и записи состояние Конвертера.
        public State St { get; set; }

        //Конструктор.
        public Control_()
        {
            St = State.Editing;

            Pin = pin;
            Pout = pout;
            acc();
        }

        //объект редактор
        public Editor ed = new Editor();

        //Свойство для чтения и записи основание системы сч. р1.
        public int Pin { get; set; }
        //Свойство для чтения и записи основание системы сч. р2.
        public int Pout { get; set; }

        //Выполнить команду конвертера.
        public string DoCmnd(int j, string tmp)
        {

            ed.number = tmp;

            if (j == 19 && ed.number.Length > 0)
            {
                double r = Conver_p_10.dval(ed.number, Pin);
                string res = Conver_10_p.Do(r, Pout, acc());
                St = State.Converted;
                his.AddRecord(Pin, Pout, ed.number, res);
                return res;
            }
            else
            {
                St = State.Editing;
                return ed.DoEdit(j);
            }
        }
        //Точность представления результата.
        private int acc()
        {
            return (int)Math.Round(ed.Acc * Math.Log(Pin) / Math.Log(Pout) + 0.5);
        }
    }

}

