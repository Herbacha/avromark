using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avromark.Constants
{
    public class RenderConstants
    {
        public static string EscapedTypeSeparator = @" \| ";

        public static class Columns
        {
            public const string PATH = "Path";
            public const string NAME = "Name";
            public const string DOC = "Doc";
            public const string TYPE = "Type";
            public const string DEFAULT = "Default";
        }
    }
}
