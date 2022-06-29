namespace RocketLandingSystem
{
    public class LandingSystem
    {
        private const string s_Ok = "ok for landing";
        private const string s_OutOfPlatform = "out of platform";
        private const string s_Clash = "clash";

        public Area LandingArea { get; set; }
        public Area LandingPlatform { get; set; }
        public Position? LastCheckedPosition { get; set; }

        public LandingSystem() : this(new Position(0, 0), 1) { }
        public LandingSystem(int topLeftLandingPlatformX, int topLeftLandingPlatformY, int landingPlatformLength)
                            : this(new Position(topLeftLandingPlatformX, topLeftLandingPlatformY), landingPlatformLength) { }
        public LandingSystem(Position topLeftLandingPlatform, int landingPlatformLength)
        {
            if (topLeftLandingPlatform == null)
                throw new ArgumentNullException(nameof(topLeftLandingPlatform), "The top, left corner of the landing platform must be defined!");

            if (topLeftLandingPlatform.X < 0 || topLeftLandingPlatform.Y < 0 ||
                topLeftLandingPlatform.X > 99 || topLeftLandingPlatform.Y > 99)
                throw new ArgumentOutOfRangeException(nameof(topLeftLandingPlatform), "The top, left corner of the landing platform must be within the landing area.");

            if (landingPlatformLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(landingPlatformLength), "Invalid length for the landing platform. The length of the landing platform must be at least 1 unit long.");

            if (topLeftLandingPlatform.X + landingPlatformLength > 100 || topLeftLandingPlatform.Y + landingPlatformLength > 100)
                throw new ArgumentException("The landing platform must fit in the landing area!");

            LandingArea = new Area(new Position(0, 0), 100);
            LandingPlatform = new Area(topLeftLandingPlatform, landingPlatformLength);
        }
        

        public string CheckPosition(Position position)
        {
            if (position.X < 0 || position.Y < 0 ||
                position.X > 99 || position.Y > 99)
                throw new ArgumentOutOfRangeException(nameof(position), "Invalid position, requested position is out of the landing area.");

            string output;
            if (LastCheckedPosition != null &&
                IsPositionWithinArea(new Area(new Position(LastCheckedPosition.X-1, LastCheckedPosition.Y - 1), 3), position))
            {
                output = s_Clash;
            }
            else if (IsPositionWithinArea(LandingPlatform, position))
            {
                output = s_Ok;
            }
            else
            {
                output = s_OutOfPlatform;
            }

            LastCheckedPosition = position;
            return output;
        }

        public string CheckPosition(int x, int y)
        {
            return CheckPosition(new Position(x, y));
        }

        private static bool IsPositionWithinArea(Area area, Position position)
        {
            return position.X >= area.TopLeftCorner.X &&
                    position.X <= area.TopLeftCorner.X + area.Length - 1 &&
                    position.Y >= area.TopLeftCorner.Y &&
                    position.Y <= area.TopLeftCorner.Y + area.Length - 1;
        }
    }
}
