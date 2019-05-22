using System.Collections.Generic;
using System.Data;

namespace DbToExcelTool
{
    public abstract class ExportExcelAbstract
    {
        protected string fileName = null; //文件名
        protected bool disposed;

        public abstract void CreateSheet(string sheetName);

        public abstract void SetColumnName(List<string> columnNames, int rowIndex);

        public abstract void SetRowValue(DataRow dataRow, int columnCount, int rowIndex);

        public abstract void Save();

        public abstract void Dispose();
    }
}
