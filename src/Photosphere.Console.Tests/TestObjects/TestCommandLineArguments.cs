using System.Collections.Generic;
using Photosphere.Console.Arguments.Attributes;
using Photosphere.Console.Arguments.DataTransferObjects;

namespace Photosphere.Console.Tests.TestObjects
{
    public class TestCommandLineArguments : ICommandLineArguments
    {
        public TestCommandLineArguments()
        {
            Foos = new List<string>();
        }

        [ConsoleOption(Option = "f")]
        public string Foo { get; set; }

        [ConsoleOption(Option = "fs", AllowMultiple = true)]
        public IList<string> Foos { get; set; }

        [ConsoleOption(Option = "b")]
        public string Bar { get; set; }

        [ConsoleOption(Option = "r", IsRequired = true)]
        public string Rock { get; set; }
    }
}