using System;

namespace Photosphere.Console.Arguments.Services.Exceptions
{
    public class UnrecognizedCommandLineOptionException : Exception
    {
        private readonly string _option;

        public UnrecognizedCommandLineOptionException(string option)
        {
            _option = option;
        }

        public override string Message => $"Unrecognized command line option `{_option}`";
    }
}