using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class TPNumber

    {

        public const int MinP = 2;

        public const int MaxP = 16;

        public string number;

        public int p, c;

        public static string zero = "0";

        public TPNumber(double a, int p, int c)

        {

            if (p < MinP || p > MaxP)

                return;

            this.p = p;

            number = Conver_10_p.Do(a, p, c);

            this.c = c;

        }

        public TPNumber(string a, string p, string c)

        {

            if (Convert.ToInt16(p) < Convert.ToInt16(MinP) || Convert.ToInt16(p) > Convert.ToInt16(MaxP))

                return;

            this.p = Convert.ToInt16(p);

            this.c = Convert.ToInt16(c);

            number = a;

        }

        public TPNumber() { }

        public TPNumber copy()

        {

            TPNumber tmp = new TPNumber(this.number, Convert.ToString(this.p), Convert.ToString(this.c));

            return tmp;

        }

        public TPNumber add(TPNumber d)

        {

            TPNumber result = new TPNumber();

            double sum = (Conver_p_10.dval(Convert.ToString(d.number), d.p)

            + Conver_p_10.dval(Convert.ToString(this.number), p));

            result.number = Convert.ToString(Conver_10_p.Do(sum, d.p, d.c));

            result.p = d.p;

            result.c = d.c > this.c ? d.c : this.c;

            result.number = deletezero(result.number);

            return result;

        }

        public TPNumber mult(TPNumber d)

        {

            TPNumber result = new TPNumber();

            result.number = Convert.ToString(Conver_10_p.Do(Conver_p_10.dval(Convert.ToString(d.number), d.p)

            * Conver_p_10.dval(Convert.ToString(this.number), p), d.p, d.c));

            result.p = d.p;

            result.c = d.c + this.c;

            result.number = deletezero(result.number);

            return result;

        }

        private string deletezero(string num)
        {
            if (num.Contains("."))
            {
                int i = num.Length - 1;
                if (num[i] == '0')
                {
                    num = num.Remove(i);

                    if (num[i - 1] == '0')
                       num = deletezero(num);
                }
            }

            return num;

        }

        public TPNumber sub(TPNumber d)

        {

            TPNumber result = new TPNumber();

            result.number = Convert.ToString(Conver_10_p.Do(Conver_p_10.dval(Convert.ToString(this.number), p) -

            Conver_p_10.dval(Convert.ToString(d.number), d.p), d.p, d.c));

            result.p = d.p;

            result.c = d.c > this.c ? d.c : this.c;

            result.number = deletezero(result.number);

            return result;

        }

        public TPNumber del(TPNumber d)

        {

            TPNumber result = new TPNumber();

            result.number = Convert.ToString(Conver_10_p.Do(Conver_p_10.dval(Convert.ToString(this.number), p) /

            Conver_p_10.dval(Convert.ToString(d.number), d.p), d.p, d.c));

            result.p = d.p;

            result.c = d.c > this.c ? d.c : this.c;

            result.number = deletezero(result.number);

            return result;

        }

        public TPNumber rev()

        {

            if (c == 0)

                c = 15;

            else

                c = 15;

            TPNumber result = new TPNumber(number, Convert.ToString(p), Convert.ToString(c));

            result.number = Convert.ToString(Conver_10_p.Do(Math.Round(1 / Conver_p_10.dval(number, p), c), p, c));

            result.number = deletezero(result.number);

            return result;

        }

        public TPNumber sqr()

        {

            if (c < 8)

                c = c * 2;

            else

                c = 15;

            TPNumber result = new TPNumber(number, Convert.ToString(p), Convert.ToString(c));

            result.number = Convert.ToString(Conver_10_p.Do(Math.Round(Math.Pow(Conver_p_10.dval(number, p), 2), c), p, c));

            result.number = deletezero(result.number);

            return result;

        }

        public double getPNum()

        {

            return Conver_p_10.dval(number, p);

        }

        public string getPString()

        {

            return number;

        }

        public double getNumberP()

        {

            return p;

        }

        public string getStringP()

        {

            return p.ToString();

        }

        public double getNumberC()

        {

            return c;

        }

        public string getStringC()

        {

            return c.ToString();

        }

        public void setP(int newb)

        {

            p = newb;

        }

        public void setPstring(string bs)

        {

            p = Convert.ToInt16(bs);

        }

        public void setC(int newc)

        {

            c = newc;

        }

        public void setCstring(string newc)

        {

            c = Convert.ToInt16(newc);

        }

    }
}
