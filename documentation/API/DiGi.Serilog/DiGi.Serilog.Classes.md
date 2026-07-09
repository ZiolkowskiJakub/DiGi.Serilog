#### [DiGi\.Serilog](DiGi.Serilog.Overview.md 'DiGi\.Serilog\.Overview')

## DiGi\.Serilog\.Classes Namespace
### Classes

<a name='DiGi.Serilog.Classes.LoggerManager'></a>

## LoggerManager Class

Manages the creation and retrieval of logger instances associated with specific assemblies\.

```csharp
public class LoggerManager
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → LoggerManager
### Methods

<a name='DiGi.Serilog.Classes.LoggerManager.GetLogger(System.Reflection.Assembly,bool)'></a>

## LoggerManager\.GetLogger\(Assembly, bool\) Method

Retrieves an existing logger for the specified assembly or creates a new one if requested\.

```csharp
public Serilog.Core.Logger? GetLogger(System.Reflection.Assembly? assembly, bool create=true);
```
#### Parameters

<a name='DiGi.Serilog.Classes.LoggerManager.GetLogger(System.Reflection.Assembly,bool).assembly'></a>

`assembly` [System\.Reflection\.Assembly](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly 'System\.Reflection\.Assembly')

The assembly used to determine the directory and path for the log file\.

<a name='DiGi.Serilog.Classes.LoggerManager.GetLogger(System.Reflection.Assembly,bool).create'></a>

`create` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether a new logger should be created if an existing one is not found\. Defaults to true\.

#### Returns
[Serilog\.Core\.Logger](https://learn.microsoft.com/en-us/dotnet/api/serilog.core.logger 'Serilog\.Core\.Logger')  
The [Serilog\.Core\.Logger](https://learn.microsoft.com/en-us/dotnet/api/serilog.core.logger 'Serilog\.Core\.Logger') instance associated with the assembly, or `null` if the assembly is null, the path cannot be determined, or creation is disabled and no logger exists\.