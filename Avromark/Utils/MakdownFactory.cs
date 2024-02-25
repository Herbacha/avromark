using Avromark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Avro;
using Avromark.Constants;
using Avromark.Enum;
using Avromark.Exceptions;

namespace Avromark.Utils
{
    public class MakdownFactory
    {
        private Configuration _configuration;

        private Dictionary<RenderedColumn, int> columnWidth = new Dictionary<RenderedColumn, int>();

        public MakdownFactory(Configuration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateMarkdown()
        {
            var markdown = new StringBuilder();

            string avroSchema = File.ReadAllText(_configuration.InputFileName);

            var jsonDoc = JsonDocument.Parse(avroSchema);

            var fields = jsonDoc.RootElement.GetProperty(AvroParserConstants.FIELDS_LABEL);

            columnWidth.Add(RenderedColumn.Path, RenderConstants.Columns.PATH.Length);
            columnWidth.Add(RenderedColumn.Name, RenderConstants.Columns.NAME.Length);
            columnWidth.Add(RenderedColumn.Type, RenderConstants.Columns.TYPE.Length);
            columnWidth.Add(RenderedColumn.Default, RenderConstants.Columns.DEFAULT.Length);
            columnWidth.Add(RenderedColumn.Doc, RenderConstants.Columns.DOC.Length);

            var lines = AvroParser.ArrayLinesFromAvroFields(fields);

            foreach(var line in lines)
            {
                MaximizeColumnLength(RenderedColumn.Path, RenderPath(line.ParentField));
                MaximizeColumnLength(RenderedColumn.Name, line.Name);
                MaximizeColumnLength(RenderedColumn.Type, line.Type);
                MaximizeColumnLength(RenderedColumn.Doc, line.Doc);
                MaximizeColumnLength(RenderedColumn.Default, line.DefaultValue);

            }

            var headers =
                $"| {RenderConstants.Columns.PATH.PadRight(columnWidth[RenderedColumn.Path])} " +
                $"| {RenderConstants.Columns.NAME.PadRight(columnWidth[RenderedColumn.Name])} " +
                $"| {RenderConstants.Columns.TYPE.PadRight(columnWidth[RenderedColumn.Type])} " +
                $"| {RenderConstants.Columns.DEFAULT.PadRight(columnWidth[RenderedColumn.Default])} " +
                $"| {RenderConstants.Columns.DOC.PadRight(columnWidth[RenderedColumn.Doc])} |" +
                Environment.NewLine +
                $"| {new string('-', columnWidth[RenderedColumn.Path])} " +
                $"| {new string('-', columnWidth[RenderedColumn.Name])} " +
                $"| {new string('-', columnWidth[RenderedColumn.Type])} " +
                $"| {new string('-', columnWidth[RenderedColumn.Default])} " +
                $"| {new string('-', columnWidth[RenderedColumn.Doc])} |";

            var renderedLines = new List<string>();

            foreach(var line in lines)
            {
                renderedLines.Add(
                    $"| {(line.ParentField == null ? "" : RenderPath(line.ParentField)).PadRight(columnWidth[RenderedColumn.Path])} " +
                    $"| {line.Name.PadRight(columnWidth[RenderedColumn.Name])} " +
                    $"| {line.Type.PadRight(columnWidth[RenderedColumn.Type])} " +
                    $"| {(line.DefaultValue != null ? line.DefaultValue : "" ).PadRight(columnWidth[RenderedColumn.Default])} " +
                    $"| {(line.Doc != null ? line.Doc : "").PadRight(columnWidth[RenderedColumn.Doc])} |"
                );
            }

            markdown.AppendJoin(Environment.NewLine, headers, string.Join(Environment.NewLine, renderedLines) );

            return markdown.ToString();
        }

        private string RenderPath(AvroField? parentField)
        {
            if (parentField != null)
                return RenderPath(parentField.ParentField) + " > " + parentField.Name;
            else
                return String.Empty;
        }

        private void MaximizeColumnLength(RenderedColumn columnName, string? cellContents)
        {
            if (cellContents != null && cellContents.Length > columnWidth[columnName])
                columnWidth[columnName] = cellContents.Length;
        }
    }
}
