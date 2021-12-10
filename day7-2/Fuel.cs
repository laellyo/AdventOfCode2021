using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7_2
{
    internal class Fuel
    {
        public double CurrentPosition { get; private set; }
        public double NumberOfCrabs { get; set; }

        public Fuel(double currentPosition)
        {
            CurrentPosition = currentPosition;
            NumberOfCrabs = 1;
        }

        public double Move(double destination)
        {
            double consumedFuel = 0;
            double currentFuelCost = 1;
            for(int i = 0; i < Math.Abs(CurrentPosition - destination); i++)
            {
                consumedFuel += currentFuelCost;
                currentFuelCost++;
            }
            return consumedFuel * NumberOfCrabs;
        }

    }
}
