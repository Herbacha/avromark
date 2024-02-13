using Avromark.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avromark.Models
{
    /// <summary>Configuration arguments</summary>
    public class Configuration
    {
        /// <summary>Name of the file to convert to markdown</summary>
        public string FileName { get; private set; }

        /// <summary>Option to compress type names</summary>
        public bool CompressTypesName { get; private set; }

        /// <summary>Option to display a Mandatory column, that indicates "false" on nullable types.</summary>
        public bool MandatoryColumn { get; private set; }

        public Configuration(Dictionary<string, object> values)
        {
            FileName = values[nameof(ArgumentsConstants.FILE_PARAMETER)].ToString();

            CompressTypesName = values.ContainsKey(nameof(ArgumentsConstants.COMPRESS_TYPE_PARAMETER));

            MandatoryColumn = values.ContainsKey(nameof(ArgumentsConstants.MANDATORY_COLUMN_PARAMETER));
        }
    }
}
