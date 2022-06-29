using RocketLandingSystem;

namespace RocketLandingSystemTests
{
    public class LandingSystemTests
    {
        [Fact]
        public void LandingPlatformSetToNullTestThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new LandingSystem(null, 5));
        }

        [Fact]
        public void LandingPlatformTopLeftCornerSetToInvalidPositionTestThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingSystem(-10,-10, 25));
        }

        [Fact]
        public void LandingPlatformLengthSetToNegativeLengthTestThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingSystem(new Position(10,10), -50));
        }

        [Fact]
        public void LandingPlatformDoesNotFitInTheLandingAreaTestThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new LandingSystem(new Position(10, 10), 92));
        }

        [Fact]
        public void LandingPlatformAreaChangedToAnInvalidAreaTestThrowsArgumentOutOfRangeException()
        {
            LandingSystem landingSystem = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => landingSystem.LandingPlatform = new Area(new Position(-3,5), 10));
        }

        [Fact]
        public void DefaultLandingPlatformAreaSetToTheInitialValuesTest()
        {
            LandingSystem landingSystem = new();
            Assert.Equal(10, landingSystem.LandingPlatform.Length);
            Assert.Equal(5, landingSystem.LandingPlatform.TopLeftCorner.X);
            Assert.Equal(5, landingSystem.LandingPlatform.TopLeftCorner.Y);
        }

        [Fact]
        public void CheckPositionCalledWithInvalidPositionTest()
        {
            LandingSystem landingSystem = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => landingSystem.CheckPosition(-5,-10));
        }

        [Fact]
        public void CheckPositionCalledWithValidPositionInsideTheLandingPlatformTest()
        {
            LandingSystem landingSystem = new();

            var result = landingSystem.CheckPosition(new Position(10, 10));
            Assert.Equal("ok for landing", result);
        }

        [Fact]
        public void CheckPositionCalledWithValidPositionOutsideTheLandingPlatformTest()
        {
            LandingSystem landingSystem = new();

            var result = landingSystem.CheckPosition(new Position(20, 20));
            Assert.Equal("out of platform", result);
        }

        [Fact]
        public void SamePositionCheckedTwiceByTwoRocketsOneAfterTheOtherTest()
        {
            LandingSystem landingSystem = new();

            var firstRocketCheckResult = landingSystem.CheckPosition(new Position(10, 10));
            Assert.Equal("ok for landing", firstRocketCheckResult);

            var secondRocketCheckResult = landingSystem.CheckPosition(new Position(10, 10));
            Assert.Equal("clash", secondRocketCheckResult);
        }

        [Fact]
        public void CheckPositionCalledWithValidPositionButNextToThePositionOtherRocketCheckedTheLandingPlatformTest()
        {
            LandingSystem landingSystem = new();

            var firstRocketCheckResult = landingSystem.CheckPosition(new Position(10, 10));
            Assert.Equal("ok for landing", firstRocketCheckResult);

            var secondRocketCheckResult = landingSystem.CheckPosition(new Position(11, 11));
            Assert.Equal("clash", secondRocketCheckResult);
        }
    }
}