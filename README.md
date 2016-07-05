# Photosphere.Console
Set of command line utilities.

## Status
[![Windows build Status](https://ci.appveyor.com/api/projects/status/github/sunloving/photosphere-console?retina=true&svg=true)](https://ci.appveyor.com/project/sunloving/photosphere-console)
[![NuGet](https://img.shields.io/nuget/v/Photosphere.Console.svg)](https://www.nuget.org/packages/Photosphere.Console/)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg?maxAge=2592000)](https://github.com/sunloving/photosphere-console/blob/master/LICENSE)

## Install via NuGet
```
PM> Install-Package Photosphere.Console
```

## Interface
``` C#
interface ICommandLineArgumentsParser<T> : IConsoleService where T : ICommandLineArguments
interface ICommandLineActionSelector<T> : IConsoleService where T : ICommandLineArguments
```

### Example
``` C#
registrator.Register<IConsoleService>(); // if you use dependency injection, you can register services by common interface
```
``` C# 
class FooArguments : ICommandLineArguments
{
  [ConsoleOption(Option = "f", BoundedActionType = typeof(CompileAction))]
  public IReadOnlyList<string> FilePathes { get; set; }

  [ConsoleOption(Option = "h", BoundedActionType = typeof(ShowHelpAction))]
  public bool ShowHelp { get; set; }
}
```
``` C#
class DoSomethingAction : ICommandLineAction<ICommandLineArguments>
{
  public void Action(ICompilerArguments arguments)
  {
    Console.WriteLine("Do something!");
  }
}
```
``` C#
class ShowHelpAction : ICommandLineAction<ICompilerArguments>
{
  public void Action(ICompilerArguments arguments)
  {
    Console.WriteLine("It's a help!");
  }
}
```
``` C#
class FooProgram
{
  private readonly ICommandLineArgumentsParser<FooArguments> _commandLineArgumentsParser;
  private readonly ICommandLineActionSelector<FooArguments> _commandLineActionSelector;

  public FooProgram(
    ICommandLineArgumentsParser<FooArguments> commandLineArgumentsParser,
    ICommandLineActionSelector<FooArguments> commandLineActionSelector)
  {
    _commandLineArgumentsParser = commandLineArgumentsParser;
    _commandLineActionSelector = commandLineActionSelector;
  }

  public void Start(IEnumerable<string> args)
  {
    var arguments = _commandLineArgumentsParser.Parse(args);
    var action = _commandLineActionSelector.Select(arguments);
    action(arguments);
  }
}
```
