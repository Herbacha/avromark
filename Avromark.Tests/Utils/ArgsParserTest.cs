using Avromark.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using Avromark.Exceptions;

namespace Avromark.Tests.Utils
{
    [TestClass]
    public class ArgsParserTest
    {
        [TestMethod]
        public void Parse_OnlyFileFullArgumentName_CorrectValuesAndDefaultValues()
        {
            var sentArguments = "--file myfile.avsc".Split(" ");
            
            var result = ArgsParser.Parse(sentArguments);

            // Assertions

            result.FileName.Should().Be("myfile.avsc");
            result.MandatoryColumn.Should().Be(false);
            result.CompressTypesName.Should().Be(false);
        }

        [TestMethod]
        public void Parse_OnlyFileShortArgumentName_CorrectValuesAndDefaultValues()
        {
            var sentArguments = "-f myfile.avsc".Split(' ');

            var result = ArgsParser.Parse(sentArguments);

            // Assertions

            result.FileName.Should().Be("myfile.avsc");
            result.MandatoryColumn.Should().Be(false);
            result.CompressTypesName.Should().Be(false);
        }

        [TestMethod]
        public void Parse_Empty_ShouldThrowException()
        {
            var sentArguments = "".Split();

            Action parserStartAction = () =>
            {
                var result = ArgsParser.Parse(sentArguments);
            };

            // Assertions
            parserStartAction.Should().Throw<CommandLineArgumentException>();
        }

        [TestMethod]
        public void Parse_MissingFile_ShouldThrowException()
        {
            var sentArguments = "--file".Split(" ");

            Action parserStartAction = () =>
            {
                var result = ArgsParser.Parse(sentArguments);
            };

            // Assertions
            parserStartAction.Should().Throw<CommandLineArgumentException>();
        }
    }
}
