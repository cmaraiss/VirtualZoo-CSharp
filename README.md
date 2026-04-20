# Virtual Zoo Management System

This is my C# OOP project for PRG521 at uni. It's a virtual zoo where you manage animals - feeding them, moving them around, the usual stuff. I built a few versions as the assignments progressed.

## Versions

**FA2 (main)** - The first proper implementation. Uses interfaces (IFeedable, IMovable) to define animal behaviours. Straightforward OOP with inheritance and polymorphism.

**FA3** - Built on top of FA2 but adds abstract classes, custom exceptions (like FeedingException), enums for animal types, and structs. Basically the "more advanced OOP" version.

**FA2/zooManager** - A modular console app version where each class lives in its own file. Same concepts, just better organised as a proper project structure.

## Tech

- C#
- .NET 8

## Build and Run

Pick a version folder, then:

```bash
dotnet build
dotnet run
```

That's it. Each folder has its own .csproj so they run independently.
