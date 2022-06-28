namespace RocketLandingSystem
{
    /// <summary>
    /// Stores positions defined by the X and Y coordinates in the 2D space
    /// </summary>
    public class Position
    {
        /// <summary>
        /// X coordinate of the 2D space
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of the 2D space
        /// </summary>
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
