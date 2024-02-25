using Avromark.Constants;
using Avromark.Enum;
using Avromark.Exceptions;
using Avromark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Avromark.Utils
{
    public static class AvroParser
    {
        public static List<AvroField> ArrayLinesFromAvroFields(JsonElement jsonElement, AvroField? parent = null)
        {
            var fieldBuilder = new AvroFieldBuilder();

            var arrayLines = new List<AvroField>();

            var arrayEnumerator = jsonElement.EnumerateArray();
            foreach (var field in arrayEnumerator)
            {
                var builder = new AvroFieldBuilder();

                if (field.GetProperty(AvroParserConstants.NAME_LABEL).GetString() is not string fieldName)
                    throw new AvroFormatErrorException();


                if (parent != null)
                    builder.AddParent(parent);
                //MaximizeColumnLength(RenderedColumn.Path, fieldPath);

                builder.AddName(fieldName);

                var fieldTypeElement = field.GetProperty(AvroParserConstants.TYPE_LABEL);

                var detailedFieldType = AnalyzeTypeElement(fieldTypeElement);

                var fieldType = detailedFieldType.ReadableType;

                builder.AddType(fieldType);

                if (field.TryGetProperty(AvroParserConstants.DOC_LABEL, out var fieldDoc))
                    builder.AddDoc(fieldDoc.ToString());

                if (field.TryGetProperty(AvroParserConstants.DEFAULT_LABEL, out var defaultProperty))
                    builder.AddDefault(defaultProperty.ToString());

                if (parent != null)
                    builder.AddParent(parent);

                var currentField = builder.Build();

                if (detailedFieldType.ComplexType == AvroComplexType.Record)
                {
                    var recordFields = fieldTypeElement.GetProperty(AvroParserConstants.FIELDS_LABEL);
                    arrayLines.AddRange(ArrayLinesFromAvroFields(recordFields, currentField));
                }

                arrayLines.Add(currentField);
            }

            return arrayLines;
        }

        private static AvroTypeDetails AnalyzeTypeElement(JsonElement fieldTypeElement)
        {
            if (fieldTypeElement.ValueKind == JsonValueKind.String)
                return new AvroTypeDetails(fieldTypeElement.GetString() ?? fieldTypeElement.GetRawText());

            if (fieldTypeElement.ValueKind == JsonValueKind.Array && fieldTypeElement.EnumerateArray() is JsonElement.ArrayEnumerator enumerate)
            {
                return new AvroTypeDetails(string.Join(RenderConstants.EscapedTypeSeparator, enumerate), AvroComplexType.Union);
            }

            if (fieldTypeElement.ValueKind == JsonValueKind.Object)
                return new AvroTypeDetails(AvroParserConstants.TYPE_RECORD_LABEL, AvroComplexType.Record);

            return new AvroTypeDetails(fieldTypeElement.GetRawText());
        }

    }
}
