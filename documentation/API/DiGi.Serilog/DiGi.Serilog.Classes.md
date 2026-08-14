#### [DiGi\.Serilog](DiGi.Serilog.Overview.md 'DiGi\.Serilog\.Overview')

## DiGi\.Serilog\.Classes Namespace
### Classes

<a name='DiGi.Serilog.Classes.LoggerManager'></a>

## LoggerManager Class

Manages the creation and retrieval of logger instances\.

One application writes one log. The directory is the one the application was launched from, so every assembly it loads - whichever repository each was built in - reports into the same file.

```csharp
public class LoggerManager
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → LoggerManager
### Properties

<a name='DiGi.Serilog.Classes.LoggerManager.Directory'></a>

## LoggerManager\.Directory Property

Gets or sets the directory the `logs` folder is created in\. When null the directory the application was launched from is used\.

```csharp
public string? Directory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.Serilog.Classes.LoggerManager.GetLogger(System.Reflection.Assembly,bool)'></a>

## LoggerManager\.GetLogger\(Assembly, bool\) Method

Retrieves an existing logger for the specified assembly or creates a new one if requested\.

The log location does not depend on the assembly. It used to be derived from the calling assembly's own location, which put a task's report beside its own library rather than beside the application: two tasks of the same application logged to two different files whenever their libraries were deployed to different folders, and one of them looked as though it had produced no output at all. An assembly bundled into a single-file application made it worse by reporting no location, which silently disabled logging altogether.

```csharp
public Serilog.Core.Logger? GetLogger(System.Reflection.Assembly? assembly, bool create=true);
```
#### Parameters

<a name='DiGi.Serilog.Classes.LoggerManager.GetLogger(System.Reflection.Assembly,bool).assembly'></a>

`assembly` [System\.Reflection\.Assembly](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly 'System\.Reflection\.Assembly')

The assembly asking for the logger\. Retained so a caller can be identified, but it no longer decides where the log is written\.

<a name='DiGi.Serilog.Classes.LoggerManager.GetLogger(System.Reflection.Assembly,bool).create'></a>

`create` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether a new logger should be created if an existing one is not found\. Defaults to true\.

#### Returns
[Serilog\.Core\.Logger](https://learn.microsoft.com/en-us/dotnet/api/serilog.core.logger 'Serilog\.Core\.Logger')  
The [Serilog\.Core\.Logger](https://learn.microsoft.com/en-us/dotnet/api/serilog.core.logger 'Serilog\.Core\.Logger') instance, or `null` if the assembly is null, the path cannot be determined, or creation is disabled and no logger exists\.