using System;
namespace Application.Models.Export
{
    public class ExcelFile : BaseExportFile
    {
        private const string NAME = "orders";
        private const string TYPE = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private const string EXTENSION = "xlsx";

        public string NameFile => $"{NAME}.{EXTENSION}";

        public ExcelFile(byte[] content)
                : base(fileName: NAME, contentType: TYPE, content: content, extension: EXTENSION)
        {
        }
    }
}
