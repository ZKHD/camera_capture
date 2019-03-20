using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AforgeDemo
{
    public partial class FormShow : Form
    {
        public FormShow()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void PicVideoShow_Paint(object sender, PaintEventArgs e)
        {
            if ( FormMain.bmp == null) return;
            lock (FormMain.bmp)
            {
                e.Graphics.DrawImage(FormMain.bmp, 0, 0);

                if (FormMain.bmp.Height > 32)
                { 
                this.Height = FormMain.bmp.Height;
                this.Width = FormMain.bmp.Width;

                }
            }
            //if(this.Height>100)
            //    this.WindowState = FormWindowState.Normal;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            //this.WindowState = FormWindowState.Normal;

        }
    }
}
