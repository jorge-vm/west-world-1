using System;

namespace Westworld.Library
{
    /// <summary>
    ///  In this state the miner will walk to a goldmine and pick up a nugget
    ///  of gold. If the miner already has a nugget of gold he'll change state
    ///  to VisitBankAndDepositGold. If he gets thirsty he'll change state
    ///  to QuenchThirst
    /// </summary>
    public class EnterMineAndDigForNugget : State
    {
        private EnterMineAndDigForNugget()
        {
            Color = ConsoleColor.Red;
        }

        static EnterMineAndDigForNugget()
        {
            Instance = new EnterMineAndDigForNugget();
        }

        public static EnterMineAndDigForNugget Instance { get; }

        public override void Enter(Miner miner)
        {
            //if the miner is not already located at the goldmine, he must
            //change location to the gold mine
            if (miner.Location == LocationType.Goldmine) return;
            Console.ForegroundColor = Color;
            Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
            
            Console.WriteLine("Walkin' to the goldmine");

            miner.Location = LocationType.Goldmine;
        }

        public override void Execute(Miner miner)
        {
            //the miner digs for gold until he is carrying in excess of MaxNuggets.
            //If he gets thirsty during his digging he packs up work for a while and
            //changes state to go to the saloon for a whiskey.
            miner.GoldCarried += 1;

            miner.IncreaseFatigue();

            Console.ForegroundColor = Color;
            Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
            
            Console.WriteLine("Pickin' up a nugget");

            //if enough gold mined, go and put it in the bank
            if (miner.PocketsFull) {
                miner.ChangeState(VisitBankAndDepositGold.Instance);
            }

            if (miner.Thirsty()) {
                miner.ChangeState(QuenchThirst.Instance);
            }
        }

        public override void Exit(Miner miner)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
            
            Console.WriteLine("Ah'm leavin' the goldmine with mah pockets full o' sweet gold");
        }

    }
}
