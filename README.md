# RocketLandingSystem

Requirements: .NET 6, VS 2022

Unit test framework: XUnit

Library interface to query position:
```
LandingSystem.CheckPosition(int x, int y)
LandingSystem.CheckPosition(Position position)
```

Create new landing system module:
```
LandingSystem.LandingSystem()
LandingSystem.LandingSystem(int topLeftLandingPlatformX, int topLeftLandingPlatformY, int landingPlatformLength)
LandingSystem.LandingSystem(Position topLeftLandingPlatform, int landingPlatformLength)
```
