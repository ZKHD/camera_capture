namespace AforgeDemo
{
    partial class FormShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PicVideoShow = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PicVideoShow)).BeginInit();
            this.SuspendLayout();
            // 
            // PicVideoShow
            // 
            this.PicVideoShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicVideoShow.Location = new System.Drawing.Point(0, 0);
            this.PicVideoShow.Name = "PicVideoShow";
            this.PicVideoShow.Size = new System.Drawing.Size(699, 514);
            this.PicVideoShow.TabIndex = 0;
            this.PicVideoShow.TabStop = false;
            this.PicVideoShow.Paint += new System.Windows.Forms.PaintEventHandler(this.PicVideoShow_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormShow
            // 
            this.ClientSize = new System.Drawing.Size(699, 514);
            this.Controls.Add(this.PicVideoShow);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShow";
            this.Text = "Shown";
            ((System.ComponentModel.ISupportInitialize)(this.PicVideoShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PicVideoShow;
        private System.Windows.Forms.Timer timer1;
    }
}