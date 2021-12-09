using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5_1
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
            // We only support vertical or horizontal line for this exercice
            if (X1 != X2 && Y1 != Y2)
                return;

            // We calculate and store all point coordinates of the line
            if(Y1 != Y2)
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
            else
            {
                List<int> availableX = new List<int>();
                int startX = X1 < X2 ? X1 : X2;
                int endX = X1 < X2 ? X2 : X1;
                for (int i = startX; i <= endX; i++)
                {
                    availableX.Add(i);
                }
                availablePoints.Add(Y1, availableX);
            }
        }

        private void OnCheckDangerOnCoordinateEvent(object? sender, CheckDangerOnCoordinateArgs e)
        {
            if(X1 == X2)
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
            else if(Y1 == Y2)
            {
                List<int> availableX = new List<int>();
                if (availablePoints.TryGetValue(e.Y, out availableX))
                {
                    if (availableX.Contains(e.X))
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
}
