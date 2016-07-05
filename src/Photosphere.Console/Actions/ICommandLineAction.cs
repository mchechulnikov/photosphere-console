using Photosphere.Console.Arguments.DataTransferObjects;

namespace Photosphere.Console.Actions
{
    public interface ICommandLineAction {}

    public interface ICommandLineAction<in TArguments> : ICommandLineAction
        where TArguments : ICommandLineArguments
    {
        void Action(TArguments arguments);
    }
}