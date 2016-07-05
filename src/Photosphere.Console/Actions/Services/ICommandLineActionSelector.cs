using System;
using Photosphere.Console.Arguments.DataTransferObjects;
using Photosphere.Console.Infrastructure;

namespace Photosphere.Console.Actions.Services
{
    public interface ICommandLineActionSelector<in TArguments> : IConsoleService
        where TArguments : ICommandLineArguments
    {
        Action<TArguments> Select(TArguments arguments);
    }
}