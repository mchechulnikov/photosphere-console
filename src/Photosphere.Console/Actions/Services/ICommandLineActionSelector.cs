using System;
using Photosphere.Console.Arguments.DataTransferObjects;

namespace Photosphere.Console.Actions.Services
{
    public interface ICommandLineActionSelector<in TArguments>
        where TArguments : ICommandLineArguments
    {
        Action<TArguments> Select(TArguments arguments);
    }
}