using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5_2
{
    internal class MatchCoordinateArgs
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MatchCoordinateArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
