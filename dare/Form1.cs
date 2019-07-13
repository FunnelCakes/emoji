using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Security.AccessControl;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            System.Drawing.Image imgSrc = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));

            using (Graphics g = Graphics.FromImage(imgSrc))
        {
            g.DrawImage(imgSrc, 0, 0, imgSrc.Width, imgSrc.Height);
            using (Font f = new Font("宋体",125,FontStyle.Bold))
            {

                    using (Brush b = new SolidBrush(Color.Red))
                    {
                        string addText = "真不敢" + textBox1.Text + "么";
                        int num =( (int)addText.Length / 6 )+ 1;
                        string[] part = new string[num];
                        Graphics GRA = this.CreateGraphics();
                        for (int i = 0; i < num; i++)
                        {
                            try
                            {
                                part[i] = addText.Substring(6 * i,6);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                try
                                {
                                    part[i] = addText.Substring(6 * i, addText.Length - 6 * i);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Debug.WriteLine("addtext达到了6的整数倍");
                                }
                            }
                            finally
                            {
                                SizeF size = GRA.MeasureString(part[i], new Font("宋体", 125, FontStyle.Bold));
                                g.DrawString(part[i], f, b, (imgSrc.Width - size.Width) / 2, 360 + (size.Height + 50) * i);
                            }
                        }
                    }
            }
        }
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            imgSrc.Save(dir+"//表情包.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void enter(object sender, KeyEventArgs e)
        {

        }
    }
}
