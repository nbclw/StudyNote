using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbToExcelTool.Office
{
    public class OfficeExcelHelper : ExportExcelAbstract
    {
        private Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
        private Microsoft.Office.Interop.Excel.Workbook workbook = null;
        private Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
        private Microsoft.Office.Interop.Excel.Application excel = null;
        public OfficeExcelHelper(string fileName)
        {
            base.fileName = fileName;
            base.disposed = false;
        }

        public override void CreateSheet(string sheetName)
        {
            this.excel = new Microsoft.Office.Interop.Excel.Application();
            //设置为不可见，操作在后台执行，为 true 的话会打开 Excel
            excel.Visible = false;

            //打开时设置为全屏显式
            //excel.DisplayFullScreen = true;

            //初始化工作簿
            this.workbooks = excel.Workbooks;

            //新增加一个工作簿，Add（）方法也可以直接传入参数 true
            this.workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //同样是新增一个工作簿，但是会弹出保存对话框
            //Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Add(true);

            //新增加一个 Excel 表(sheet)
            this.worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

            //设置表的名称
            this.worksheet.Name = sheetName;
        }
        public override void SetColumnName(List<string> columnNames, int rowIndex)
        {
            rowIndex += 1;
            Microsoft.Office.Interop.Excel.Range range;
            for (int i = 0; i < columnNames.Count; i++)
            {
                //设置第一行，即列名
                worksheet.Cells[rowIndex, i + 1] = columnNames[i];
                //获取第一行的每个单元格
                range = worksheet.Cells[rowIndex, i + 1];
                //字体加粗
                range.Font.Bold = true;
                //设置为黑色
                range.Font.Color = 0;
                //设置为宋体
                range.Font.Name = "Arial";
                //设置字体大小
                range.Font.Size = 12;
                //水平居中
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //垂直居中
                range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            }
        }

        public override void SetRowValue(DataRow dataRow, int columnCount, int rowIndex)
        {
            rowIndex += 1;
            for (int j = 0; j < columnCount; j++)
            {
                worksheet.Cells[rowIndex, j + 1] = dataRow[j].ToString();
            }
        }

        public override void Save()
        {
            //设置所有列宽为自动列宽
            //worksheet.Columns.AutoFit();

            //设置所有单元格列宽为自动列宽
            //worksheet.Cells.Columns.AutoFit();
            //worksheet.Cells.EntireColumn.AutoFit();

            //是否提示，如果想删除某个sheet页，首先要将此项设为fasle。
            excel.DisplayAlerts = false;

            //保存写入的数据，这里还没有保存到磁盘
            workbook.Saved = true;

            //创建文件
            FileStream file = new FileStream(fileName, FileMode.Create);

            //关闭释放流，不然没办法写入数据
            file.Close();
            file.Dispose();

            //保存到指定的路径
            workbook.SaveCopyAs(fileName);
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
                    workbook.Close(false, Type.Missing, Type.Missing);
                    workbooks.Close();

                    //关闭退出
                    excel.Quit();

                    //释放 COM 对象
                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excel);

                    worksheet = null;
                    workbook = null;
                    workbooks = null;
                    excel = null;
                }

                base.disposed = true;
            }
        }
    }
}
