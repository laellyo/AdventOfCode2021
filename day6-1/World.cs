using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6_1
{
    internal class World
    {
        private readonly object fishesLock = new object();
        public event EventHandler NewDayComingEvent;
        private double numberOfFishes;

        public double CreateLife(int days, List<Fish> initFishes)
        {
            numberOfFishes = initFishes.Count;
            foreach (Fish fish in initFishes)
            {
                fish.FishBornEvent += OnFishBorn;
            }

            for(int i = 0; i < days; i++)
            {
                if (i % 10 == 0)
                {
                    lock (fishesLock)
                    {
                        Console.WriteLine("Starting day #{0} with {1} fishes", i, numberOfFishes);
                    }
                }
                if (NewDayComingEvent != null)
                {
                    NewDayComingEvent(this, new EventArgs());
                }
            }

            lock(fishesLock)
            {
                return numberOfFishes;
            }
        }

        private void OnFishBorn(object? sender, Fish e)
        {
            lock(fishesLock)
            {
                numberOfFishes++;
                e.FishBornEvent += OnFishBorn;
            }
        }
    }
}
