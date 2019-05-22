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
    public partial class BuildDBConnect : Form
    {
        public BuildDBConnect()
        {
            InitializeComponent();
        }

        private void btnSetDBConn_Click(object sender, EventArgs e)
        {
            string server = this.txtServer.Text.Trim();
            string database = this.txtDatabase.Text.Trim();
            string uid = this.txtUID.Text.Trim();
            string pwd = this.txtPwd.Text.Trim();

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("存在未填写项");
                return;
            }

            StaticUnit.DB_CONNECT = string.Format("server={0};database={1};uid={2};password={3}", server, database, uid, pwd);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
