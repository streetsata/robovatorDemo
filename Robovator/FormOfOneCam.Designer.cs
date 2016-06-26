namespace Robovator1._3
{
    partial class FormOfOneCam
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOfOneCam));
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.BtnConnetct = new System.Windows.Forms.Button();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.videoSourcePlayer2 = new AForge.Controls.VideoSourcePlayer();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.btnToTalePicture = new System.Windows.Forms.Button();
            this.RadiusTrackBar = new System.Windows.Forms.TrackBar();
            this.labelRadiusNum = new System.Windows.Forms.Label();
            this.labelCountOfObjects = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            resources.ApplyResources(this.videoSourcePlayer1, "videoSourcePlayer1");
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame_1);
            // 
            // BtnConnetct
            // 
            resources.ApplyResources(this.BtnConnetct, "BtnConnetct");
            this.BtnConnetct.Name = "BtnConnetct";
            this.BtnConnetct.UseVisualStyleBackColor = true;
            this.BtnConnetct.Click += new System.EventHandler(this.BtnConnetct_Click);
            // 
            // comboBoxDevices
            // 
            resources.ApplyResources(this.comboBoxDevices, "comboBoxDevices");
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Name = "comboBoxDevices";
            // 
            // videoSourcePlayer2
            // 
            resources.ApplyResources(this.videoSourcePlayer2, "videoSourcePlayer2");
            this.videoSourcePlayer2.Name = "videoSourcePlayer2";
            this.videoSourcePlayer2.VideoSource = null;
            this.videoSourcePlayer2.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer2_NewFrame);
            // 
            // BtnDisconnect
            // 
            resources.ApplyResources(this.BtnDisconnect, "BtnDisconnect");
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // btnToTalePicture
            // 
            resources.ApplyResources(this.btnToTalePicture, "btnToTalePicture");
            this.btnToTalePicture.Name = "btnToTalePicture";
            this.btnToTalePicture.UseVisualStyleBackColor = true;
            this.btnToTalePicture.Click += new System.EventHandler(this.btnToTalePicture_Click);
            // 
            // RadiusTrackBar
            // 
            resources.ApplyResources(this.RadiusTrackBar, "RadiusTrackBar");
            this.RadiusTrackBar.Maximum = 450;
            this.RadiusTrackBar.Name = "RadiusTrackBar";
            this.RadiusTrackBar.Scroll += new System.EventHandler(this.RadiusTrackBar_Scroll);
            // 
            // labelRadiusNum
            // 
            resources.ApplyResources(this.labelRadiusNum, "labelRadiusNum");
            this.labelRadiusNum.Name = "labelRadiusNum";
            // 
            // labelCountOfObjects
            // 
            resources.ApplyResources(this.labelCountOfObjects, "labelCountOfObjects");
            this.labelCountOfObjects.Name = "labelCountOfObjects";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // FormOfOneCam
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCountOfObjects);
            this.Controls.Add(this.labelRadiusNum);
            this.Controls.Add(this.RadiusTrackBar);
            this.Controls.Add(this.btnToTalePicture);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.videoSourcePlayer2);
            this.Controls.Add(this.comboBoxDevices);
            this.Controls.Add(this.BtnConnetct);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Name = "FormOfOneCam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOfOneCam_FormClosing);
            this.Load += new System.EventHandler(this.FormOfOneCam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RadiusTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Button BtnConnetct;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer2;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.Button btnToTalePicture;
        private System.Windows.Forms.TrackBar RadiusTrackBar;
        private System.Windows.Forms.Label labelRadiusNum;
        private System.Windows.Forms.Label labelCountOfObjects;
        private System.Windows.Forms.Label label1;

    }
}

