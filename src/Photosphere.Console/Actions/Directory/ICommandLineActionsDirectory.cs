using System.Collections.Generic;

namespace Photosphere.Console.Actions.Directory
{
    public interface ICommandLineActionsDirectory
    {
        IReadOnlyList<ICommandLineAction> Actions { get; }
    }
}