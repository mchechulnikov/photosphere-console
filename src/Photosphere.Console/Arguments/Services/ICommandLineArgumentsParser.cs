using System.Collections.Generic;
using Photosphere.Console.Arguments.DataTransferObjects;
using Photosphere.Console.Infrastructure;

namespace Photosphere.Console.Arguments.Services
{
    public interface ICommandLineArgumentsParser<out TCommandLineArguments> : IConsoleService
        where TCommandLineArguments : ICommandLineArguments, new()
    {
        TCommandLineArguments Parse(IEnumerable<string> args);
    }
}