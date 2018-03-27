# Pre-release

+ Updated dependencies to current releases.
+ Moved build target to .NET 4.5.
+ Minor tweaks to debug configuration to remove hard coded paths.
+ Modified dependencies to reflect deprecated classes.
+ Renamed `DisConnect` to `Disconnect` to reflect MSFT verb guidelines.
+ Reworked numerous `WriteOutput` to `WriteVerbose` and `WriteError` so as not to break pipeline unnecessarily.
+ Substantial, but stil incomplete, linting to reflect strict coding guidelines.
+ Added minimal `appveyor.yml` for CI building.
  - Added framework for Redis server install to be used for future CI tests.
+ Converted `Connect-RedisServer` from using `RedisClient` to `RedisManagerPool`.

# 2.0.0
+ Migrate to .NET Standard 2.0
+ Create a Nuget Package
