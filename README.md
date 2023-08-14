# nier-rein-apps
An assortment of applications interfacing with the API of Nier Reincarnation, built on .NET7.

## NierReincarnation.Core
This is the Core implementation of the game by reverse engineering the game code and closely follows the same structure and behavior.

## NierReincarnation.Api
This is a higher level library that uses NierReincarnation.Core and exploses extra custom functionality.

## NierReincarnation.Datamine
An application used to datamine information from the game. It has a dependency on [AssetStudio](https://github.com/Perfare/AssetStudio).

## NierReincarnation.Db
An application used to export game data to a PostgreSQL database. Used for the [https://nierrein.guide/](https://nierrein.guide/) website.

# Usage

## Nuget packages
NierReincarnation.Core and NierReincarnation.Api come as nuget packages that you can import and use in your own project.

## NierReincarnation.Datamine
### Requirements
- [Visual Studio 2022 or newer](https://visualstudio.microsoft.com/downloads/)
- [Autodesk FBX SDK 2020.2.1](https://www.autodesk.com/developer-network/platform-technologies/fbx-sdk-2020-2-1)
### Build
1. Install all above requirements
1. Build the AssetStudio solution at ```src\External\AssetStudio\AssetStudio.sln```
1. Build the main solution in the root folder ```NierReincarnation.sln```
1. Run the ```NierReincarnation.Datamine``` app

## NierReincarnation.Db
1. Copy the ```src\NierReincarnation.Db\config\dbConfig.stub.json``` file to ```src\NierReincarnation.Db\config\dbConfig.json``` and populate it with the database connection details
1. Build the main solution in the root folder ```NierReincarnation.sln```
1. Run the ```NierReincarnation.Db``` app

# Open source libraries used
- [AssetStudio](https://github.com/Perfare/AssetStudio)
- [CommandLine](https://github.com/commandlineparser/commandline)
- [ConsoleTools](https://github.com/lastunicorn/ConsoleTools)
- [Google.Protobuf](https://github.com/protocolbuffers/protobuf)
- [GRPC](https://github.com/grpc/grpc)
- [K4os.Compression.LZ4](https://github.com/MiloszKrajewski/K4os.Compression.LZ4)
- [MessagePack-CSharp](https://github.com/MessagePack-CSharp/MessagePack-CSharp)
- [NCrontab](https://github.com/atifaziz/NCrontab)
- [protobuf-net](https://github.com/protobuf-net/protobuf-net)