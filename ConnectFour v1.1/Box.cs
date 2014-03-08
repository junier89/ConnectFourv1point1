using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_v1._1
{
    class Box
    {
        public int X { get; set; }
        public int Width { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Turn { get; set; }
        public int Column { get; set; }

        public Box()
        {
            X = 33;
            Width = 50;
            Y = 25;
            var height = 2;
            Height = height;
            Turn = 2;
            Column = 0;
        }
        public Box(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }
}
