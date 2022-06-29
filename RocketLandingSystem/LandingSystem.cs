namespace RocketLandingSystem
{
    public class LandingSystem
    {
        private const string s_Ok = "ok for landing";
        private const string s_OutOfPlatform = "out of platform";
        private const string s_Clash = "clash";

        private Area _landingPlatform;
        private Position? LastCheckedPosition { get; set; }

        public Area LandingPlatform 
        { 
            get { return _landingPlatform; }
            set
            {
                Validation.ValidateLandingPlatform(value.TopLeftCorner, value.Length);
                _landingPlatform = value;
            } 
        }

        public LandingSystem() : this(new Position(5, 5), 10) { }
        public LandingSystem(int topLeftLandingPlatformX, int topLeftLandingPlatformY, int landingPlatformLength)
                            : this(new Position(topLeftLandingPlatformX, topLeftLandingPlatformY), landingPlatformLength) { }
        public LandingSystem(Position topLeftLandingPlatform, int landingPlatformLength)
        {
            Validation.ValidateLandingPlatform(topLeftLandingPlatform, landingPlatformLength);

            _landingPlatform = new Area(topLeftLandingPlatform, landingPlatformLength);
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
