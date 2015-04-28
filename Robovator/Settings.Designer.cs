namespace Robovator
{
    partial class Settings
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxCam = new System.Windows.Forms.GroupBox();
            this.numericUpDownCountEncoder = new System.Windows.Forms.NumericUpDown();
            this.labelCountEncoder = new System.Windows.Forms.Label();
            this.groupBoxObject = new System.Windows.Forms.GroupBox();
            this.numericUpDownUnionObject = new System.Windows.Forms.NumericUpDown();
            this.labelUnionObject = new System.Windows.Forms.Label();
            this.numericUpDownDelayAfterObject = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelayBeforeObject = new System.Windows.Forms.NumericUpDown();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWight = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinWidth = new System.Windows.Forms.NumericUpDown();
            this.labelDelayAfterObject = new System.Windows.Forms.Label();
            this.labelDelayBeforeObject = new System.Windows.Forms.Label();
            this.labelMinObject = new System.Windows.Forms.Label();
            this.groupBoxMechanizm = new System.Windows.Forms.GroupBox();
            this.numericUpDownDistanceToTheMechanism = new System.Windows.Forms.NumericUpDown();
            this.labelDistanceToTheMechanism = new System.Windows.Forms.Label();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.hScrollBrightnessFilter = new System.Windows.Forms.HScrollBar();
            this.labelCr = new System.Windows.Forms.Label();
            this.labelCb = new System.Windows.Forms.Label();
            this.labelbrightness = new System.Windows.Forms.Label();
            this.multiScrollCrFilter = new Robovator.MultiScroll();
            this.multiScrollCbFilter = new Robovator.MultiScroll();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxCam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountEncoder)).BeginInit();
            this.groupBoxObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnionObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayAfterObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayBeforeObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinWidth)).BeginInit();
            this.groupBoxMechanizm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistanceToTheMechanism)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxCam
            // 
            this.groupBoxCam.Controls.Add(this.numericUpDownCountEncoder);
            this.groupBoxCam.Controls.Add(this.labelCountEncoder);
            this.groupBoxCam.Location = new System.Drawing.Point(339, 13);
            this.groupBoxCam.Name = "groupBoxCam";
            this.groupBoxCam.Size = new System.Drawing.Size(389, 65);
            this.groupBoxCam.TabIndex = 10;
            this.groupBoxCam.TabStop = false;
            this.groupBoxCam.Text = "Камера";
            // 
            // numericUpDownCountEncoder
            // 
            this.numericUpDownCountEncoder.Location = new System.Drawing.Point(303, 19);
            this.numericUpDownCountEncoder.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCountEncoder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountEncoder.Name = "numericUpDownCountEncoder";
            this.numericUpDownCountEncoder.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownCountEncoder.TabIndex = 5;
            this.numericUpDownCountEncoder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountEncoder.ValueChanged += new System.EventHandler(this.numericUpDownCountEncoder_ValueChanged);
            // 
            // labelCountEncoder
            // 
            this.labelCountEncoder.AutoSize = true;
            this.labelCountEncoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountEncoder.Location = new System.Drawing.Point(6, 25);
            this.labelCountEncoder.Name = "labelCountEncoder";
            this.labelCountEncoder.Size = new System.Drawing.Size(257, 18);
            this.labelCountEncoder.TabIndex = 2;
            this.labelCountEncoder.Text = "Кол-во сигналов энкодера в кадре:";
            // 
            // groupBoxObject
            // 
            this.groupBoxObject.Controls.Add(this.numericUpDownUnionObject);
            this.groupBoxObject.Controls.Add(this.labelUnionObject);
            this.groupBoxObject.Controls.Add(this.numericUpDownDelayAfterObject);
            this.groupBoxObject.Controls.Add(this.numericUpDownDelayBeforeObject);
            this.groupBoxObject.Controls.Add(this.labelHeight);
            this.groupBoxObject.Controls.Add(this.labelWight);
            this.groupBoxObject.Controls.Add(this.numericUpDownHeight);
            this.groupBoxObject.Controls.Add(this.numericUpDownMinWidth);
            this.groupBoxObject.Controls.Add(this.labelDelayAfterObject);
            this.groupBoxObject.Controls.Add(this.labelDelayBeforeObject);
            this.groupBoxObject.Controls.Add(this.labelMinObject);
            this.groupBoxObject.Location = new System.Drawing.Point(339, 84);
            this.groupBoxObject.Name = "groupBoxObject";
            this.groupBoxObject.Size = new System.Drawing.Size(389, 226);
            this.groupBoxObject.TabIndex = 11;
            this.groupBoxObject.TabStop = false;
            this.groupBoxObject.Text = "Объект";
            // 
            // numericUpDownUnionObject
            // 
            this.numericUpDownUnionObject.Location = new System.Drawing.Point(303, 185);
            this.numericUpDownUnionObject.Name = "numericUpDownUnionObject";
            this.numericUpDownUnionObject.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownUnionObject.TabIndex = 114;
            this.numericUpDownUnionObject.ValueChanged += new System.EventHandler(this.numericUpDownUnionObject_ValueChanged);
            // 
            // labelUnionObject
            // 
            this.labelUnionObject.AutoSize = true;
            this.labelUnionObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUnionObject.Location = new System.Drawing.Point(6, 191);
            this.labelUnionObject.Name = "labelUnionObject";
            this.labelUnionObject.Size = new System.Drawing.Size(253, 18);
            this.labelUnionObject.TabIndex = 115;
            this.labelUnionObject.Text = "Объеденение маленьких объектов";
            // 
            // numericUpDownDelayAfterObject
            // 
            this.numericUpDownDelayAfterObject.Location = new System.Drawing.Point(303, 147);
            this.numericUpDownDelayAfterObject.Name = "numericUpDownDelayAfterObject";
            this.numericUpDownDelayAfterObject.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownDelayAfterObject.TabIndex = 11;
            // 
            // numericUpDownDelayBeforeObject
            // 
            this.numericUpDownDelayBeforeObject.Location = new System.Drawing.Point(303, 112);
            this.numericUpDownDelayBeforeObject.Name = "numericUpDownDelayBeforeObject";
            this.numericUpDownDelayBeforeObject.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownDelayBeforeObject.TabIndex = 10;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeight.Location = new System.Drawing.Point(128, 83);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(61, 18);
            this.labelHeight.TabIndex = 9;
            this.labelHeight.Text = "Высота";
            // 
            // labelWight
            // 
            this.labelWight.AutoSize = true;
            this.labelWight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWight.Location = new System.Drawing.Point(128, 48);
            this.labelWight.Name = "labelWight";
            this.labelWight.Size = new System.Drawing.Size(61, 18);
            this.labelWight.TabIndex = 8;
            this.labelWight.Text = "Ширина";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(303, 77);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownHeight.TabIndex = 7;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDownHeight_ValueChanged);
            // 
            // numericUpDownMinWidth
            // 
            this.numericUpDownMinWidth.Location = new System.Drawing.Point(303, 42);
            this.numericUpDownMinWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMinWidth.Name = "numericUpDownMinWidth";
            this.numericUpDownMinWidth.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownMinWidth.TabIndex = 6;
            this.numericUpDownMinWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMinWidth.ValueChanged += new System.EventHandler(this.numericUpDownMinWidth_ValueChanged);
            // 
            // labelDelayAfterObject
            // 
            this.labelDelayAfterObject.AutoSize = true;
            this.labelDelayAfterObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDelayAfterObject.Location = new System.Drawing.Point(6, 153);
            this.labelDelayAfterObject.Name = "labelDelayAfterObject";
            this.labelDelayAfterObject.Size = new System.Drawing.Size(202, 18);
            this.labelDelayAfterObject.TabIndex = 6;
            this.labelDelayAfterObject.Text = "Задержка после объектом:";
            // 
            // labelDelayBeforeObject
            // 
            this.labelDelayBeforeObject.AutoSize = true;
            this.labelDelayBeforeObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDelayBeforeObject.Location = new System.Drawing.Point(6, 118);
            this.labelDelayBeforeObject.Name = "labelDelayBeforeObject";
            this.labelDelayBeforeObject.Size = new System.Drawing.Size(201, 18);
            this.labelDelayBeforeObject.TabIndex = 5;
            this.labelDelayBeforeObject.Text = "Задержка перед объектом:";
            // 
            // labelMinObject
            // 
            this.labelMinObject.AutoSize = true;
            this.labelMinObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinObject.Location = new System.Drawing.Point(6, 25);
            this.labelMinObject.Name = "labelMinObject";
            this.labelMinObject.Size = new System.Drawing.Size(166, 18);
            this.labelMinObject.TabIndex = 4;
            this.labelMinObject.Text = "Минимальный объект:";
            // 
            // groupBoxMechanizm
            // 
            this.groupBoxMechanizm.Controls.Add(this.numericUpDownDistanceToTheMechanism);
            this.groupBoxMechanizm.Controls.Add(this.labelDistanceToTheMechanism);
            this.groupBoxMechanizm.Location = new System.Drawing.Point(345, 328);
            this.groupBoxMechanizm.Name = "groupBoxMechanizm";
            this.groupBoxMechanizm.Size = new System.Drawing.Size(389, 58);
            this.groupBoxMechanizm.TabIndex = 12;
            this.groupBoxMechanizm.TabStop = false;
            this.groupBoxMechanizm.Text = "Механизм";
            // 
            // numericUpDownDistanceToTheMechanism
            // 
            this.numericUpDownDistanceToTheMechanism.Location = new System.Drawing.Point(303, 19);
            this.numericUpDownDistanceToTheMechanism.Name = "numericUpDownDistanceToTheMechanism";
            this.numericUpDownDistanceToTheMechanism.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownDistanceToTheMechanism.TabIndex = 6;
            // 
            // labelDistanceToTheMechanism
            // 
            this.labelDistanceToTheMechanism.AutoSize = true;
            this.labelDistanceToTheMechanism.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDistanceToTheMechanism.Location = new System.Drawing.Point(6, 25);
            this.labelDistanceToTheMechanism.Name = "labelDistanceToTheMechanism";
            this.labelDistanceToTheMechanism.Size = new System.Drawing.Size(197, 18);
            this.labelDistanceToTheMechanism.TabIndex = 5;
            this.labelDistanceToTheMechanism.Text = "Расстояние до механизма:";
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.hScrollBrightnessFilter);
            this.groupBoxFilter.Controls.Add(this.multiScrollCrFilter);
            this.groupBoxFilter.Controls.Add(this.labelCr);
            this.groupBoxFilter.Controls.Add(this.multiScrollCbFilter);
            this.groupBoxFilter.Controls.Add(this.labelCb);
            this.groupBoxFilter.Controls.Add(this.labelbrightness);
            this.groupBoxFilter.Location = new System.Drawing.Point(13, 255);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(326, 247);
            this.groupBoxFilter.TabIndex = 13;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Фильтр";
            // 
            // hScrollBrightnessFilter
            // 
            this.hScrollBrightnessFilter.Location = new System.Drawing.Point(11, 43);
            this.hScrollBrightnessFilter.Maximum = 1000;
            this.hScrollBrightnessFilter.Name = "hScrollBrightnessFilter";
            this.hScrollBrightnessFilter.Size = new System.Drawing.Size(309, 30);
            this.hScrollBrightnessFilter.TabIndex = 12;
            this.hScrollBrightnessFilter.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBrightnessFilter_Scroll);
            // 
            // labelCr
            // 
            this.labelCr.AutoSize = true;
            this.labelCr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCr.Location = new System.Drawing.Point(6, 161);
            this.labelCr.Name = "labelCr";
            this.labelCr.Size = new System.Drawing.Size(28, 18);
            this.labelCr.TabIndex = 8;
            this.labelCr.Text = "Cr:";
            // 
            // labelCb
            // 
            this.labelCb.AutoSize = true;
            this.labelCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCb.Location = new System.Drawing.Point(8, 73);
            this.labelCb.Name = "labelCb";
            this.labelCb.Size = new System.Drawing.Size(31, 18);
            this.labelCb.TabIndex = 7;
            this.labelCb.Text = "Cb:";
            // 
            // labelbrightness
            // 
            this.labelbrightness.AutoSize = true;
            this.labelbrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelbrightness.Location = new System.Drawing.Point(8, 25);
            this.labelbrightness.Name = "labelbrightness";
            this.labelbrightness.Size = new System.Drawing.Size(131, 18);
            this.labelbrightness.TabIndex = 6;
            this.labelbrightness.Text = "Уровень яркости:";
            // 
            // multiScrollCrFilter
            // 
            this.multiScrollCrFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiScrollCrFilter.Location = new System.Drawing.Point(0, 181);
            this.multiScrollCrFilter.Margin = new System.Windows.Forms.Padding(20);
            this.multiScrollCrFilter.MaxValue = 500;
            this.multiScrollCrFilter.MinValue = -500;
            this.multiScrollCrFilter.Name = "multiScrollCrFilter";
            this.multiScrollCrFilter.Size = new System.Drawing.Size(320, 54);
            this.multiScrollCrFilter.TabIndex = 11;
            this.multiScrollCrFilter.OnMultiScroll += new Robovator.MultiScroll.MultiScrollEventHandler(this.multiScrollCrFilter_OnMultiScroll);
            // 
            // multiScrollCbFilter
            // 
            this.multiScrollCbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiScrollCbFilter.Location = new System.Drawing.Point(11, 93);
            this.multiScrollCbFilter.Margin = new System.Windows.Forms.Padding(11);
            this.multiScrollCbFilter.MaxValue = 500;
            this.multiScrollCbFilter.MinValue = -500;
            this.multiScrollCbFilter.Name = "multiScrollCbFilter";
            this.multiScrollCbFilter.Size = new System.Drawing.Size(309, 57);
            this.multiScrollCbFilter.TabIndex = 10;
            this.multiScrollCbFilter.OnMultiScroll += new Robovator.MultiScroll.MultiScrollEventHandler(this.multiScrollCbFilter_OnMultiScroll);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 509);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.groupBoxMechanizm);
            this.Controls.Add(this.groupBoxObject);
            this.Controls.Add(this.groupBoxCam);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxCam.ResumeLayout(false);
            this.groupBoxCam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountEncoder)).EndInit();
            this.groupBoxObject.ResumeLayout(false);
            this.groupBoxObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnionObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayAfterObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayBeforeObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinWidth)).EndInit();
            this.groupBoxMechanizm.ResumeLayout(false);
            this.groupBoxMechanizm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistanceToTheMechanism)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxCam;
        private System.Windows.Forms.NumericUpDown numericUpDownCountEncoder;
        private System.Windows.Forms.Label labelCountEncoder;
        private System.Windows.Forms.GroupBox groupBoxObject;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWight;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownMinWidth;
        private System.Windows.Forms.Label labelDelayAfterObject;
        private System.Windows.Forms.Label labelDelayBeforeObject;
        private System.Windows.Forms.Label labelMinObject;
        private System.Windows.Forms.NumericUpDown numericUpDownDelayAfterObject;
        private System.Windows.Forms.NumericUpDown numericUpDownDelayBeforeObject;
        private System.Windows.Forms.GroupBox groupBoxMechanizm;
        private System.Windows.Forms.Label labelDistanceToTheMechanism;
        private System.Windows.Forms.NumericUpDown numericUpDownDistanceToTheMechanism;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.HScrollBar hScrollBrightnessFilter;
        private MultiScroll multiScrollCrFilter;
        private System.Windows.Forms.Label labelCr;
        private MultiScroll multiScrollCbFilter;
        private System.Windows.Forms.Label labelCb;
        private System.Windows.Forms.Label labelbrightness;
        private System.Windows.Forms.NumericUpDown numericUpDownUnionObject;
        private System.Windows.Forms.Label labelUnionObject;

    }
}