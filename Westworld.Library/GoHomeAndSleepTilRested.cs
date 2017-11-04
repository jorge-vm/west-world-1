using System;

namespace Westworld.Library
{
    /// <summary>
    /// Miner will go home and sleep until his fatigue is decreased sufficiently
    /// </summary>
    /// <remarks></remarks>
    public class GoHomeAndSleepTilRested : State
    {
        private GoHomeAndSleepTilRested()
        {
            Color = ConsoleColor.Blue;
        }

        static GoHomeAndSleepTilRested()
        {
            Instance = new GoHomeAndSleepTilRested();
        }

        public static GoHomeAndSleepTilRested Instance { get; }

        public override void Enter(Miner miner)
        {
            if (miner.Location == LocationType.Shack) return;
            Console.ForegroundColor = Color;

            Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
            
            Console.WriteLine("Walkin' home");

            miner.Location = LocationType.Shack;
        }

        public override void Execute(Miner miner)
        {
            //if miner is not fatigued start to dig for nuggets again.
            if (!miner.Fatigued()) {
                Console.ForegroundColor = Color;
                Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
                
                Console.WriteLine("What a God darn fantastic nap! Time to find more gold");

                miner.ChangeState(EnterMineAndDigForNugget.Instance);

            } else {
                //sleep
                miner.DecreaseFatigue();

                Console.ForegroundColor = Color;
                Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
                
                Console.WriteLine("ZZZZ... ");

            }
        }


        public override void Exit(Miner miner)
        {
            Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
            
            Console.WriteLine("Leaving the house");

        }
    }
}
