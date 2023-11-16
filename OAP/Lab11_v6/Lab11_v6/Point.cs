using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_v6
{
    internal class Point
    {
        int x { get; set; }
        int y { get; set; }

        public void sdvig(int _x, int _y)
        {
            x = x + _x;
            y = y + _y;

        }
    }
}
