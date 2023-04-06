using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project7
{
    class Money : Pair
    {
        private int _rubles;
        private int _kopecks;

        public int Rubles
        {
            get { return _rubles; }
            set { _rubles = value; }
        }

        public int Kopecks
        {
            get { return _kopecks; }
            set { _kopecks = value; }
        }

        public Money(int rubles, int kopecks) : base(rubles, kopecks)
        {
            Rubles = rubles;
            Kopecks = kopecks;
        }

        public override Pair Addition(Pair value)
        {
            Pair helpPair = new Pair(First + value.First, Second + value.Second);

            if (helpPair.Second > 100)
            {
                return new Money((First + value.First) + 1, (Second + value.Second) - 100);
            }
            else if (helpPair.Second == 100)
            {
                return new Money((First + value.First) + 1, 0);
            }
            else
            {
                return new Money(First + value.First, Second + value.Second);
            }

        }

        public Money Subtraction(Money value)
        {
            Money help = new Money(Rubles - value.Rubles, Kopecks - value.Kopecks);

            if (help.Kopecks < 0)
            {
                return new Money((Rubles - value.Rubles) - 1, (Kopecks - value.Kopecks) + 100);
            }
            else
            {
                return new Money(Rubles - value.Rubles, Kopecks - value.Kopecks);
            }
        }

        public Money Division(Money value)
        {
            if (Rubles > value.Rubles && Kopecks > value.Kopecks)
            {
                return new Money(Rubles / value.Rubles, Kopecks / value.Kopecks);
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }
}
