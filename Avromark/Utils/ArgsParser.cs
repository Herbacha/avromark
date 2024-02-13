using Avromark.Exceptions;
using Avromark.Models;
using Avromark.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avromark.Utils
{
    public static class ArgsParser
    {
        public static Configuration Parse(string[] args)
        {
            if ((args.Length < 2) || !args.Contains(ArgumentsConstants.FILE_PARAMETER) && !args.Contains(ArgumentsConstants.FILE_SHORT_PARAMETER))
                throw new CommandLineArgumentException(string.Join("", HelpConstants.NoFileProvided, HelpConstants.SampleUsage));

            var parsedConfiguration = new Dictionary<string, object>();

            for (int iArgument = 0; iArgument < args.Length; iArgument++)
            {
                if (!args[iArgument].StartsWith('-') || !ArgumentsConstants.AllowedArguments.ContainsKey(args[iArgument]))
                    throw new CommandLineArgumentException(string.Format(HelpConstants.UnknownArgument, args[iArgument]));

                var resolvedArgumentName = ArgumentsConstants.AllowedArguments[args[iArgument]];

                if (!ArgumentsConstants.ArgumentsWithValue.Contains(resolvedArgumentName))
                {
                    parsedConfiguration.Add(resolvedArgumentName, true);
                }
                else
                {
                    if (iArgument + 1 >= args.Length || args[iArgument + 1].StartsWith("-"))
                        throw new CommandLineArgumentException(string.Format(HelpConstants.MissingValueForArgument, args[iArgument]));

                    parsedConfiguration.Add(resolvedArgumentName, args[iArgument+1]);
                    iArgument++;
                }
            }

            return new Configuration(parsedConfiguration);

        }

    }
}
