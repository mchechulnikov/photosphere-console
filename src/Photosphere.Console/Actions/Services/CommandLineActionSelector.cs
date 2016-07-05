using System;
using System.Linq;
using Photosphere.Console.Actions.Directory;
using Photosphere.Console.Actions.Services.Exceptions;
using Photosphere.Console.Arguments.Attributes;
using Photosphere.Console.Arguments.DataTransferObjects;
using Photosphere.Console.Extensions;

namespace Photosphere.Console.Actions.Services
{
    public class CommandLineActionSelector<TArguments> : ICommandLineActionSelector<TArguments>
        where TArguments : ICommandLineArguments
    {
        private readonly ICommandLineActionsDirectory _actionsDirectory;

        public CommandLineActionSelector(ICommandLineActionsDirectory actionsDirectory)
        {
            _actionsDirectory = actionsDirectory;
        }

        public Action<TArguments> Select(TArguments arguments)
        {
            var attributes = arguments.GetPropertiesAttributes<ConsoleOptionAttribute>();
            foreach (var attribute in attributes.Where(attribute => attribute.BoundedActionType != null))
            {
                return GetAction(attribute.BoundedActionType);
            }
            throw new NoActionWasFoundException(arguments);
        }

        private Action<TArguments> GetAction(Type type)
        {
            var actionService = _actionsDirectory.Actions.First(a => a.GetType() == type);
            return ((ICommandLineAction<TArguments>) actionService).Action;
        }
    }
}