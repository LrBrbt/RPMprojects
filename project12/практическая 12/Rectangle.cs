using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace практическая_12
{
    class Rectangle
    {
        private int _length;
        private int _width;

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public Rectangle(int length, int width)
        {
                _length = length;
                _width = width;
        }

        public int Perimeter(int length, int width)
        {
            return 2 * (length + width);
        }
        public int Area(int length, int width)
        {
            return length * width;
        }
    }
}
