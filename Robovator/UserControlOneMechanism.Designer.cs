namespace Robovator
{
    partial class UserControlOneMechanism
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.groupBoxCam = new System.Windows.Forms.GroupBox();
            this.numericUpDownCountEncoder = new System.Windows.Forms.NumericUpDown();
            this.labelFPSValue = new System.Windows.Forms.Label();
            this.labelResolutionValue = new System.Windows.Forms.Label();
            this.labelCountEncoder = new System.Windows.Forms.Label();
            this.labelFPS = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.groupBoxMechanizm = new System.Windows.Forms.GroupBox();
            this.numericUpDownDistanceToTheMechanism = new System.Windows.Forms.NumericUpDown();
            this.labelDistanceToTheMechanism = new System.Windows.Forms.Label();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.hScrollBrightnessFilter = new System.Windows.Forms.HScrollBar();
            this.multiScrollCrFilter = new Robovator.MultiScroll();
            this.labelCr = new System.Windows.Forms.Label();
            this.multiScrollCbFilter = new Robovator.MultiScroll();
            this.labelCb = new System.Windows.Forms.Label();
            this.labelbrightness = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.labelCountInFrame = new System.Windows.Forms.Label();
            this.labelMinObject = new System.Windows.Forms.Label();
            this.labelDelayBeforeObject = new System.Windows.Forms.Label();
            this.labelDelayAfterObject = new System.Windows.Forms.Label();
            this.numericUpDownMinWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.labelWight = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelCountInFrameValue = new System.Windows.Forms.Label();
            this.labelTotalCountObjectValue = new System.Windows.Forms.Label();
            this.groupBoxObject = new System.Windows.Forms.GroupBox();
            this.numericUpDownUnionObject = new System.Windows.Forms.NumericUpDown();
            this.labelUnionObject = new System.Windows.Forms.Label();
            this.numericUpDownDelayAfterObject = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelayBeforeObject = new System.Windows.Forms.NumericUpDown();
            this.buttonSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.groupBoxCam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountEncoder)).BeginInit();
            this.groupBoxMechanizm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistanceToTheMechanism)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.groupBoxObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnionObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayAfterObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayBeforeObject)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(6, 6);
            this.pictureBoxMain.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(629, 472);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            // 
            // groupBoxCam
            // 
            this.groupBoxCam.Controls.Add(this.numericUpDownCountEncoder);
            this.groupBoxCam.Controls.Add(this.labelFPSValue);
            this.groupBoxCam.Controls.Add(this.labelResolutionValue);
            this.groupBoxCam.Controls.Add(this.labelCountEncoder);
            this.groupBoxCam.Controls.Add(this.labelFPS);
            this.groupBoxCam.Controls.Add(this.labelResolution);
            this.groupBoxCam.Location = new System.Drawing.Point(661, 24);
            this.groupBoxCam.Name = "groupBoxCam";
            this.groupBoxCam.Size = new System.Drawing.Size(356, 95);
            this.groupBoxCam.TabIndex = 100;
            this.groupBoxCam.TabStop = false;
            this.groupBoxCam.Text = "Камера";
            // 
            // numericUpDownCountEncoder
            // 
            this.numericUpDownCountEncoder.Location = new System.Drawing.Point(270, 61);
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
            this.numericUpDownCountEncoder.TabIndex = 0;
            this.numericUpDownCountEncoder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountEncoder.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelFPSValue
            // 
            this.labelFPSValue.AutoSize = true;
            this.labelFPSValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFPSValue.Location = new System.Drawing.Point(54, 47);
            this.labelFPSValue.Name = "labelFPSValue";
            this.labelFPSValue.Size = new System.Drawing.Size(0, 18);
            this.labelFPSValue.TabIndex = 4;
            // 
            // labelResolutionValue
            // 
            this.labelResolutionValue.AutoSize = true;
            this.labelResolutionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResolutionValue.Location = new System.Drawing.Point(101, 29);
            this.labelResolutionValue.Name = "labelResolutionValue";
            this.labelResolutionValue.Size = new System.Drawing.Size(0, 18);
            this.labelResolutionValue.TabIndex = 0;
            // 
            // labelCountEncoder
            // 
            this.labelCountEncoder.AutoSize = true;
            this.labelCountEncoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountEncoder.Location = new System.Drawing.Point(7, 65);
            this.labelCountEncoder.Name = "labelCountEncoder";
            this.labelCountEncoder.Size = new System.Drawing.Size(257, 18);
            this.labelCountEncoder.TabIndex = 103;
            this.labelCountEncoder.Text = "Кол-во сигналов энкодера в кадре:";
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFPS.Location = new System.Drawing.Point(7, 47);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(41, 18);
            this.labelFPS.TabIndex = 102;
            this.labelFPS.Text = "FPS:";
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResolution.Location = new System.Drawing.Point(7, 29);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(101, 18);
            this.labelResolution.TabIndex = 101;
            this.labelResolution.Text = "Разрешение: ";
            // 
            // groupBoxMechanizm
            // 
            this.groupBoxMechanizm.Controls.Add(this.numericUpDownDistanceToTheMechanism);
            this.groupBoxMechanizm.Controls.Add(this.labelDistanceToTheMechanism);
            this.groupBoxMechanizm.Location = new System.Drawing.Point(661, 426);
            this.groupBoxMechanizm.Name = "groupBoxMechanizm";
            this.groupBoxMechanizm.Size = new System.Drawing.Size(356, 52);
            this.groupBoxMechanizm.TabIndex = 112;
            this.groupBoxMechanizm.TabStop = false;
            this.groupBoxMechanizm.Text = "Механизм";
            // 
            // numericUpDownDistanceToTheMechanism
            // 
            this.numericUpDownDistanceToTheMechanism.Location = new System.Drawing.Point(270, 19);
            this.numericUpDownDistanceToTheMechanism.Name = "numericUpDownDistanceToTheMechanism";
            this.numericUpDownDistanceToTheMechanism.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownDistanceToTheMechanism.TabIndex = 5;
            // 
            // labelDistanceToTheMechanism
            // 
            this.labelDistanceToTheMechanism.AutoSize = true;
            this.labelDistanceToTheMechanism.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDistanceToTheMechanism.Location = new System.Drawing.Point(6, 25);
            this.labelDistanceToTheMechanism.Name = "labelDistanceToTheMechanism";
            this.labelDistanceToTheMechanism.Size = new System.Drawing.Size(197, 18);
            this.labelDistanceToTheMechanism.TabIndex = 113;
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
            this.groupBoxFilter.Location = new System.Drawing.Point(6, 487);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(629, 194);
            this.groupBoxFilter.TabIndex = 114;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Фильтр";
            // 
            // hScrollBrightnessFilter
            // 
            this.hScrollBrightnessFilter.Location = new System.Drawing.Point(11, 62);
            this.hScrollBrightnessFilter.Maximum = 1000;
            this.hScrollBrightnessFilter.Name = "hScrollBrightnessFilter";
            this.hScrollBrightnessFilter.Size = new System.Drawing.Size(260, 22);
            this.hScrollBrightnessFilter.TabIndex = 6;
            this.hScrollBrightnessFilter.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // multiScrollCrFilter
            // 
            this.multiScrollCrFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiScrollCrFilter.Location = new System.Drawing.Point(350, 131);
            this.multiScrollCrFilter.Margin = new System.Windows.Forms.Padding(20);
            this.multiScrollCrFilter.MaxValue = 500;
            this.multiScrollCrFilter.MinValue = -500;
            this.multiScrollCrFilter.Name = "multiScrollCrFilter";
            this.multiScrollCrFilter.Size = new System.Drawing.Size(279, 54);
            this.multiScrollCrFilter.TabIndex = 8;
            this.multiScrollCrFilter.OnMultiScroll += new Robovator.MultiScroll.MultiScrollEventHandler(this.multiScroll3_OnMultiScroll);
            // 
            // labelCr
            // 
            this.labelCr.AutoSize = true;
            this.labelCr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCr.Location = new System.Drawing.Point(364, 111);
            this.labelCr.Name = "labelCr";
            this.labelCr.Size = new System.Drawing.Size(28, 18);
            this.labelCr.TabIndex = 117;
            this.labelCr.Text = "Cr:";
            // 
            // multiScrollCbFilter
            // 
            this.multiScrollCbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiScrollCbFilter.Location = new System.Drawing.Point(11, 131);
            this.multiScrollCbFilter.Margin = new System.Windows.Forms.Padding(11);
            this.multiScrollCbFilter.MaxValue = 500;
            this.multiScrollCbFilter.MinValue = -500;
            this.multiScrollCbFilter.Name = "multiScrollCbFilter";
            this.multiScrollCbFilter.Size = new System.Drawing.Size(286, 54);
            this.multiScrollCbFilter.TabIndex = 7;
            this.multiScrollCbFilter.OnMultiScroll += new Robovator.MultiScroll.MultiScrollEventHandler(this.multiScroll2_OnMultiScroll);
            // 
            // labelCb
            // 
            this.labelCb.AutoSize = true;
            this.labelCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCb.Location = new System.Drawing.Point(21, 102);
            this.labelCb.Name = "labelCb";
            this.labelCb.Size = new System.Drawing.Size(31, 18);
            this.labelCb.TabIndex = 116;
            this.labelCb.Text = "Cb:";
            // 
            // labelbrightness
            // 
            this.labelbrightness.AutoSize = true;
            this.labelbrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelbrightness.Location = new System.Drawing.Point(8, 44);
            this.labelbrightness.Name = "labelbrightness";
            this.labelbrightness.Size = new System.Drawing.Size(131, 18);
            this.labelbrightness.TabIndex = 115;
            this.labelbrightness.Text = "Уровень яркости:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 118;
            this.label1.Text = "0";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(891, 618);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(126, 60);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(643, 618);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(126, 60);
            this.buttonDefault.TabIndex = 9;
            this.buttonDefault.Text = "По умолчанию";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalCount.Location = new System.Drawing.Point(7, 25);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(146, 18);
            this.labelTotalCount.TabIndex = 105;
            this.labelTotalCount.Text = "Общее количество:";
            // 
            // labelCountInFrame
            // 
            this.labelCountInFrame.AutoSize = true;
            this.labelCountInFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountInFrame.Location = new System.Drawing.Point(7, 43);
            this.labelCountInFrame.Name = "labelCountInFrame";
            this.labelCountInFrame.Size = new System.Drawing.Size(130, 18);
            this.labelCountInFrame.TabIndex = 106;
            this.labelCountInFrame.Text = "Найдено в кадре:";
            // 
            // labelMinObject
            // 
            this.labelMinObject.AutoSize = true;
            this.labelMinObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinObject.Location = new System.Drawing.Point(7, 66);
            this.labelMinObject.Name = "labelMinObject";
            this.labelMinObject.Size = new System.Drawing.Size(166, 18);
            this.labelMinObject.TabIndex = 107;
            this.labelMinObject.Text = "Минимальный объект:";
            // 
            // labelDelayBeforeObject
            // 
            this.labelDelayBeforeObject.AutoSize = true;
            this.labelDelayBeforeObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDelayBeforeObject.Location = new System.Drawing.Point(7, 154);
            this.labelDelayBeforeObject.Name = "labelDelayBeforeObject";
            this.labelDelayBeforeObject.Size = new System.Drawing.Size(201, 18);
            this.labelDelayBeforeObject.TabIndex = 110;
            this.labelDelayBeforeObject.Text = "Задержка перед объектом:";
            // 
            // labelDelayAfterObject
            // 
            this.labelDelayAfterObject.AutoSize = true;
            this.labelDelayAfterObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDelayAfterObject.Location = new System.Drawing.Point(7, 189);
            this.labelDelayAfterObject.Name = "labelDelayAfterObject";
            this.labelDelayAfterObject.Size = new System.Drawing.Size(202, 18);
            this.labelDelayAfterObject.TabIndex = 111;
            this.labelDelayAfterObject.Text = "Задержка после объектом:";
            // 
            // numericUpDownMinWidth
            // 
            this.numericUpDownMinWidth.Location = new System.Drawing.Point(270, 78);
            this.numericUpDownMinWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMinWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMinWidth.Name = "numericUpDownMinWidth";
            this.numericUpDownMinWidth.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownMinWidth.TabIndex = 1;
            this.numericUpDownMinWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMinWidth.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(270, 113);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownHeight.TabIndex = 2;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // labelWight
            // 
            this.labelWight.AutoSize = true;
            this.labelWight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWight.Location = new System.Drawing.Point(142, 84);
            this.labelWight.Name = "labelWight";
            this.labelWight.Size = new System.Drawing.Size(61, 18);
            this.labelWight.TabIndex = 108;
            this.labelWight.Text = "Ширина";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeight.Location = new System.Drawing.Point(142, 119);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(61, 18);
            this.labelHeight.TabIndex = 109;
            this.labelHeight.Text = "Высота";
            // 
            // labelCountInFrameValue
            // 
            this.labelCountInFrameValue.AutoSize = true;
            this.labelCountInFrameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountInFrameValue.Location = new System.Drawing.Point(143, 43);
            this.labelCountInFrameValue.Name = "labelCountInFrameValue";
            this.labelCountInFrameValue.Size = new System.Drawing.Size(0, 18);
            this.labelCountInFrameValue.TabIndex = 10;
            // 
            // labelTotalCountObjectValue
            // 
            this.labelTotalCountObjectValue.AutoSize = true;
            this.labelTotalCountObjectValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalCountObjectValue.Location = new System.Drawing.Point(157, 25);
            this.labelTotalCountObjectValue.Name = "labelTotalCountObjectValue";
            this.labelTotalCountObjectValue.Size = new System.Drawing.Size(0, 18);
            this.labelTotalCountObjectValue.TabIndex = 11;
            // 
            // groupBoxObject
            // 
            this.groupBoxObject.Controls.Add(this.numericUpDownUnionObject);
            this.groupBoxObject.Controls.Add(this.labelUnionObject);
            this.groupBoxObject.Controls.Add(this.numericUpDownDelayAfterObject);
            this.groupBoxObject.Controls.Add(this.numericUpDownDelayBeforeObject);
            this.groupBoxObject.Controls.Add(this.labelTotalCountObjectValue);
            this.groupBoxObject.Controls.Add(this.labelCountInFrameValue);
            this.groupBoxObject.Controls.Add(this.labelHeight);
            this.groupBoxObject.Controls.Add(this.labelWight);
            this.groupBoxObject.Controls.Add(this.numericUpDownHeight);
            this.groupBoxObject.Controls.Add(this.numericUpDownMinWidth);
            this.groupBoxObject.Controls.Add(this.labelDelayAfterObject);
            this.groupBoxObject.Controls.Add(this.labelDelayBeforeObject);
            this.groupBoxObject.Controls.Add(this.labelMinObject);
            this.groupBoxObject.Controls.Add(this.labelCountInFrame);
            this.groupBoxObject.Controls.Add(this.labelTotalCount);
            this.groupBoxObject.Location = new System.Drawing.Point(661, 120);
            this.groupBoxObject.Name = "groupBoxObject";
            this.groupBoxObject.Size = new System.Drawing.Size(356, 300);
            this.groupBoxObject.TabIndex = 104;
            this.groupBoxObject.TabStop = false;
            this.groupBoxObject.Text = "Объект";
            // 
            // numericUpDownUnionObject
            // 
            this.numericUpDownUnionObject.Location = new System.Drawing.Point(270, 217);
            this.numericUpDownUnionObject.Name = "numericUpDownUnionObject";
            this.numericUpDownUnionObject.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownUnionObject.TabIndex = 112;
            this.numericUpDownUnionObject.ValueChanged += new System.EventHandler(this.numericUpDownUnionObject_ValueChanged);
            // 
            // labelUnionObject
            // 
            this.labelUnionObject.AutoSize = true;
            this.labelUnionObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUnionObject.Location = new System.Drawing.Point(7, 223);
            this.labelUnionObject.Name = "labelUnionObject";
            this.labelUnionObject.Size = new System.Drawing.Size(253, 18);
            this.labelUnionObject.TabIndex = 113;
            this.labelUnionObject.Text = "Объеденение маленьких объектов";
            // 
            // numericUpDownDelayAfterObject
            // 
            this.numericUpDownDelayAfterObject.Location = new System.Drawing.Point(270, 183);
            this.numericUpDownDelayAfterObject.Name = "numericUpDownDelayAfterObject";
            this.numericUpDownDelayAfterObject.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownDelayAfterObject.TabIndex = 4;
            // 
            // numericUpDownDelayBeforeObject
            // 
            this.numericUpDownDelayBeforeObject.Location = new System.Drawing.Point(270, 148);
            this.numericUpDownDelayBeforeObject.Name = "numericUpDownDelayBeforeObject";
            this.numericUpDownDelayBeforeObject.Size = new System.Drawing.Size(80, 29);
            this.numericUpDownDelayBeforeObject.TabIndex = 3;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(767, 618);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(126, 60);
            this.buttonSettings.TabIndex = 10;
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // UserControlOneMechanism
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.groupBoxMechanizm);
            this.Controls.Add(this.groupBoxObject);
            this.Controls.Add(this.groupBoxCam);
            this.Controls.Add(this.pictureBoxMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UserControlOneMechanism";
            this.Size = new System.Drawing.Size(1024, 688);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.groupBoxCam.ResumeLayout(false);
            this.groupBoxCam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountEncoder)).EndInit();
            this.groupBoxMechanizm.ResumeLayout(false);
            this.groupBoxMechanizm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistanceToTheMechanism)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.groupBoxObject.ResumeLayout(false);
            this.groupBoxObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnionObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayAfterObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayBeforeObject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.GroupBox groupBoxCam;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Label labelCountEncoder;
        private System.Windows.Forms.GroupBox groupBoxMechanizm;
        private System.Windows.Forms.Label labelDistanceToTheMechanism;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label labelCr;
        private System.Windows.Forms.Label labelCb;
        private System.Windows.Forms.Label labelbrightness;
        internal System.Windows.Forms.Label labelResolutionValue;
        private System.Windows.Forms.Label labelFPSValue;
        private System.Windows.Forms.NumericUpDown numericUpDownCountEncoder;
        private MultiScroll multiScrollCbFilter;
        private MultiScroll multiScrollCrFilter;
        private System.Windows.Forms.HScrollBar hScrollBrightnessFilter;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Label labelTotalCount;
        private System.Windows.Forms.Label labelCountInFrame;
        private System.Windows.Forms.Label labelMinObject;
        private System.Windows.Forms.Label labelDelayBeforeObject;
        private System.Windows.Forms.Label labelDelayAfterObject;
        private System.Windows.Forms.NumericUpDown numericUpDownMinWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label labelWight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelCountInFrameValue;
        private System.Windows.Forms.Label labelTotalCountObjectValue;
        private System.Windows.Forms.GroupBox groupBoxObject;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.NumericUpDown numericUpDownDelayAfterObject;
        private System.Windows.Forms.NumericUpDown numericUpDownDelayBeforeObject;
        private System.Windows.Forms.NumericUpDown numericUpDownDistanceToTheMechanism;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownUnionObject;
        private System.Windows.Forms.Label labelUnionObject;



    }
}
