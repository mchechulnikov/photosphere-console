using System;
using Photosphere.Console.Arguments.DataTransferObjects;

namespace Photosphere.Console.Actions.Services.Exceptions
{
    public class NoActionWasFoundException : Exception
    {
        private readonly string _argumentsTypeName;

        public NoActionWasFoundException(ICommandLineArguments arguments)
        {
            _argumentsTypeName = arguments.GetType().Name;
        }

        public override string Message => $"No action was found in arguments `{_argumentsTypeName}`";
    }
}