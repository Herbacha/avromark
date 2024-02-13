using Avromark.Utils;
using System;

namespace Avromark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = ArgsParser.Parse(args);

            var resultMarkdown = new MakdownFactory(configuration).GenerateMarkdown();

            Console.WriteLine(resultMarkdown);
        }
    }
}