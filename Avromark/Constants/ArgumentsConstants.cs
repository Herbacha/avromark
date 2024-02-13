using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avromark.Constants
{
    /// <summary>Constants to evaluate arguments of the command line.</summary>
    public static class ArgumentsConstants
    {
        /// <summary>Parameter preceding a file name.</summary>
        public const string FILE_PARAMETER = "--file";

        /// <summary>Parameter preceding a file name, short version.</summary>
        public const string FILE_SHORT_PARAMETER = "-f";


        /// <summary>Parameter preceding a file name.</summary>
        public const string COMPRESS_TYPE_PARAMETER = "--compress-type";

        /// <summary>Parameter preceding a file name.</summary>
        public const string MANDATORY_COLUMN_PARAMETER = "--mandatory-column";


        /// <summary>A Dictionary of allowed arguments, linked with the longest version of the constant name.</summary>
        public static readonly Dictionary<string, string> AllowedArguments =
            new Dictionary<string, string>()
            {
                { FILE_PARAMETER, nameof(FILE_PARAMETER) },
                { FILE_SHORT_PARAMETER, nameof(FILE_PARAMETER) },
                { COMPRESS_TYPE_PARAMETER, nameof(COMPRESS_TYPE_PARAMETER) },
                { MANDATORY_COLUMN_PARAMETER, nameof(MANDATORY_COLUMN_PARAMETER) }
            };

        /// <summary>A list of arguments followed by a value that needs to be stored. Any argument not in this list is just evaluated as "true" if the argument exists.</summary>
        public static readonly List<string> ArgumentsWithValue = new() { nameof(FILE_PARAMETER) };
    }
}
