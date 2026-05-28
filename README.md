# GigGuide

GigGuide is a cross-platform mobile app for browsing concerts and booking tickets. Customers can sign in, browse upcoming concerts and their performances, view venue information, and place bookings — all backed by a REST API and a SQL Server database.

This project was developed as a group assignment in the course **"Utveckling av mobila applikationer"** (Mobile Application Development) at **Högskolan i Borås**.

## Architecture

The solution consists of four projects:

- **GigGuide.MAUI** — .NET MAUI client app (Android, iOS, MacCatalyst, Windows)
- **GigGuide.API** — ASP.NET Core REST API
- **GigGuide.Data** — Entity Framework Core data layer (entities, repositories, migrations)
- **GigGuide.Data.DTO** — Shared data transfer objects

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- .NET MAUI workload — install with:
  ```bash
  dotnet workload install maui
  ```
- SQL Server (LocalDB on Windows works out of the box; any SQL Server instance works if you update the connection string)
- An IDE with MAUI support — Visual Studio 2022 (17.12+) is recommended; JetBrains Rider also works

## Getting started

### 1. Clone the repository

```bash
git clone <repository-url>
cd GigGuide
```

### 2. Configure the database connection

Open [GigGuide.API/appsettings.json](GigGuide.API/appsettings.json) and update the `GigGuide` connection string if you are not using the default LocalDB instance.

### 3. Apply database migrations

From the `GigGuide` solution folder:

```bash
dotnet ef database update --project GigGuide.Data --startup-project GigGuide.API
```

(If you don't have the EF tools installed, run `dotnet tool install --global dotnet-ef` first.)

### 4. Run the API

```bash
dotnet run --project GigGuide.API
```

The API will start on `https://localhost:5001`. Swagger UI is available at `https://localhost:5001/swagger`.

### 5. Run the MAUI app

Before launching the client, check [GigGuide.MAUI/Constants.cs](GigGuide.MAUI/Constants.cs) and make sure the host/port match where the API is running:

- **Windows / iOS simulator / MacCatalyst:** `localhost` works as-is
- **Android emulator:** uses `10.0.2.2` automatically
- **Physical Android device:** update the IP address in `Constants.cs` to your computer's local IP, and make sure the device is on the same network

Then run the app from Visual Studio by selecting a target (Windows Machine, Android Emulator, etc.) and pressing F5, or from the command line:

```bash
dotnet build GigGuide.MAUI -t:Run -f net8.0-windows10.0.19041.0
```

(Replace the target framework with `net8.0-android`, `net8.0-ios`, or `net8.0-maccatalyst` as needed.)
