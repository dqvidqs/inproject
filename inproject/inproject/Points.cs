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
        private const int _default_quantity = 1;
        private int Quantity;
        //private int Index = 0;
        public Coordinate[] Coo;
        public struct Coordinate
        {
            public double X;
            public double Y;
            public string Gruop;
            public double Distance;
        }
        public Points() {
            Coo = new Coordinate[_default_quantity];
            Quantity = _default_quantity;
        }
        public Points(int Quantity)
        {
            Coo = new Coordinate[Quantity];
            this.Quantity = Quantity;
        }
        public Points(string TitleX, string TitleY, int Quantity)
        {
            _x_title = TitleX;
            _y_title = TitleY;
            Coo = new Coordinate[Quantity];
            this.Quantity = Quantity;
        }
        public Points(string TitleX, string TitleY)
        {
            _x_title = TitleX;
            _y_title = TitleY;
            Coo = new Coordinate[_default_quantity];
            Quantity = _default_quantity;
        }
        public int GetQuantity()
        {
            return Quantity;
        }
    }
}
