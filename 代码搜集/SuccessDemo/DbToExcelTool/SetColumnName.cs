using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbToExcelTool
{
    public partial class SetColumnName : Form
    {
        public SetColumnName()
        {
            InitializeComponent();
        }
        public SetColumnName(Dictionary<string, string> columnNames)
        {
            InitializeComponent();
            this._columnNames = columnNames;
        }
        private Dictionary<string, string> _columnNames = null;
        private DataTable _dtName = new DataTable();

        private void SetColumnName_Load(object sender, EventArgs e)
        {
            if (_columnNames != null)
            {
                //this.dgvColumnNames.DataSource = (from v in _columnNames
                //                                  select new
                //                                  {
                //                                      source = v.Key,
                //                                      target = v.Value
                //                                  }).ToArray();
                //this.dgvColumnNames.ReadOnly = false;
                _dtName.Columns.Add(new DataColumn("原始名称"));
                _dtName.Columns.Add(new DataColumn("导出名称"));
                foreach (var kvp in _columnNames)
                {
                    DataRow row = _dtName.NewRow();
                    row["原始名称"] = kvp.Key;
                    row["导出名称"] = kvp.Value;
                    _dtName.Rows.Add(row);
                }

                this.dgvColumnNames.DataSource = _dtName;
                this.dgvColumnNames.ReadOnly = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_columnNames != null)
            {
                foreach (DataGridViewRow row in dgvColumnNames.Rows)
                {
                    string key = row.Cells["原始名称"].Value.ToString();
                    if (_columnNames.ContainsKey(key))
                        _columnNames[key] = row.Cells["导出名称"].Value.ToString();
                }
            }

            this.Close();
        }

        private void dgvColumnNames_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvColumnNames.Rows.Count == 0 || e.ColumnIndex == 0)
            {
                e.Cancel = true;
            }
        }
    }
}
