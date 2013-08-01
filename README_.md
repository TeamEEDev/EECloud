# EECloud
EECloud is a special platform which allows you to connect to the servers of [Everybody Edits][], and do actions like in the game.

[Everybody Edits]: http://everybodyedits.com/

## The structure
This repository consists of 5 elements:

  * EECloud          - The official implementation of EECloud.Host, for use in production
  * EECloud.API      - The API refrenced by Plugins to use the functions of EECloud
  * EECloud.Host     - Hosting API can be used to run EECloud Plugins on any .NET Application
  * EECloud.Launcher - Works as a wrapper around EECloud.exe, restarts in case the connection gets lost
  * EECloud.Setup    - Installs the components of EECloud

The project is written in [VB.NET][], and requires [Microsoft .NET Framework 4.5][] (or higher) and [WiX Toolset][] (for the installer project) to be installed.

[VB.NET]: http://wikipedia.org/wiki/Visual_Basic_.NET
[Microsoft .NET Framework 4.5]: http://www.microsoft.com/download/details.aspx?id=30653
[WiX Toolset]: http://wixtoolset.org/

## Components
### Connection-specific components
These components are shared between all plugins in a connection:

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