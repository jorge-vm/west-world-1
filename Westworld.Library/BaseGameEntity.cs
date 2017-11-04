namespace Westworld.Library
{
    /// <summary>
    ///     Base class for a game object
    /// </summary>
    /// <remarks></remarks>
    public abstract class BaseGameEntity
    {
        /// <summary>
        ///     make sure the val is equal to or greater than the next available ID
        /// </summary>
        private int _uniqueId;

        protected BaseGameEntity(int id)
        {
            _uniqueId = id;
        }

        /// <summary>
        ///     This is the next valid ID. Each time a BaseGameEntity is instantiated
        ///     this value is updated
        /// </summary>
        public static int NextId { get; private set; }


        /// <summary>
        ///     This must be called within each constructor to make sure the ID is set
        ///     correctly. It verifies that the value passed to the method is greater
        ///     or equal to the next valid ID, before setting the ID and incrementing
        ///     the next valid ID
        /// </summary>
        public int UniqueId
        {
            get { return _uniqueId; }
            set
            {
                _uniqueId = value;
                NextId = _uniqueId + 1;
            }
        }

        /// <summary>
        ///     All entities must implement an update function
        /// </summary>
        /// <remarks></remarks>
        public abstract void Update();
    }
}