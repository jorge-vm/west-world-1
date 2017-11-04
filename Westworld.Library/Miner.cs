namespace Westworld.Library
{
    /// <summary>
    ///     A class defining a gold miner.
    /// </summary>
    /// <remarks></remarks>
    public class Miner : BaseGameEntity
    {
        private State _currentState;

        /// <summary>
        ///     The higher the value, the more tired the miner
        /// </summary>
        /// <remarks></remarks>
        private int _fatigue;

        /// <summary>
        ///     The higher the value, the thirstier the miner
        /// </summary>
        private int _thirst;

        public Miner(int uniqueId) : base(uniqueId)
        {
            Location = LocationType.Shack;
            GoldCarried = 0;
            Wealth = 0;
            _thirst = 0;
            _fatigue = 0;
            _currentState = GoHomeAndSleepTilRested.Instance;
        }

        public int Wealth { get; set; }

        public int GoldCarried { get; set; }

        public LocationType Location { get; set; }

        /// <summary>
        ///     how many nuggets the miner has in his pockets
        /// </summary>
        public bool PocketsFull => GoldCarried >= Common.MaxNuggets;

        /// <summary>
        ///     Base class override
        /// </summary>
        /// <remarks></remarks>
        public override void Update()
        {
            _thirst += 1;
            _currentState?.Execute(this);
        }

        /// <summary>
        ///     This method changes the current state to the new state. It first
        ///     calls the Exit() method of the current state, then assigns the
        ///     new state to m_pCurrentState and finally calls the Entry()
        ///     method of the new state.
        /// </summary>
        /// <param name="p"></param>
        public void ChangeState(State p)
        {
            //make sure both states are both valid before attempting to
            //call their methods

            //call the exit method of the existing state
            _currentState.Exit(this);

            //change state to the new state
            _currentState = p;

            //call the entry method of the new state
            _currentState.Enter(this);
        }

        public bool Fatigued()
        {
            return _fatigue > Common.TirednessThreshold;
        }

        public void DecreaseFatigue()
        {
            _fatigue -= 1;
        }

        public void IncreaseFatigue()
        {
            _fatigue += 1;
        }

        public bool Thirsty()
        {
            return _thirst >= Common.ThirstLevel;
        }

        public void BuyAndDrinkAWhiskey()
        {
            _thirst = 0;
            Wealth -= 2;
        }
    }
}