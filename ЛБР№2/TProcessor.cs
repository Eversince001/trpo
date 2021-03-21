using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TProcessor<T> where T : TPNumber

    {

        public T Lop_Res, Rop;

        public enum OperationState { none, add, sub, mult, div, rev, sqr }

        public OperationState State;

        public TProcessor(int p)

        {

            Lop_Res = (T)new TPNumber(0, p, 1);

            Rop = (T)new TPNumber(0, p, 1);

            Lop_Res.c = 0;

            Lop_Res.p = p;

            Lop_Res.number = "";

            Rop.c = 0;

            Rop.p = p;

            Rop.number = "";

        }

        public void reset()

        {

            Lop_Res.c = 0;

            Lop_Res.p = 10;

            Lop_Res.number = "0";

            Rop.c = 0;

            Rop.p = 10;

            Rop.number = "0";

            State = OperationState.none;

        }

        public void OpReset()

        {

            State = OperationState.none;

        }

        public void doOp()

        {

            if (State == OperationState.none)

                return;

            if (State == OperationState.add)

                if (Rop.number == "")

                    Lop_Res = (T)Lop_Res.add(Lop_Res);

                else

                    Lop_Res = (T)Lop_Res.add(Rop);

            if (State == OperationState.sub)

                if (Rop.number == "")

                    Lop_Res = (T)Lop_Res.sub(Lop_Res);

                else

                    Lop_Res = (T)Lop_Res.sub(Rop);

            if (State == OperationState.mult)

                if (Rop.number == "")

                    Lop_Res = (T)Lop_Res.mult(Lop_Res);

                else

                    Lop_Res = (T)Lop_Res.mult(Rop);

            if (State == OperationState.div)

                if (Rop.number == "")

                    Lop_Res = (T)Lop_Res.del(Lop_Res);

                else

                    Lop_Res = (T)Lop_Res.del(Rop);

            setRop((T)new TPNumber("", Rop.p.ToString(), Rop.c.ToString()));

           // State = OperationState.none;

        }

        public void doFunc(bool right)

        {

            if (State == OperationState.none)

                return;

            if (right)

            {

                if (State == OperationState.rev)

                    Rop = (T)Rop.rev();

                if (State == OperationState.sqr)

                    Rop = (T)Rop.sqr();

            }

            else

            {

                if (State == OperationState.rev)

                    Lop_Res = (T)Lop_Res.rev();

                if (State == OperationState.sqr)

                    Lop_Res = (T)Lop_Res.sqr();

            }

        }

        public T getLop()

        {

            return Lop_Res;

        }

        public void setLop(T Lop)

        {

            Lop_Res = (T)new TPNumber(Lop.number, Lop.p.ToString(), Lop.c.ToString());

        }

        public T getRop()

        {

            return Rop;

        }

        public void setRop(T Rop)

        {

            this.Rop = (T)new TPNumber(Rop.number, Rop.p.ToString(), Rop.c.ToString());

        }

        public OperationState getState()

        {

            return State;

        }

        public void setState(OperationState st)

        {

            State = st;

        }

    }
}
