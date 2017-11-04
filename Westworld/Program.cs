using System;
using System.Threading;
using Westworld.Library;

namespace Westworld
{
    public class Program
    {
        public static void Main()
        {
            //create a miner
            var miner = new Miner((int) EntityType.Miner);

            //simply run the miner through a few Update calls
            for (var i = 0; i <= 19; i++) {
                miner.Update();

                Thread.Sleep(5000);
            }

            //wait for a key press before exiting
            Console.Read();

        }
    }
}
