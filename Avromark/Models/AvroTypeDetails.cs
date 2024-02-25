using Avromark.Enum;

namespace Avromark.Models
{
    public class AvroTypeDetails
    {
        /// <summary>The Avro type in a readable format</summary>
        public string ReadableType { get
            {
                return LogicalType == null ?
                    _baseType :
                    LogicalType.ToString() + $"({_baseType})";
            }
        }

        private string _baseType;

        /// <summary>Complex type if available</summary>
        public AvroComplexType? ComplexType { get; private set; }

        /// <summary>Complex type if available</summary>
        public AvroLogicalType? LogicalType { get; private set; }

        public AvroTypeDetails(string readableType, AvroComplexType? complexType = null, AvroLogicalType? logicalType = null)
        {
            _baseType = readableType;
            ComplexType = complexType;
            LogicalType = logicalType;
        }
    }
}
