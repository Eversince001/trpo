using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    public struct Record
    {
        int p1;
        int p2;
        string number1;
        string number2;
        public Record(int p1, int p2, string n1, string n2)
        {
            this.p1 = p1;
            this.p2 = p2;
            number1 = n1;
            number2 = n2;
        }
        public override string ToString()
        {
            return number1 + " (" + p1 + ") -> " + number2 + " (" + p2 + ")" + Environment.NewLine;
        }
    }

    class History
    {
        List<Record> L;
        public Record this[int i]
        {
            get
            {
                return L.ElementAt(i);
            }
        }

        public void AddRecord(int p1, int p2, string n1, string n2)
        {
            Record tmp = new Record(p1, p2, n1, n2);
            L.Add(tmp);
        }
        public void Clear()
        {
            L.Clear();
        }
        public int Count()
        {
            return L.Count();
        }
        public History()
        {
            L = new List<Record>();
        }
    }
}
