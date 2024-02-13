using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avromark.Constants
{
    public static class HelpConstants
    {
        public const string NoFileProvided = "No file provided in the arguments.";

        public const string SampleUsage = "Usage: avromark.exe --file path/to/file.avsc";

        public const string UnknownArgument = "This argument is unknown: {0}";

        public const string MissingValueForArgument = "Missing value for argument: {0}";

    }
}
