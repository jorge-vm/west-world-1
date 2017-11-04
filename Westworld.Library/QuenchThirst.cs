using System;

namespace Westworld.Library
{
    public class QuenchThirst : State
    {
        private QuenchThirst()
        {
            Color = ConsoleColor.Yellow;
        }

        static QuenchThirst()
        {
            Instance = new QuenchThirst();
        }

        public static QuenchThirst Instance { get; }

        public override void Enter(Miner miner)
        {
            if (miner.Location != LocationType.Saloon) {
                miner.Location = LocationType.Saloon;

                Console.ForegroundColor = Color;
                Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
                
                Console.WriteLine("Boy, ah sure is thusty! Walking to the saloon");

            }
        }

        public override void Execute(Miner miner)
        {
            if (miner.Thirsty()) {
                miner.BuyAndDrinkAWhiskey();

                Console.ForegroundColor = Color;
                Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
                
                Console.WriteLine("That's mighty fine sippin liquer");

                miner.ChangeState(EnterMineAndDigForNugget.Instance);

            } else {
                Console.ForegroundColor = Color;
                Console.WriteLine("ERROR!" + "ERROR!" + "ERROR!");

            }
        }

        public override void Exit(Miner miner)
        {
            Console.ForegroundColor = Color;

            Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
            
            Console.WriteLine("Leaving the saloon, feelin' good");

        }
    }
}