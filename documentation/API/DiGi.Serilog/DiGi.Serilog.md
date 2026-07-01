#### [DiGi\.Serilog](index.md 'index')

## DiGi\.Serilog Namespace
### Classes

<a name='DiGi.Serilog.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.Serilog.Modify.Log(DiGi.Serilog.Enums.LogEventLevel,string,object[])'></a>

## Modify\.Log\(LogEventLevel, string, object\[\]\) Method

Logs a message with a specified event level using the calling assembly\.

```csharp
public static bool Log(DiGi.Serilog.Enums.LogEventLevel logEventLevel, string? message, params object[] parameters);
```
#### Parameters

<a name='DiGi.Serilog.Modify.Log(DiGi.Serilog.Enums.LogEventLevel,string,object[]).logEventLevel'></a>

`logEventLevel` [LogEventLevel](DiGi.Serilog.Enums.md#DiGi.Serilog.Enums.LogEventLevel 'DiGi\.Serilog\.Enums\.LogEventLevel')

The severity level of the log event\.

<a name='DiGi.Serilog.Modify.Log(DiGi.Serilog.Enums.LogEventLevel,string,object[]).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template to be logged\.

<a name='DiGi.Serilog.Modify.Log(DiGi.Serilog.Enums.LogEventLevel,string,object[]).parameters'></a>

`parameters` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The arguments to be formatted into the message template\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the logging operation was successful; otherwise, false\.

<a name='DiGi.Serilog.Modify.Log(string,object[])'></a>

## Modify\.Log\(string, object\[\]\) Method

Logs an information message using the calling assembly\.

```csharp
public static bool Log(string? message, params object[] parameters);
```
#### Parameters

<a name='DiGi.Serilog.Modify.Log(string,object[]).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template to be logged\.

<a name='DiGi.Serilog.Modify.Log(string,object[]).parameters'></a>

`parameters` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The arguments to be formatted into the message template\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the logging operation was successful; otherwise, false\.

<a name='DiGi.Serilog.Modify.Log(System.Exception,string)'></a>

## Modify\.Log\(Exception, string\) Method

Logs an error message and a corresponding exception using the calling assembly\.

```csharp
public static bool Log(System.Exception? exception, string? message);
```
#### Parameters

<a name='DiGi.Serilog.Modify.Log(System.Exception,string).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception to be logged\.

<a name='DiGi.Serilog.Modify.Log(System.Exception,string).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error message to be logged\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the logging operation was successful; otherwise, false\.

<a name='DiGi.Serilog.Modify.Log(System.Exception,string,object[])'></a>

## Modify\.Log\(Exception, string, object\[\]\) Method

Logs an error message with arguments and a corresponding exception using the calling assembly\.

```csharp
public static bool Log(System.Exception? exception, string? message, params object[] parameters);
```
#### Parameters

<a name='DiGi.Serilog.Modify.Log(System.Exception,string,object[]).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception to be logged\.

<a name='DiGi.Serilog.Modify.Log(System.Exception,string,object[]).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template to be logged\.

<a name='DiGi.Serilog.Modify.Log(System.Exception,string,object[]).parameters'></a>

`parameters` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The arguments to be formatted into the message template\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the logging operation was successful; otherwise, false\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,DiGi.Serilog.Enums.LogEventLevel,string,object[])'></a>

## Modify\.Log\(this Assembly, LogEventLevel, string, object\[\]\) Method

Logs a message with a specified event level for the given assembly\.

```csharp
public static bool Log(this System.Reflection.Assembly? assembly, DiGi.Serilog.Enums.LogEventLevel logEventLevel, string? message, params object[] parameters);
```
#### Parameters

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,DiGi.Serilog.Enums.LogEventLevel,string,object[]).assembly'></a>

`assembly` [System\.Reflection\.Assembly](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly 'System\.Reflection\.Assembly')

The assembly to associate with the logger\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,DiGi.Serilog.Enums.LogEventLevel,string,object[]).logEventLevel'></a>

`logEventLevel` [LogEventLevel](DiGi.Serilog.Enums.md#DiGi.Serilog.Enums.LogEventLevel 'DiGi\.Serilog\.Enums\.LogEventLevel')

The severity level of the log event\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,DiGi.Serilog.Enums.LogEventLevel,string,object[]).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template to be logged\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,DiGi.Serilog.Enums.LogEventLevel,string,object[]).parameters'></a>

`parameters` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The arguments to be formatted into the message template\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the logging operation was successful; otherwise, false\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,string,object[])'></a>

## Modify\.Log\(this Assembly, string, object\[\]\) Method

Logs an information message for the given assembly\.

```csharp
public static bool Log(this System.Reflection.Assembly? assembly, string? message, params object[] parameters);
```
#### Parameters

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,string,object[]).assembly'></a>

`assembly` [System\.Reflection\.Assembly](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly 'System\.Reflection\.Assembly')

The assembly to associate with the logger\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,string,object[]).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template to be logged\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,string,object[]).parameters'></a>

`parameters` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The arguments to be formatted into the message template\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the logging operation was successful; otherwise, false\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,System.Exception,string)'></a>

## Modify\.Log\(this Assembly, Exception, string\) Method

Logs an error message and a corresponding exception for the given assembly\.

```csharp
public static bool Log(this System.Reflection.Assembly? assembly, System.Exception? exception, string? message);
```
#### Parameters

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,System.Exception,string).assembly'></a>

`assembly` [System\.Reflection\.Assembly](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly 'System\.Reflection\.Assembly')

The assembly to associate with the logger\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,System.Exception,string).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception to be logged\.

<a name='DiGi.Serilog.Modify.Log(thisSystem.Reflection.Assembly,System.Exception,string).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error message to be logged\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the logging operation was successful; otherwise, false\.

<a name='DiGi.Serilog.Settings'></a>

## Settings Class

```csharp
public static class Settings
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Settings
### Properties

<a name='DiGi.Serilog.Settings.LoggerManager'></a>

## Settings\.LoggerManager Property

Gets the logger manager instance\.

```csharp
public static DiGi.Serilog.Classes.LoggerManager LoggerManager { get; }
```

#### Property Value
[LoggerManager](DiGi.Serilog.Classes.md#DiGi.Serilog.Classes.LoggerManager 'DiGi\.Serilog\.Classes\.LoggerManager')