using System.Collections.Generic;
using Photosphere.Console.Arguments.DataTransferObjects;

namespace Photosphere.Console.Arguments.Services
{
    public interface ICommandLineArgumentsParser<out TCommandLineArguments>
        where TCommandLineArguments : ICommandLineArguments, new()
    {
        TCommandLineArguments Parse(IEnumerable<string> args);
    }
}