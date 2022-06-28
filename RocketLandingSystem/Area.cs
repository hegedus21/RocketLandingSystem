namespace RocketLandingSystem
{
    /// <summary>
    /// Defines the area of a square shape.
    /// </summary>
    public class Area
    {
        /// <summary>
        /// The top left point of the area
        /// </summary>
        public Position TopLeftCorner { get; set; }

        /// <summary>
        /// The width and length of the square
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topLeftCorner">The position of the top, left corner</param>
        /// <param name="length">The width and length of the area</param>
        /// <exception cref="ArgumentNullException">The top, left corner must be defined</exception>
        public Area(Position topLeftCorner, int length)
        {
            TopLeftCorner = topLeftCorner ?? throw new ArgumentNullException(nameof(topLeftCorner), "Invalid position: Position must not be null!");
            Length = length;
        }
    }
}
