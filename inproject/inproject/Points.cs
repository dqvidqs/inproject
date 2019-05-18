using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class Points
    {
        private string _x_title;
        private string _y_title;
        private const int _default_quantity = 1000;
        private int Index = 0;
        public Coordinate[] Coo;
        public struct Coordinate
        {
            public int X;
            public int Y;
            public int Gruop;
        }
        public Points() { }
        public Points(string TitleX, string TitleY, int Quantity)
        {
            _x_title = TitleX;
            _y_title = TitleY;
            Coo = new Coordinate[Quantity];
        }
        public Points(string TitleX, string TitleY)
        {
            _x_title = TitleX;
            _y_title = TitleY;
            Coo = new Coordinate[_default_quantity];
        }
    }
}
