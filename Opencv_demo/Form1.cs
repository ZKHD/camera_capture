using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp; 

namespace Opencv_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoCapture cap1 = new VideoCapture(new CaptureDevice(), 1);//(1, 0);
            VideoCapture cap2 = new VideoCapture(new CaptureDevice(), 0);//(1, 0);


        

        }
    }
}
