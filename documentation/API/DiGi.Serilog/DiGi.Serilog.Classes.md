#### [DiGi\.Serilog](DiGi.Serilog.Overview.md 'DiGi\.Serilog\.Overview')

## DiGi\.Serilog\.Classes Namespace
### Classes

<a name='DiGi.Serilog.Classes.LoggerManager'></a>

## LoggerManager Class

Manages the creation and retrieval of logger instances\.

By default one application writes one log. The directory is the one the application was launched from, so every assembly it loads - whichever repository each was built in - reports into the same file. Deriving the log location from the calling assembly's own location used to split one application's output across files whenever its assemblies were deployed to different folders, and an assembly bundled into a single-file application reported no location at all, which silently disabled logging.

When [RoutePerAssembly](DiGi.Serilog.Classes.md#DiGi.Serilog.Classes.LoggerManager.RoutePerAssembly 'DiGi\.Serilog\.Classes\.LoggerManager\.RoutePerAssembly') is enabled, an assembly that has a resolvable location writes its log beside itself instead. A modular host that loads extensions from sub-folders uses this so every extension keeps its own `logs` folder while the host keeps the one beside the application. The explicit [Directory](DiGi.Serilog.Classes.md#DiGi.Serilog.Classes.LoggerManager.Directory 'DiGi\.Serilog\.Classes\.LoggerManager\.Directory') override always wins.

```csharp
public class LoggerManager
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → LoggerManager
### Properties

<a name='DiGi.Serilog.Classes.LoggerManager.Directory'></a>

## LoggerManager\.Directory Property

Gets or sets the directory the `logs` folder is created in\. When null the directory the application was launched from is used, or the requesting assembly's own directory when [RoutePerAssembly](DiGi.Serilog.Classes.md#DiGi.Serilog.Classes.LoggerManager.RoutePerAssembly 'DiGi\.Serilog\.Classes\.LoggerManager\.RoutePerAssembly') is enabled\.

```csharp
public string? Directory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Serilog.Classes.LoggerManager.RoutePerAssembly'></a>

## LoggerManager\.RoutePerAssembly Property

Gets or sets a value indicating whether a logger writes into the directory of the assembly requesting it instead of the directory the application was launched from\. Defaults to false, so one application writes one log no matter where its assemblies were deployed\.

```csharp
public bool RoutePerAssembly { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')
### Methods

<a name='DiGi.Serilog.Classes.LoggerManager.GetLogger(System.Reflection.Assembly,bool)'></a>

## LoggerManager\.GetLogger\(Assembly, bool\) Method

Retrieves an existing logger for the specified assembly or creates a new one if requested\.

Concurrent first-time requests for the same path resolve to a single [Serilog\.Core\.Logger](https://learn.microsoft.com/en-us/dotnet/api/serilog.core.logger 'Serilog\.Core\.Logger'), so controller code logging in parallel never races on the cache.

```csharp
public Serilog.Core.Logger? GetLogger(System.Reflection.Assembly? assembly, bool create=true);
```
#### Parameters

<a name='DiGi.Serilog.Classes.LoggerManager.GetLogger(System.Reflection.Assembly,bool).assembly'></a>

`assembly` [System\.Reflection\.Assembly](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly 'System\.Reflection\.Assembly')

The assembly asking for the logger\. With [RoutePerAssembly](DiGi.Serilog.Classes.md#DiGi.Serilog.Classes.LoggerManager.RoutePerAssembly 'DiGi\.Serilog\.Classes\.LoggerManager\.RoutePerAssembly') enabled and a resolvable location it also decides where the log is written; otherwise it is retained so a caller can be identified\.

<a name='DiGi.Serilog.Classes.LoggerManager.GetLogger(System.Reflection.Assembly,bool).create'></a>

`create` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether a new logger should be created if an existing one is not found\. Defaults to true\.

#### Returns
[Serilog\.Core\.Logger](https://learn.microsoft.com/en-us/dotnet/api/serilog.core.logger 'Serilog\.Core\.Logger')  
The [Serilog\.Core\.Logger](https://learn.microsoft.com/en-us/dotnet/api/serilog.core.logger 'Serilog\.Core\.Logger') instance, or `null` if the assembly is null, the path cannot be determined, or creation is disabled and no logger exists\.