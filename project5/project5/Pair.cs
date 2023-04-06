using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace project5
{
    class Pair
    {
        private int _first;
        private int _second;
        public Pair(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int First
        {
            get => _first;
            set
            {
                _first = value;
            }
        }
        public int Second
        {
            get => _second;
            set
            {
                _second = value;
            }
        }
        public Pair Addition(Pair value)
        {
            return new Pair(First + value.First, Second + value.Second);
        }

        public Pair Addition(Pair secondPair, Pair thirdPair)
        {
            return new Pair(First + secondPair.First + thirdPair.First, Second + secondPair.Second + thirdPair.Second);
        }

        public Pair IncreaseFields()
        {
            return new Pair(++First, ++Second);
        }


        public override string ToString()
        {
            return $"{First}, {Second}";
        }
    }
}
