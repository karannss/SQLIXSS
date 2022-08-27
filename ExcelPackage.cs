using System.IO;

namespace WebApplication4
{
    internal class ExcelPackage
    {
        private Stream inputStream;

        public ExcelPackage(Stream inputStream)
        {
            this.inputStream = inputStream;
        }

        public object Workbook { get; internal set; }
    }
}