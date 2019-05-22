namespace DbToExcelTool
{
    partial class ToolMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rtbSql = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblSelectCount = new System.Windows.Forms.Label();
            this.btnCommandSql = new System.Windows.Forms.Button();
            this.btnConnDB = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblProcess = new System.Windows.Forms.Label();
            this.btnOfficeExport = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvSelectValue = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectValue)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 125);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rtbSql);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(943, 125);
            this.panel4.TabIndex = 0;
            // 
            // rtbSql
            // 
            this.rtbSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSql.Location = new System.Drawing.Point(0, 0);
            this.rtbSql.Name = "rtbSql";
            this.rtbSql.Size = new System.Drawing.Size(943, 125);
            this.rtbSql.TabIndex = 0;
            this.rtbSql.Text = "";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblSelectCount);
            this.panel5.Controls.Add(this.btnCommandSql);
            this.panel5.Controls.Add(this.btnConnDB);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(943, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 125);
            this.panel5.TabIndex = 1;
            // 
            // lblSelectCount
            // 
            this.lblSelectCount.AutoSize = true;
            this.lblSelectCount.Location = new System.Drawing.Point(19, 101);
            this.lblSelectCount.Name = "lblSelectCount";
            this.lblSelectCount.Size = new System.Drawing.Size(71, 12);
            this.lblSelectCount.TabIndex = 2;
            this.lblSelectCount.Text = "查询数量：0";
            // 
            // btnCommandSql
            // 
            this.btnCommandSql.Location = new System.Drawing.Point(65, 75);
            this.btnCommandSql.Name = "btnCommandSql";
            this.btnCommandSql.Size = new System.Drawing.Size(75, 23);
            this.btnCommandSql.TabIndex = 1;
            this.btnCommandSql.Text = "执行语句";
            this.btnCommandSql.UseVisualStyleBackColor = true;
            this.btnCommandSql.Click += new System.EventHandler(this.btnCommandSql_Click);
            // 
            // btnConnDB
            // 
            this.btnConnDB.Location = new System.Drawing.Point(65, 24);
            this.btnConnDB.Name = "btnConnDB";
            this.btnConnDB.Size = new System.Drawing.Size(75, 23);
            this.btnConnDB.TabIndex = 0;
            this.btnConnDB.Text = "数据库连接";
            this.btnConnDB.UseVisualStyleBackColor = true;
            this.btnConnDB.Click += new System.EventHandler(this.btnConnDB_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblProcess);
            this.panel2.Controls.Add(this.btnOfficeExport);
            this.panel2.Controls.Add(this.btnExportExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(943, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 429);
            this.panel2.TabIndex = 1;
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(19, 114);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(47, 12);
            this.lblProcess.TabIndex = 2;
            this.lblProcess.Text = "进度：/";
            // 
            // btnOfficeExport
            // 
            this.btnOfficeExport.Location = new System.Drawing.Point(65, 74);
            this.btnOfficeExport.Name = "btnOfficeExport";
            this.btnOfficeExport.Size = new System.Drawing.Size(75, 23);
            this.btnOfficeExport.TabIndex = 1;
            this.btnOfficeExport.Text = "导出(OFF)";
            this.btnOfficeExport.UseVisualStyleBackColor = true;
            this.btnOfficeExport.Click += new System.EventHandler(this.btnOfficeExport_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(65, 30);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 0;
            this.btnExportExcel.Text = "导出(NPOI)";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvSelectValue);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(943, 429);
            this.panel3.TabIndex = 2;
            // 
            // dgvSelectValue
            // 
            this.dgvSelectValue.AllowUserToAddRows = false;
            this.dgvSelectValue.AllowUserToDeleteRows = false;
            this.dgvSelectValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelectValue.Location = new System.Drawing.Point(0, 0);
            this.dgvSelectValue.Name = "dgvSelectValue";
            this.dgvSelectValue.ReadOnly = true;
            this.dgvSelectValue.RowTemplate.Height = 23;
            this.dgvSelectValue.Size = new System.Drawing.Size(943, 429);
            this.dgvSelectValue.TabIndex = 0;
            // 
            // ToolMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 554);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DbToExcelTool";
            this.Load += new System.EventHandler(this.ToolMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtbSql;
        private System.Windows.Forms.Button btnCommandSql;
        private System.Windows.Forms.Button btnConnDB;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvSelectValue;
        private System.Windows.Forms.Button btnOfficeExport;
        private System.Windows.Forms.Label lblSelectCount;
        private System.Windows.Forms.Label lblProcess;
    }
}

