using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class Memory<T> where T : TPNumber

    {

        T FNumber = (T)new TPNumber(0, 10, 1);

        public enum FState { _off, _on };

        public FState FS { set; get; }

        public Memory()
        {

            FS = FState._off;

        }

        public void store(T num)
        {
            FNumber = (T)new TPNumber(num.number, num.p.ToString(), num.c.ToString());
            FS = FState._on;

        }

        public T get()
        {
            T tmp;
            tmp = FNumber;
            return tmp;
        }

        public void add(T e)

        {

            if (FS == FState._off)

                FNumber = (T)new TPNumber(e.number, e.p.ToString(), e.c.ToString());

            else

                FNumber = (T)e.add(FNumber);

        }

        public void clear()

        {

            FS = FState._off;

        }

        public FState getFS()

        {

            return FS;

        }

        public T getFNumber()

        {

            T n = (T)new TPNumber(FNumber.number, FNumber.p.ToString(), FNumber.c.ToString());

            return n;

        }

    }
}
