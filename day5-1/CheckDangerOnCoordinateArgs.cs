using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5_1
{
    internal class CheckDangerOnCoordinateArgs
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CheckDangerOnCoordinateArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
