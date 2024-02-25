using Avromark.Enum;
using Avromark.Exceptions;
using Avromark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avromark.Utils
{
    public class AvroFieldBuilder
    {
        private AvroField? _parentField;
        private string? _name;
        private string? _type;
        private string? _defaultValue;
        private string? _doc;

        private AvroComplexType? _complexType;
        private AvroLogicalType? _logicalType;
        private IEnumerable<AvroField>? _childrenFields;

        public AvroField Build()
        {
            if (_name != null && _type != null)
                return new AvroField(_parentField, _childrenFields, _name, _type, _doc, _defaultValue, _complexType, _logicalType);
            
            throw new AvroFormatErrorException();
        }

        public AvroFieldBuilder AddName(string name)
        {
            _name = name;
            return this;
        }
        public AvroFieldBuilder AddDefault(string defaultValue)
        {
            _defaultValue = defaultValue;
            return this;
        }
        public AvroFieldBuilder AddType(string type)
        {
            _type = type;
            return this;
        }
        public AvroFieldBuilder AddDoc(string doc)
        {
            _doc = doc;
            return this;
        }
        public AvroFieldBuilder AddParent(AvroField parentField)
        {
            _parentField = parentField;
            return this;
        }
        public AvroFieldBuilder AddComplexType(AvroComplexType complexType)
        {
            _complexType = complexType;
            return this;
        }
        public AvroFieldBuilder AddLogicalType(AvroLogicalType logicalType)
        {
            _logicalType = logicalType;
            return this;
        }
        public AvroFieldBuilder AddChildren(IEnumerable<AvroField> childrenFields)
        {
            _childrenFields = childrenFields;
            return this;
        }
    }
}
