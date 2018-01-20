using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MouseAutoClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, Keys.F4); //注册
        }

        //注册全局热键
        class HotKey
        {
            //以下方法用于注册热键 
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(IntPtr hWnd, int Id, KeyModifiers fsModifiers, Keys vk);
            //以下方法用于注销热键 
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
            public enum KeyModifiers
            {
                None = 0,
                Alt = 1,
                Ctrl = 2,
                Shift = 4,
                WindowKey = 8,
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键    
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:
                            if (timer1.Enabled)
                            {
                                StopClick();
                            }
                            else
                            {
                                StartClick();
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }  

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标    
  

        private bool _isAuto = true;
        private int _mouseDown = MOUSEEVENTF_LEFTDOWN;
        private int _mouseUp = MOUSEEVENTF_LEFTUP;

        private void StartClick()
        {
            SetComboBoxEnabled(false);
            timer1.Enabled = true;
        }

        private void StopClick()
        {
            timer1.Enabled = false;
            SetComboBoxEnabled(true);
        }

        private void SetComboBoxEnabled(bool state)
        {
            comboBox1.Enabled = state;
            comboBox2.Enabled = state;
            comboBox3.Enabled = state;
            comboBox4.Enabled = state;
        }

        private void MouseEvent()
        {
            mouse_event(_mouseDown | _mouseUp, Cursor.Position.X, Cursor.Position.Y, 0, 0);       
        }



        /// <summary>
        /// 最小化托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        /// <summary>
        /// 双击还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Show();
            this.Activate();
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 点击还原按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Show();
            this.Activate();
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 点击退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotKey.UnregisterHotKey(Handle, 100);
            Application.Exit();
        }

        /// <summary>
        /// 时间间隔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse((timer1.Interval * Convert.ToDouble(comboBox1.Text)).ToString());
        }

        /// <summary>
        /// 是什么鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "左击")
            {
                _mouseDown = MOUSEEVENTF_LEFTDOWN;
                _mouseUp = MOUSEEVENTF_LEFTUP;
            }
            else if (comboBox4.Text == "右击")
            {
                _mouseDown = MOUSEEVENTF_RIGHTDOWN;
                _mouseUp = MOUSEEVENTF_RIGHTUP;
            }
            else
            {
                _mouseDown = MOUSEEVENTF_MIDDLEDOWN;
                _mouseUp = MOUSEEVENTF_MIDDLEUP;
            }
        }

        /// <summary>
        /// 决定启动热键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 是否连续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "连续")
            {
                _isAuto = true;
            }
            else
            {
                _isAuto = false;
            }
        }

        /// <summary>
        /// 开始连点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!_isAuto) 
            {
                StopClick();
            }
            MouseEvent();
        }
    }
}
