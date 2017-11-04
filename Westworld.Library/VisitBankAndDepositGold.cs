using System;

namespace Westworld.Library
{
    /// <summary>
    /// Entity will go to a bank and deposit any nuggets he is carrying. If the
    ///  miner is subsequently wealthy enough he'll walk home, otherwise he'll
    /// keep going to get more gold
    /// </summary>
    /// <remarks></remarks>
    public class VisitBankAndDepositGold : State
    {
        private VisitBankAndDepositGold()
        {
            Color = ConsoleColor.Green;
        }

        static VisitBankAndDepositGold()
        {
            Instance = new VisitBankAndDepositGold();
        }

        public static VisitBankAndDepositGold Instance { get; }

        public override void Enter(Miner miner)
        {
            //on entry the miner makes sure he is located at the bank

            if (miner.Location == LocationType.Bank) return;

            Console.ForegroundColor = Color;
            Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
            
            Console.WriteLine("Goin' to the bank. Yes siree");
            miner.Location = LocationType.Bank;
        }


        public override void Execute(Miner miner)
        {
            //deposit the gold
            miner.Wealth += miner.GoldCarried;
            miner.GoldCarried = 0;

            Console.ForegroundColor = Color;
            Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
            
            Console.WriteLine("Depositing gold. Total savings now: ");
            Console.WriteLine(miner.Wealth);

            //wealthy enough to have a well earned rest?
            if (miner.Wealth >= Common.ComfortLevel) {
                Console.ForegroundColor = Color;

                Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
                
                Console.WriteLine("WooHoo! Rich enough for now. Back home to mah li'lle lady");

                miner.ChangeState(GoHomeAndSleepTilRested.Instance);

                //otherwise get more gold
            } else {
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner miner)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(EntityNames.GetNameOfEntity(miner.UniqueId));
            
            Console.WriteLine("Leavin' the bank");

        }
    }
}