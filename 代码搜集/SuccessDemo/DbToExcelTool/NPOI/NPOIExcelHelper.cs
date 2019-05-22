using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace DbToExcelTool.NPOI
{
    public class NPOIExcelHelper : ExportExcelAbstract
    {
        private IWorkbook workbook = null;
        private ISheet sheet = null;
        private FileStream fs = null;

        public NPOIExcelHelper(string fileName)
        {
            base.fileName = fileName;
            base.disposed = false;
        }
        public override void CreateSheet(string sheetName)
        {
            if (string.IsNullOrEmpty(sheetName)) sheetName = "sheet";
            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            if (workbook != null)
            {
                sheet = workbook.CreateSheet(sheetName);
            }
        }

        public override void SetColumnName(List<string> columnNames, int rowIndex)
        {
            IRow row = sheet.CreateRow(rowIndex);
            for (int i = 0; i < columnNames.Count; i++)
            {
                row.CreateCell(i).SetCellValue(columnNames[i]);
            }
        }

        public override void SetRowValue(DataRow dataRow, int columnCount, int rowIndex)
        {
            IRow row = sheet.CreateRow(rowIndex);
            for (int i = 0; i < columnCount; i++)
            {
                row.CreateCell(i).SetCellValue(dataRow[i].ToString());
            }
        }

        public override void Save()
        {
            workbook.Write(fs); //写入到excel
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!base.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                base.disposed = true;
            }
        }
    }
}
