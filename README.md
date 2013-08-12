# EECloud
EECloud is an open source platform that you can use to connect to the servers of [Everybody Edits][] and perform actions with, just like you would in the game.

[Everybody Edits]: http://everybodyedits.com/

## The structure
This repository consists of 6 elements:

  * EECloud           - The official implementation of EECloud.Host, for use in production
  * EECloud.API       - The API refrenced by plugins to use the functions of EECloud
  * EECloud.Host      - Hosting API can be used to run EECloud _Plugins_ on any .NET application
  * EECloud.EEService - Stores and fetches data of players, and other useful information in a SQL database
  * EECloud.Launcher  - Works as a wrapper around EECloud.exe, restarts in case the _Connection_ gets lost
  * EECloud.Setup     - Installs the components of EECloud

The project is written in [VB.NET][], and requires [Microsoft .NET Framework 4.5][] (or higher), and [Visual C++ Redistributable 2012 Update 1][] (or higher) to be installed for its users. Developers should install [Microsoft Visual Studio 2012][] (or higher), and [WiX Toolset][] (in order to compile _EECloud.Setup)._

[VB.NET]: http://wikipedia.org/wiki/Visual_Basic_.NET
[Microsoft .NET Framework 4.5]: http://www.microsoft.com/download/details.aspx?id=30653
[Visual C++ Redistributable 2012 Update 1]: http://www.microsoft.com/download/details.aspx?id=30679
[Microsoft Visual Studio 2012]: http://www.microsoft.com/visualstudio/
[WiX Toolset]: http://wixtoolset.org/

## Components
### Connection-specific components
These components are shared between all _Plugins_ in a _Connection:_

  * Game
  * Uploader
  * PluginManager
  * KeyManager
  * Connection
  * World

### Plugin-specific components
These components have a new instance per plugin and have customized behavior for the plugin they are serving:

  * Client
  * Chatter
  * CommandManager
  * PlayerManager
