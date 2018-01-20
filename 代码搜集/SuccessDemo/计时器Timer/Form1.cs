using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计时工具
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 计时器
        int time = 0;
        int i1 = 0, i2 = 0, i3 = 0, i4 = 0, i5 = 0, i6 = 0, i7 = 0, i8 = 0, i9 = 0, i10 = 0, i11 = 0, i12 = 0, i13 = 0, i14 = 0, i15 = 0, i16 = 0;
        #endregion

        private void label14_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl.Text=="刷新")
            {
                lbl.Text = "未知";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = Convert.ToInt32(ConfigurationManager.AppSettings["time"]);
            label1.Text = ConfigurationManager.AppSettings["moster1"];
            label2.Text = ConfigurationManager.AppSettings["moster2"];
            label3.Text = ConfigurationManager.AppSettings["moster3"];
            label4.Text = ConfigurationManager.AppSettings["moster4"];
            label5.Text = ConfigurationManager.AppSettings["moster5"];
            label6.Text = ConfigurationManager.AppSettings["moster6"];
            label7.Text = ConfigurationManager.AppSettings["moster7"];
            label8.Text = ConfigurationManager.AppSettings["moster8"];
            label9.Text = ConfigurationManager.AppSettings["moster9"];
            label10.Text = ConfigurationManager.AppSettings["moster10"];
            label11.Text = ConfigurationManager.AppSettings["moster11"];
            label12.Text = ConfigurationManager.AppSettings["moster12"];
            label13.Text = ConfigurationManager.AppSettings["moster13"];
            label14.Text = ConfigurationManager.AppSettings["moster14"];
            label15.Text = ConfigurationManager.AppSettings["moster15"];
            label16.Text = ConfigurationManager.AppSettings["moster16"];
        }

        #region timer

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i1 > -1)
            {
                label32.Text = (i1--).ToString();
            }
            else
            {
                label32.Text = "刷新";
                label1.Enabled = true;
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (i2 > -1)
            {
                label31.Text = (i2--).ToString();
            }
            else
            {
                label31.Text = "刷新";
                label2.Enabled = true;
                timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (i3 > -1)
            {
                label30.Text = (i3--).ToString();
            }
            else
            {
                label30.Text = "刷新";
                label3.Enabled = true;
                timer3.Stop();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (i4 > -1)
            {
                label29.Text = (i4--).ToString();
            }
            else
            {
                label29.Text = "刷新";
                label4.Enabled = true;
                timer4.Stop();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (i5 > -1)
            {
                label28.Text = (i5--).ToString();
            }
            else
            {
                label28.Text = "刷新";
                label5.Enabled = true;
                timer5.Stop();
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (i6 > -1)
            {
                label27.Text = (i6--).ToString();
            }
            else
            {
                label27.Text = "刷新";
                label6.Enabled = true;
                timer6.Stop();
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (i7 > -1)
            {
                label26.Text = (i7--).ToString();
            }
            else
            {
                label26.Text = "刷新";
                label7.Enabled = true;
                timer7.Stop();
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            if (i8 > -1)
            {
                label25.Text = (i8--).ToString();
            }
            else
            {
                label25.Text = "刷新";
                label8.Enabled = true;
                timer8.Stop();
            }
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (i9 > -1)
            {
                label24.Text = (i9--).ToString();
            }
            else
            {
                label24.Text = "刷新";
                label9.Enabled = true;
                timer9.Stop();
            }
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            if (i10 > -1)
            {
                label23.Text = (i10--).ToString();
            }
            else
            {
                label23.Text = "刷新";
                label10.Enabled = true;
                timer10.Stop();
            }
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            if (i11 > -1)
            {
                label22.Text = (i11--).ToString();
            }
            else
            {
                label22.Text = "刷新";
                label11.Enabled = true;
                timer11.Stop();
            }
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            if (i12 > -1)
            {
                label21.Text = (i12--).ToString();
            }
            else
            {
                label21.Text = "刷新";
                label12.Enabled = true;
                timer12.Stop();
            }
        }

        private void timer13_Tick(object sender, EventArgs e)
        {
            if (i13 > -1)
            {
                label20.Text = (i13--).ToString();
            }
            else
            {
                label20.Text = "刷新";
                label13.Enabled = true;
                timer13.Stop();
            }
        }

        private void timer14_Tick(object sender, EventArgs e)
        {
            if (i14 > -1)
            {
                label19.Text = (i14--).ToString();
            }
            else
            {
                label19.Text = "刷新";
                label14.Enabled = true;
                timer14.Stop();
            }
        }

        private void timer15_Tick(object sender, EventArgs e)
        {
            if (i15 > -1)
            {
                label18.Text = (i15--).ToString();
            }
            else
            {
                label18.Text = "刷新";
                label15.Enabled = true;
                timer15.Stop();
            }
        }

        private void timer16_Tick(object sender, EventArgs e)
        {
            if (i16 > -1)
            {
                label17.Text = (i16--).ToString();
            }
            else
            {
                label17.Text = "刷新";
                label16.Enabled = true;
                timer16.Stop();
            }
        }
        #endregion

        #region label
        private void label1_Click(object sender, EventArgs e)
        {
            i1 = time;
            label1.Enabled = false;
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            i2 = time;
            label2.Enabled = false;
            timer2.Interval = 1000;
            timer2.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            i3 = time;
            label3.Enabled = false;
            timer3.Interval = 1000;
            timer3.Start();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            i4 = time;
            label4.Enabled = false;
            timer4.Interval = 1000;
            timer4.Start();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            i5 = time;
            label5.Enabled = false;
            timer5.Interval = 1000;
            timer5.Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            i6 = time;
            label6.Enabled = false;
            timer6.Interval = 1000;
            timer6.Start();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            i7 = time;
            label7.Enabled = false;
            timer7.Interval = 1000;
            timer7.Start();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            i8 = time;
            label8.Enabled = false;
            timer8.Interval = 1000;
            timer8.Start();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            i9 = time;
            label9.Enabled = false;
            timer9.Interval = 1000;
            timer9.Start();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            i10 = time;
            label10.Enabled = false;
            timer10.Interval = 1000;
            timer10.Start();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            i11 = time;
            label11.Enabled = false;
            timer11.Interval = 1000;
            timer11.Start();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            i12 = time;
            label12.Enabled = false;
            timer12.Interval = 1000;
            timer12.Start();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            i13 = time;
            label13.Enabled = false;
            timer13.Interval = 1000;
            timer13.Start();
        }

        private void label14_Click_1(object sender, EventArgs e)
        {
            i14 = time;
            label14.Enabled = false;
            timer14.Interval = 1000;
            timer14.Start();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            i15 = time;
            label15.Enabled = false;
            timer15.Interval = 1000;
            timer15.Start();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            i16 = time;
            label16.Enabled = false;
            timer16.Interval = 1000;
            timer16.Start();
        }
        #endregion

    }
}
