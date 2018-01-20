using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string baseStrBmp = textBox1.Text;
            if (!string.IsNullOrEmpty(baseStrBmp.Trim()))
            {
                byte[] strBmp = Convert.FromBase64String(baseStrBmp);
                MemoryStream memStream = new MemoryStream(strBmp);
                BinaryFormatter binFormatter = new BinaryFormatter();
                Image img = (Image)binFormatter.Deserialize(memStream);
                pictureBox1.Image = img;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片文件|*.jpg;*.bmp";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
                Bitmap bmp = new Bitmap(fName);
                BinaryFormatter binFormatter = new BinaryFormatter();
                MemoryStream memStream = new MemoryStream();
                binFormatter.Serialize(memStream, bmp);
                byte[] bytes = memStream.GetBuffer();
                memStream.Close();
                string base64 = Convert.ToBase64String(bytes);
                textBox1.Text = base64;
            }
        }
    }
}
