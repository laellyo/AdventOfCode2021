using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6_2
{
    internal class FishGeneration
    {
        public double Gen0 { get; set; }
        public double Gen1 { get; set; }
        public double Gen2 { get; set; }
        public double Gen3 { get; set; }
        public double Gen4 { get; set; }
        public double Gen5 { get; set; }
        public double Gen6 { get; set; }
        public double Gen7 { get; set; }
        public double Gen8 { get; set; }

        public double TotalFish
        {
            get
            {
                return Gen0 + Gen1 + Gen2 + Gen3 + Gen4 + Gen5 + Gen6 + Gen7 + Gen8;
            }
        }

        public FishGeneration(int[] initGenerations)
        {
            if(initGenerations == null || initGenerations.Length < 8)
                throw new ArgumentException(nameof(initGenerations));

            Gen0 = initGenerations[0];
            Gen1 = initGenerations[1];
            Gen2 = initGenerations[2];
            Gen3 = initGenerations[3];
            Gen4 = initGenerations[4];
            Gen5 = initGenerations[5];
            Gen6 = initGenerations[6];
            Gen7 = initGenerations[7];
            Gen8 = initGenerations[8];
        }

        public void NewDayComing()
        {
            double newGen6, newGen7, newGen8;

            newGen6 = Gen0 + Gen7;
            newGen7 = Gen8;
            newGen8 = Gen0;
            Gen0 = Gen1;
            Gen1 = Gen2;
            Gen2 = Gen3;
            Gen3 = Gen4;
            Gen4 = Gen5;
            Gen5 = Gen6;
            Gen6 = newGen6;
            Gen7 = newGen7;
            Gen8 = newGen8;
        }

    }
}
