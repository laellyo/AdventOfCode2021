using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5_1
{
    internal class Diagram
    {
        public int SizeX { get; set; }

        public int SizeY { get; set; }

        public event EventHandler<CheckDangerOnCoordinateArgs> CheckDangerOnCoordinateEvent;

        private int[,] dangerMatrix; 

        public Diagram(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            dangerMatrix = new int[sizeX, sizeY];
        }

        public void AnalyzeDiagram(List<Line> lines)
        {
            foreach (Line line in lines)
            {
                line.MatchCoordinateEvent += OnMatchCoordinate;
            }

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    if(CheckDangerOnCoordinateEvent != null)
                    {
                        CheckDangerOnCoordinateEvent(this, new CheckDangerOnCoordinateArgs(x, y));
                    }
                }
            }
        }

        private void OnMatchCoordinate(object? sender, CheckDangerOnCoordinateArgs e)
        {
            dangerMatrix[e.X,e.Y]++;
        }

        public int CalculateDangerousArea()
        {
            int result = 0;
            for(int x = 0;x < SizeX;x++)
            {
                for(int y = 0;y < SizeY;y++)
                {
                    if(dangerMatrix[x,y] >= 2)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
