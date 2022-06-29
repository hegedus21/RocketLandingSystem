namespace RocketLandingSystem
{
    public static class Validation
    {
        public static void ValidateLandingPlatform(Position topLeftLandingPlatform, int landingPlatformLength)
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
        }
    }
}
