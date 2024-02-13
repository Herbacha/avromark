using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avromark.Constants
{
    public static class AvroParserConstants
    {
        /// <summary>Name of a field in an avro schema containing other fields.</summary>
        public const string FIELDS_LABEL = "fields";

        /// <summary>Name of a field in an avro schema containing a name.</summary>
        public const string NAME_LABEL = "name";

        /// <summary>Name of a field in an avro schema containing a type.</summary>
        public const string TYPE_LABEL = "type";

        /// <summary>Type in an avro schema defining a record.</summary>
        public const string TYPE_RECORD_LABEL = "record";

        /// <summary>Name of a field in an avro schema containing a documentation line.</summary>
        public const string DOC_LABEL = "doc";

        /// <summary>Name of a field in an avro schema containing a default value.</summary>
        public const string DEFAULT_LABEL = "default";


        
    }
}
