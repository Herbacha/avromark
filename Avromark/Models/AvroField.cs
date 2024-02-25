using Avromark.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avromark.Models
{
    public class AvroField
    {
        public AvroField? ParentField { get; private set; }
        public IEnumerable<AvroField>? ChildrenFields { get; private set; }

        public string Name { get; private set; }
        public string Type { get; private set; }
        public string? Doc { get; private set; }
        public string? DefaultValue { get; private set; }
        public AvroComplexType? ComplexType { get; private set; }
        public AvroLogicalType? LogicalType { get; private set; }

        public AvroField(AvroField? parentField, IEnumerable<AvroField>? childrenFields, string name, string type, string? doc, string? defaultValue, AvroComplexType? complexType, AvroLogicalType? logicalType)
        {
            ParentField = parentField;
            ChildrenFields = childrenFields;
            Name = name;
            Type = type;
            Doc = doc;
            DefaultValue = defaultValue;
            ComplexType = complexType;
            LogicalType = logicalType;
        }
    }
}
