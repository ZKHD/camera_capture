using AForge;
using AForge.Video;
using AForge.Controls;
using AForge.Fuzzy;
using AForge.Genetic;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AforgeDemo
{
	public partial class FormMain : Form
	{
        public int index = 0 ; 

		//用来操作摄像头 
		private VideoCaptureDevice Camera = null;

        //图像缓存
        static public Bitmap bmp = new Bitmap(1, 1);

        //用来把每一帧图像编码到视频文件
        private VideoFileWriter VideoOutPut = new VideoFileWriter();

		public FormMain()
		{
			InitializeComponent();
		}

	
		
		////摄像头输出回调
		private void Camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			//写到文件
			VideoOutPut.WriteVideoFrame(eventArgs.Frame);
			lock (bmp)
			{
				//释放上一个缓存
				bmp.Dispose();
				//保存一份缓存
				bmp = eventArgs.Frame.Clone() as Bitmap;
			}
		}

  
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_path.Text = fbd.SelectedPath;
            }

            if (tb_path.Text.Trim() == "")
            {
                tb_path.Text = @".\";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormShow fm_shown = new FormShow();
            //fm_shown.WindowState = FormWindowState.Maximized;
            fm_shown.Show();

            if (button2.Text == "启动采集显示")
            {
                button2.BackColor = Color.LightGreen;
                button2.Text = "启动显示";
                button2.Refresh();

                if (Camera == null)
                {


                    //获取摄像头列表
                    var devs = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    if (devs.Count < 1)
                    {
                        MessageBox.Show("没有找到摄像设备！！请检查硬件！");
                        return;
                    }

                    //实例化设备控制类
                    Camera = new VideoCaptureDevice(devs[index].MonikerString);

                    //配置录像参数(宽,高,帧率,比特率,等)
                    Camera.VideoResolution = Camera.VideoCapabilities[0];

                    //设置回调,aforge会不断从这个回调推出图像数据
                    Camera.NewFrame += Camera_NewFrame;
                    VideoCapabilities[] vc = Camera.VideoCapabilities;


                    //开始
                    Camera.Start();

                    //打开录像文件(如果没有则创建,如果有则会清空).
                    tb_path.Text.TrimEnd();
                    if (tb_path.Text.EndsWith("\\"))
                    {
                        tb_path.Text += "VIDEO.MP4";
                    }
                   
                    else {
                        tb_path.Text += "\\VIDEO.MP4";
                    }


                    VideoOutPut.Open(tb_path.Text, Camera.VideoResolution.FrameSize.Width, Camera.VideoResolution.FrameSize.Height, Camera.VideoResolution.AverageFrameRate, VideoCodec.MPEG4, Camera.VideoResolution.BitCount);
                }
            }
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMain_Shown(object sender, EventArgs e)
        {

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停摄像头
            if (Camera != null)
            {
                Camera.Stop();
            }

            //关闭录像文件,如果忘了不关闭,将会得到一个损坏的文件,无法播放
            if (VideoOutPut != null)
            {
                VideoOutPut.Close();
            }
        }
    }
}
