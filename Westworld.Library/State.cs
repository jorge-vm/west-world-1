using System;

namespace Westworld.Library
{
    /// <summary>
    /// Abstract base class to define an interface for a state
    /// </summary>
    /// <remarks></remarks>
    public abstract class State
    {

        public ConsoleColor Color { get; set; }

        public virtual void Dispose()
        {
        }

        /// <summary>
        /// This will execute when the state is entered
        /// </summary>
        /// <param name="p"></param>
        /// <remarks></remarks>
        public abstract void Enter(Miner p);

        /// <summary>
        /// This is the state's normal update function
        /// </summary>
        /// <param name="p"></param>
        /// <remarks></remarks>
        public abstract void Execute(Miner p);

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="p"></param>
        /// <remarks></remarks>
        public abstract void Exit(Miner p);

    }
}

