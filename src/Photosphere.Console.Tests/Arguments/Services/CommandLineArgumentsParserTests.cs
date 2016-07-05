using Photosphere.Console.Arguments.Services;
using Photosphere.Console.Arguments.Services.Exceptions;
using Photosphere.Console.Tests.TestObjects;
using Xunit;

namespace Photosphere.Console.Tests.Arguments.Services
{
    public class CommandLineArgumentsParserTests
    {
        [Theory]
        [InlineData("-f fooValue -b barValue -r rockValue", "fooValue", "barValue", "rockValue")]
        internal void Parse_ValidArgumentsWithoutArray_ValidDto(string args, string foo, string bar, string rock)
        {
            var parser = new CommandLineArgumentsParser<TestCommandLineArguments>();

            var result = parser.Parse(args.Split(' '));

            Assert.Equal(foo, result.Foo);
            Assert.Equal(0, result.Foos.Count);
            Assert.Equal(bar, result.Bar);
            Assert.Equal(rock, result.Rock);
        }

        [Fact]
        internal void Parse_ValidArgumentsWithArray_ValidDto()
        {
            var parser = new CommandLineArgumentsParser<TestCommandLineArguments>();
            var args = "-f fooValue -fs foo1 foo2 foo3 -b barValue".Split(' ');

            var result = parser.Parse(args);

            Assert.Equal("fooValue", result.Foo);
            Assert.Equal(3, result.Foos.Count);
            Assert.Equal("foo1", result.Foos[0]);
            Assert.Equal("foo2", result.Foos[1]);
            Assert.Equal("foo3", result.Foos[2]);
            Assert.Equal("barValue", result.Bar);
        }

        [Fact]
        internal void Parse_InvalidArgumentsWithoutArray_Exception()
        {
            var parser = new CommandLineArgumentsParser<TestCommandLineArguments>();
            try
            {
                parser.Parse("-f fooValue -e foo".Split(' '));
                Assert.True(false);
            }
            catch (UnrecognizedCommandLineOptionException)
            {
                Assert.True(true);
            }
        }

        [Fact]
        internal void Parse_InvalidArgumentsWithArray_Exception()
        {
            var parser = new CommandLineArgumentsParser<TestCommandLineArguments>();
            try
            {
                parser.Parse("-f fooValue -fs -b barValue".Split(' '));
                Assert.True(false);
            }
            catch (InvalidCommandLineOptionValuesCountException)
            {
                Assert.True(true);
            }
        }

        [Fact]
        internal void Parse_InvalidArgumentsNotAllowMultiple_Exception()
        {
            var parser = new CommandLineArgumentsParser<TestCommandLineArguments>();
            try
            {
                parser.Parse("-f foo1 foo2 foo3 -b barValue".Split(' '));
                Assert.True(false);
            }
            catch (InvalidCommandLineOptionValuesCountException)
            {
                Assert.True(true);
            }
        }
    }
}