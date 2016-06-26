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
            this.numericUpDownMinHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMinWith = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinWith)).BeginInit();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(12, 54);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(322, 242);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame_1);
            this.videoSourcePlayer1.Click += new System.EventHandler(this.videoSourcePlayer1_Click);
            // 
            // BtnConnetct
            // 
            this.BtnConnetct.Location = new System.Drawing.Point(139, 12);
            this.BtnConnetct.Name = "BtnConnetct";
            this.BtnConnetct.Size = new System.Drawing.Size(75, 23);
            this.BtnConnetct.TabIndex = 1;
            this.BtnConnetct.Text = "Connect";
            this.BtnConnetct.UseVisualStyleBackColor = true;
            this.BtnConnetct.Click += new System.EventHandler(this.BtnConnetct_Click);
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(12, 12);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDevices.TabIndex = 2;
            // 
            // videoSourcePlayer2
            // 
            this.videoSourcePlayer2.Location = new System.Drawing.Point(340, 54);
            this.videoSourcePlayer2.Name = "videoSourcePlayer2";
            this.videoSourcePlayer2.Size = new System.Drawing.Size(322, 242);
            this.videoSourcePlayer2.TabIndex = 3;
            this.videoSourcePlayer2.Text = "videoSourcePlayer2";
            this.videoSourcePlayer2.VideoSource = null;
            this.videoSourcePlayer2.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer2_NewFrame);
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Location = new System.Drawing.Point(220, 12);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.BtnDisconnect.TabIndex = 4;
            this.BtnDisconnect.Text = "Disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // btnToTalePicture
            // 
            this.btnToTalePicture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnToTalePicture.Location = new System.Drawing.Point(340, 12);
            this.btnToTalePicture.Name = "btnToTalePicture";
            this.btnToTalePicture.Size = new System.Drawing.Size(101, 23);
            this.btnToTalePicture.TabIndex = 5;
            this.btnToTalePicture.Text = "To take a picture";
            this.btnToTalePicture.UseVisualStyleBackColor = true;
            this.btnToTalePicture.Click += new System.EventHandler(this.btnToTalePicture_Click);
            // 
            // RadiusTrackBar
            // 
            this.RadiusTrackBar.Location = new System.Drawing.Point(340, 302);
            this.RadiusTrackBar.Maximum = 450;
            this.RadiusTrackBar.Name = "RadiusTrackBar";
            this.RadiusTrackBar.Size = new System.Drawing.Size(322, 45);
            this.RadiusTrackBar.TabIndex = 6;
            this.RadiusTrackBar.Scroll += new System.EventHandler(this.RadiusTrackBar_Scroll);
            // 
            // labelRadiusNum
            // 
            this.labelRadiusNum.AutoSize = true;
            this.labelRadiusNum.Location = new System.Drawing.Point(668, 314);
            this.labelRadiusNum.Name = "labelRadiusNum";
            this.labelRadiusNum.Size = new System.Drawing.Size(0, 13);
            this.labelRadiusNum.TabIndex = 7;
            // 
            // labelCountOfObjects
            // 
            this.labelCountOfObjects.AutoSize = true;
            this.labelCountOfObjects.Location = new System.Drawing.Point(17, 299);
            this.labelCountOfObjects.Name = "labelCountOfObjects";
            this.labelCountOfObjects.Size = new System.Drawing.Size(0, 13);
            this.labelCountOfObjects.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Radius";
            // 
            // numericUpDownMinHeight
            // 
            this.numericUpDownMinHeight.Location = new System.Drawing.Point(668, 276);
            this.numericUpDownMinHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownMinHeight.Name = "numericUpDownMinHeight";
            this.numericUpDownMinHeight.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownMinHeight.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(668, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Min With";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Min Height";
            // 
            // numericUpDownMinWith
            // 
            this.numericUpDownMinWith.Location = new System.Drawing.Point(668, 223);
            this.numericUpDownMinWith.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownMinWith.Name = "numericUpDownMinWith";
            this.numericUpDownMinWith.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownMinWith.TabIndex = 10;
            this.numericUpDownMinWith.ValueChanged += new System.EventHandler(this.numericUpDownMinWith_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ColorDialog_Click);
            // 
            // FormOfOneCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownMinHeight);
            this.Controls.Add(this.numericUpDownMinWith);
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
            this.Text = "Robovator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOfOneCam_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.RadiusTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinWith)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Button BtnConnetct;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer2;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.TrackBar RadiusTrackBar;
        private System.Windows.Forms.Label labelRadiusNum;
        private System.Windows.Forms.Label labelCountOfObjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMinHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMinWith;
        public System.Windows.Forms.Button btnToTalePicture;
        private System.Windows.Forms.Button button1;

    }
}

