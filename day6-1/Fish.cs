using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6_1
{
    internal class Fish
    {
        private readonly object timerLock = new object();
        private World World { get; set; }
        public int ReproductionTimer { get; set; }

        public event EventHandler<Fish> FishBornEvent;

        public Fish(World world, int initTimer = 8)
        {
            ReproductionTimer = initTimer;
            World = world;
            World.NewDayComingEvent += OnNewDayComing;
        }



        private void OnNewDayComing(object? sender, EventArgs e)
        {
            lock(timerLock)
            {
                if(ReproductionTimer > 0)
                {
                    ReproductionTimer--;
                }
                else
                {
                    ReproductionTimer = 6;
                    if (FishBornEvent != null)
                    {
                        FishBornEvent(this, new Fish(World));
                    }
                }
            }
        }
    }
}
