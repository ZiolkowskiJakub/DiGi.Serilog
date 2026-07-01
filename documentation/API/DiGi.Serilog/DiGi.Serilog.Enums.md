#### [DiGi\.Serilog](index.md 'index')

## DiGi\.Serilog\.Enums Namespace
### Enums

<a name='DiGi.Serilog.Enums.LogEventLevel'></a>

## LogEventLevel Enum

Defines the severity levels for log events\.

```csharp
public enum LogEventLevel
```
### Fields

<a name='DiGi.Serilog.Enums.LogEventLevel.Verbose'></a>

`Verbose` 0

The most detailed level, typically used for tracing and deep diagnostic information\.

<a name='DiGi.Serilog.Enums.LogEventLevel.Debug'></a>

`Debug` 1

Detailed information useful during development to diagnose issues\.

<a name='DiGi.Serilog.Enums.LogEventLevel.Information'></a>

`Information` 2

General information about the application's operation and flow\.

<a name='DiGi.Serilog.Enums.LogEventLevel.Warning'></a>

`Warning` 3

Indicates a potential problem that does not currently stop the application but may require attention\.

<a name='DiGi.Serilog.Enums.LogEventLevel.Error'></a>

`Error` 4

Indicates an error that occurred during a specific operation, which may be recoverable\.

<a name='DiGi.Serilog.Enums.LogEventLevel.Fatal'></a>

`Fatal` 5

Indicates a critical failure that causes the application to terminate or enter an unusable state\.