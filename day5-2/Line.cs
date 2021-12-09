using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5_2
{
    internal class Line
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        private Dictionary<int, List<int>> availablePoints;

        public event EventHandler<CheckDangerOnCoordinateArgs> MatchCoordinateEvent;

        public Line(Diagram diagram, int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            availablePoints = new Dictionary<int, List<int>>();
            diagram.CheckDangerOnCoordinateEvent += OnCheckDangerOnCoordinateEvent;

            CalculateLinePoints();
        }

        private void CalculateLinePoints()
        {

            // We calculate and store all point coordinates of the line
            if(X1 == X2 && Y1 != Y2)
            {
                List<int> availableY = new List<int>();
                int startY = Y1 < Y2 ? Y1 : Y2;
                int endY = Y1 < Y2 ? Y2 : Y1;
                for (int i = startY; i <= endY; i++)
                {
                    availableY.Add(i);
                }
                availablePoints.Add(X1, availableY);
            }
            else if(X1 != X2 && Y1 == Y2)
            {
                int startX = X1 < X2 ? X1 : X2;
                int endX = X1 < X2 ? X2 : X1;
                for (int i = startX; i <= endX; i++)
                {
                    availablePoints.Add(i, new List<int>() {Y1});
                }
            }
            else if(Math.Abs(X1 - X2) == Math.Abs(Y1 - Y2))
            {
                int startX = 0;
                int endX = 0;
                int startY = 0;
                int endY = 0;
                if (X1 < X2)
                {
                    startX = X1;
                    endX = X2;
                    startY = Y1;
                    endY = Y2;
                }
                else
                {
                    startX = X2;
                    endX = X1;
                    startY = Y2;
                    endY = Y1;
                }

                // As difference between X1 and X2 is equals to the difference between Y1 and Y2,
                // we just loop on X points, and add +1 or -1 to Y accordingly
                for(int x = startX; x <= endX; x++)
                {
                    availablePoints.Add(x, new List<int>() { startY });
                    if (startY < endY)
                        startY++;
                    else
                        startY--;
                }

            }
        }

        private void OnCheckDangerOnCoordinateEvent(object? sender, CheckDangerOnCoordinateArgs e)
        {
            List<int> availableY = new List<int>();
            if(availablePoints.TryGetValue(e.X, out availableY))
            {
                if(availableY.Contains(e.Y))
                {
                    if (MatchCoordinateEvent != null)
                    {
                        MatchCoordinateEvent(this, new CheckDangerOnCoordinateArgs(e.X, e.Y));
                        return;
                    }
                }
            }
        }
    }
}
