using DbToExcelTool.Db;
using DbToExcelTool.NPOI;
using DbToExcelTool.Office;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbToExcelTool
{
    public partial class ToolMain : Form
    {
        public ToolMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        #region private

        private DataTable _selectValue = new DataTable();
        private Dictionary<string, string> _columnNames = new Dictionary<string, string>();

        private void IsCanOperate()
        {
            bool b = !string.IsNullOrEmpty(StaticUnit.DB_CONNECT);
            IsCanOperate(b);
        }

        private void ClearSelectValue()
        {
            this.dgvSelectValue.DataSource = null;
            this._selectValue.Clear();
            this._columnNames.Clear();
            this.lblSelectCount.Text = "查询数量：" + _selectValue.Rows.Count;
            this.lblProcess.Text = "进度：0/0";
        }

        private void IsCanOperate(bool b)
        {
            this.btnCommandSql.Enabled = b;
            this.btnExportExcel.Enabled = b;
            this.btnOfficeExport.Enabled = b;
            this.rtbSql.Enabled = b;
        }

        private void NPOIExport(string fileName, string shortName, List<string> columnNames)
        {
            NPOIExcelHelper excelHelper = new NPOIExcelHelper(fileName);

            ExportToExcel(fileName, shortName, columnNames, excelHelper);
        }

        private void OfficeExport(string fileName, string shortName, List<string> columnNames)
        {
            if (!fileName.EndsWith(".xlsx"))
            {
                fileName += ".xlsx";
            }
            OfficeExcelHelper excelHelper = new OfficeExcelHelper(fileName);

            ExportToExcel(fileName, shortName, columnNames, excelHelper);
        }

        private void ExportToExcel(string fileName, string shortName, List<string> columnNames, ExportExcelAbstract excelHelper)
        {
            try
            {
                int rowCount = _selectValue.Rows.Count;
                int columnCount = _selectValue.Columns.Count;

                excelHelper.CreateSheet(shortName);
                excelHelper.SetColumnName(columnNames, 0);
                int addColumnCount = 1;

                for (int i = 0; i < rowCount; i++)
                {
                    excelHelper.SetRowValue(_selectValue.Rows[i], columnCount, i + addColumnCount);
                    this.lblProcess.Text = string.Format("进度：{0}/{1}", i, rowCount);
                }

                excelHelper.Save();
                MessageBox.Show("success");
                ClearSelectValue();
            }
            catch (Exception ex)
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
                MessageBox.Show("export error:" + ex.Message);
            }
            finally
            {
                excelHelper.Dispose();
                IsCanOperate(true);
            }
        }

        private string ChoseSavePath()
        {
            string fileName = string.Empty;
            if (_selectValue.Rows.Count == 0)
            {
                MessageBox.Show("无数据");
                IsCanOperate(true);
                return fileName;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xls文件(*.xls)|*.xls|xlsx文件(*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
            else
                IsCanOperate(true);
            return fileName;
        }

        private void OpenSetColumnNameForm()
        {
            foreach (DataColumn column in _selectValue.Columns)
            {
                if (!_columnNames.ContainsKey(column.ColumnName))
                    _columnNames.Add(column.ColumnName, column.ColumnName);
            }
            SetColumnName formSetName = new SetColumnName(_columnNames);
            formSetName.ShowDialog();
        }

        private void CommonExport(Action<string, string, List<string>> action)
        {
            IsCanOperate(false);
            string fileName = ChoseSavePath();
            if (string.IsNullOrEmpty(fileName)) return;
            string shortName = fileName.Split('\\').LastOrDefault().Split('.').FirstOrDefault();
            OpenSetColumnNameForm();
            List<string> columnNames = new List<string>(_selectValue.Columns.Count);
            foreach (DataColumn column in _selectValue.Columns)
            {
                columnNames.Add(_columnNames.ContainsKey(column.ColumnName) ? _columnNames[column.ColumnName] : column.ColumnName);
            }

            Task.Factory.StartNew(() => action.Invoke(fileName, shortName, columnNames));
        }
        #endregion

        private void ToolMain_Load(object sender, EventArgs e)
        {
            IsCanOperate();
        }

        private void btnConnDB_Click(object sender, EventArgs e)
        {
            BuildDBConnect buildDBConnect = new BuildDBConnect();
            if (buildDBConnect.ShowDialog() == DialogResult.OK)
            {
                IsCanOperate();
            }
        }

        private void btnCommandSql_Click(object sender, EventArgs e)
        {
            IsCanOperate(false);
            string sqlStr = this.rtbSql.Text.Trim();

            try
            {
                _selectValue = SqlServerHelper.ExecuteDataTable(sqlStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("sql error:" + ex.Message);
            }

            this.dgvSelectValue.DataSource = _selectValue;
            this.lblSelectCount.Text = "查询数量：" + _selectValue.Rows.Count;

            IsCanOperate(true);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Action<string, string, List<string>> action = new Action<string, string, List<string>>(NPOIExport);
            CommonExport(action);
        }

        private void btnOfficeExport_Click(object sender, EventArgs e)
        {
            Action<string, string, List<string>> action = new Action<string, string, List<string>>(OfficeExport);
            CommonExport(action);
        }
    }
}
