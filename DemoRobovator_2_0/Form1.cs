﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Video;
using AForge.Controls;
using System.Drawing.Imaging;
using AForge.Math.Geometry;
using System.Threading;
using System.Collections.Concurrent;

namespace DemoRobovator_2_0
{
    public partial class Form1 : Form
    {
        private class FoundObj
        {
            public FoundObj() { id++; objId = id; }

            public static int TotalObjectCount { get { return id; } }

            private static int id = 0;
            private int objId = 0;
            public int Id { get { return objId; } }
            public bool end = false;
            public int objTickStart = 0;
            public int objTickEnd = 0;
            private int objTickLength = 0;
            public int ObjTickLength
            {
                get { return objTickLength; }
                set
                {
                    if (objTickLength == 0)
                        objTickLength = value;
                }
            }

        }

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSources;
        private YCbCrFiltering filter = new YCbCrFiltering();
        private Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
        private BlobCounter blobCounter = new BlobCounter();
        private SerialPort serialPort1 = null;
        private int countEncoderTicks = 0;
        private bool isConnectArduino = false;
        private bool isMechanizmOn = false;
        private int brightnessCorrection = 0;
        private int cbMin = -500;
        private int cbMax = -55;
        private int crMax = 55;
        private int crMin = -500;
        private int blobCounterMinWidth = 25;
        private int blobCounterMinHeight = 25;
        private int frequencyResponse = 0;
        private Rectangle[] rects;
        private byte[] arr = new byte[1080];
        private byte[] arrTemp = new byte[40];
        private int unionObject = 0;
        private int objectCount = 0;
        private bool isIntersect = false;
        private bool isStart = false;
        private ConcurrentQueue<FoundObj> quFoundObject = new ConcurrentQueue<FoundObj>();
        private FoundObj fObj;

        

        // инициализация
        public Form1()
        {
            InitializeComponent();

            // перебираю все COM-порты в системе и добавляю в cmbBoxConnectArduino
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
                cmbBoxConnectArduino.Items.Add(portName);

            // если есть COM-порты, выбираю первый из них
            if (cmbBoxConnectArduino.Items.Count > 0)
                cmbBoxConnectArduino.SelectedIndex = 0;

            pictureBox1.Image = null;
        }

        // Нажата кнопка соеденения с Arduino
        private void btnConnectArduino_Click(object sender, EventArgs e)
        {
            serialPort1 = new SerialPort();
            try
            {
                serialPort1.PortName = cmbBoxConnectArduino.SelectedItem.ToString();
                serialPort1.BaudRate = 115200;
                serialPort1.DtrEnable = true;
                serialPort1.RtsEnable = true;
                serialPort1.ReadTimeout = 1000;
                serialPort1.Open();

                // Отправляю команду на Arduino для идентификации
                char[] ch = new char[2];
                ch[0] = 'i';
                serialPort1.Write(ch, 0, 1);

                // Опрашиваю Arduino и проверяю на пренадлежность
                String line = null;
                line = serialPort1.ReadLine();
                line = line.Trim('\r', '\n', '\t').ToLower();

                if (!String.IsNullOrEmpty(line) && line == "good")
                {
                    serialPort1.DataReceived += SerialPort1_DataReceived;
                    lblConnectArduino.Text = "OK";
                    lblConnectArduino.ForeColor = Color.Green;
                    isConnectArduino = true;
                }
                else
                {
                    MessageBox.Show("Выбран не верный порт Arduino!");
                    lblConnectArduino.Text = "NO";
                    lblConnectArduino.ForeColor = Color.Black;
                    isConnectArduino = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Порт закрыт!\n" + ex.Message);
                if (!isConnectArduino)
                {
                    lblConnectArduino.Text = "NO";
                    lblConnectArduino.ForeColor = Color.Black;
                }
            }
        }

        private bool isObjFound = false;
        private int tmpObjLenth = 0;
        private void workWithObjects(Rectangle[] rects, ref Bitmap image)
        {
            bool tmpIsObjFound = false;

            if (isStart)
            {
                if (rects.Length > 0)
                {
                    foreach (Rectangle item in rects)
                    {
                        if (item.IntersectsWith(new Rectangle(0, image.Height - (image.Height / 3), image.Width, 1)))
                        {
                            if (!isObjFound)
                            {
                                FoundObj tmpFoundObj = new FoundObj();
                                tmpObjLenth = countEncoderTicks;
                                quFoundObject.Enqueue(tmpFoundObj);
                            }
                            tmpIsObjFound = true;
                            isObjFound = true;
                            break;
                        }
                    }
                }
                if (!tmpIsObjFound)
                {
                    isObjFound = false;
                    if (quFoundObject.Count > 0)
                    {
                        quFoundObject.Last().ObjTickLength = countEncoderTicks - tmpObjLenth;
                        foreach (FoundObj tmpObj in quFoundObject)
                            tmpObj.end = true;
                        //quFoundObject.First().end = true;
                    }
                }
            }
        }

        void serialCommandProcessing()
        {
            labelTotalCountObj.Invoke((MethodInvoker)(() =>
            {
                labelTotalCountObj.Text = FoundObj.TotalObjectCount.ToString();
            }));

            listBox1.Invoke((MethodInvoker)(() => { listBox1.Items.Clear(); }));

            foreach (var item in quFoundObject)
            {
                string str = string.Format("ID: {0}, Start: {1}, End: {2}, is end: {3}, Lenght: {4}", item.Id, item.objTickStart, item.objTickEnd, item.end, item.ObjTickLength);
                listBox1.Invoke((MethodInvoker)(() =>
                {
                    listBox1.Items.Add(str);
                }));
            }


            if (quFoundObject.Count > 0)
            {
                bool isDequeue = false;
                foreach (FoundObj tmpObj in quFoundObject)
                {
                    if (tmpObj.objTickStart < frequencyResponse)
                        tmpObj.objTickStart++;
                    else
                        commandMech('w');

                    if (tmpObj.end)
                    {
                        if (tmpObj.objTickEnd < frequencyResponse)
                            tmpObj.objTickEnd++;
                        else
                        {
                            isDequeue = true;
                            commandMech('q');
                        }
                    }
                }
                if (isDequeue)
                {
                    FoundObj tmpT;
                    // quFoundObject.Dequeue();
                    quFoundObject.TryDequeue(out tmpT);
                }
            }
            lblCountEncoderTicks.Invoke((MethodInvoker)(() => lblCountEncoderTicks.Text = countEncoderTicks.ToString()));
        }

        // Событие о полученных данных с Arduino
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            String data = null;
            data = serialPort1.ReadLine();
            data = data.Trim('\r', '\n', '\t').ToLower();

            if (!String.IsNullOrEmpty(data) && data == "1" && isStart)
            {
                countEncoderTicks++;
                serialCommandProcessing();
            }
        }

        int countClick = 0;
        private bool isEnabled = false;
        // команды для механизма
        private void commandMech(char command)
        {
            if (isConnectArduino)
            {
                if (!isEnabled && command == 'w' ||
                    isEnabled && command == 'q')
                {
                    isEnabled = !isEnabled;

                    char[] ch = new char[2];
                    ch[0] = command;
                    serialPort1.Write(ch, 0, 1);
                }
            }
        }

        // проверка механизма
        private void btnCheckMechanizm_Click(object sender, EventArgs e)
        {
            if (isConnectArduino)
            {
                if (!isMechanizmOn)
                {
                    char[] ch = new char[2];
                    ch[0] = 'w';
                    serialPort1.Write(ch, 0, 1);
                    btnCheckMechanizm.BackColor = Color.GreenYellow;
                    isMechanizmOn = true;
                }
                else if (isMechanizmOn)
                {
                    char[] ch = new char[2];
                    ch[0] = 'q';
                    serialPort1.Write(ch, 0, 1);
                    btnCheckMechanizm.BackColor = SystemColors.Control;
                    isMechanizmOn = false;
                }

            }
            else
                MessageBox.Show("Arduino не подключен!");
        }

        void init()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in videoDevices)
                cmbBoxConnectCamera.Items.Add(device.Name);

            if (cmbBoxConnectCamera.Items.Count > 0)
                cmbBoxConnectCamera.SelectedIndex = 0;

            if (cmbBoxRezolution.Items.Count == 0)
            {
                videoSources = new VideoCaptureDevice(videoDevices[cmbBoxConnectCamera.SelectedIndex].MonikerString);

                foreach (VideoCapabilities videoCapabilities in videoSources.VideoCapabilities)
                    cmbBoxRezolution.Items.Clear();

                foreach (VideoCapabilities videoCapabilities in videoSources.VideoCapabilities)
                    cmbBoxRezolution.Items.Add(videoCapabilities.FrameSize);

                if (cmbBoxRezolution.Items.Count > 0)
                    cmbBoxRezolution.SelectedIndex = 0;
            }

            cmbBoxConnectCamera.SelectedIndexChanged += CmbBoxConnectCamera_SelectedIndexChanged;
        }

        // операции при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        // изминение камеры
        private void CmbBoxConnectCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxConnectCamera.Items.Count > 0)
            {
                videoSources = new VideoCaptureDevice(videoDevices[cmbBoxConnectCamera.SelectedIndex].MonikerString);

                foreach (VideoCapabilities videoCapabilities in videoSources.VideoCapabilities)
                    cmbBoxRezolution.Items.Clear();

                foreach (VideoCapabilities videoCapabilities in videoSources.VideoCapabilities)
                    cmbBoxRezolution.Items.Add(videoCapabilities.FrameSize);

                if (cmbBoxRezolution.Items.Count > 0)
                    cmbBoxRezolution.SelectedIndex = 0;
            }
        }

        // Соеденяюсь с камерой
        private void btnConnectCamera_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoSources.IsRunning)
                {
                    brightnessCorrection = 0;
                    cbMin = 0;
                    cbMax = 0;
                    crMax = 0;
                    crMin = 0;
                    pictureBox1.Image = null;
                    pictureBox1.Invalidate();
                    videoSources.Stop();
                    lblConnectCamera.Text = "NO";
                    lblConnectCamera.ForeColor = Color.Black;
                }
                else
                {
                    videoSources.VideoResolution = videoSources.VideoCapabilities[cmbBoxRezolution.SelectedIndex];
                    videoSources.NewFrame += VideoSources_NewFrame;
                    videoSources.Start();
                    lblConnectCamera.Text = "OK";
                    lblConnectCamera.ForeColor = Color.Green;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

        }

        void myMethod(Bitmap image)
        {
            temp++;
            if (temp == 1)
            {
                temp = 0;

                ResizeBilinear filterResize = new ResizeBilinear(640, 480);
                image = filterResize.Apply((Bitmap)image.Clone());


                UnmanagedImage grayImage = workFilter(ref image);

                Rectangle[] rects = workBlobs(grayImage, ref image);

                workWithObjects(rects, ref image);

                pictureBox1.Image = image;
            }
        }

        // покадравая обработка
        private int temp = 0;
        private void VideoSources_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            myMethod(image);
        }

        // формирование прямоугольника вокруг найденых объектов
        private Rectangle[] workBlobs(UnmanagedImage grayImage, ref Bitmap image)
        {
            blobCounter.MinWidth = blobCounterMinWidth;
            blobCounter.MinHeight = blobCounterMinHeight;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.YX;
            blobCounter.ProcessImage(grayImage);
            rects = blobCounter.GetObjectsRectangles();

            Graphics l = Graphics.FromImage(image);
            using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 1))
                l.DrawRectangle(pen, 0, image.Height - (image.Height / 3), image.Width, 1);

            foreach (Rectangle recs in rects)
                if (rects.Length > 0)
                {
                    foreach (Rectangle objectRect in rects)
                    {
                        Graphics g = Graphics.FromImage(image);
                        using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 1))
                        {
                            g.DrawRectangle(pen, objectRect);
                        }
                        g.Dispose();

                    }
                    objectCount = blobCounter.ObjectsCount;
                    this.Invoke((MethodInvoker)delegate
                    {
                        labelCountFoundObj.Text = objectCount.ToString();
                    });
                }

            l.Dispose();
            return rects;
        }

        // Приминение фильтров и создание серого изображения
        private UnmanagedImage workFilter(ref Bitmap image)
        {
            BrightnessCorrection bFilter = null;
            bFilter = new BrightnessCorrection(brightnessCorrection);
            bFilter.ApplyInPlace(image);

            filter.Y = new Range(0, 1);
            filter.Cb = new Range((float)cbMin / 1000.0f, (float)cbMax / 1000.0f);
            filter.Cr = new Range((float)crMin / 1000.0f, (float)crMax / 1000.0f);
            filter.ApplyInPlace(image);

            BitmapData objectsData = image.LockBits(new Rectangle(0, 0,
                image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
            UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));
            image.UnlockBits(objectsData);

            return grayImage;
        }

        // при закрытии формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            char[] ch = new char[2];
            ch[0] = 'c';
            serialPort1.Write(ch, 0, 1);

            System.Diagnostics.Process.GetCurrentProcess().Kill();
            //videoSources.PlayingFinished += VideoSources_PlayingFinished;
            isStart = false;
            videoSources.Stop();
            serialPort1.Close();
            serialPort1.Dispose();
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
            Application.Exit();
        }

        // изминения яркости
        private void trackBarBrighest_Scroll(object sender, EventArgs e)
        {
            this.brightnessCorrection = trackBarBrighest.Value;
            labelBrighest.Text = brightnessCorrection.ToString();
        }

        // изминения CbMin
        private void trackBarCbMin_Scroll(object sender, EventArgs e)
        {
            this.cbMin = trackBarCbMin.Value;
            labelCbMin.Text = cbMin.ToString();
        }

        // изминения CbMax
        private void trackBarCbMax_Scroll(object sender, EventArgs e)
        {
            this.cbMax = trackBarCbMax.Value;
            labelCbMax.Text = cbMax.ToString();
        }

        // изминения CrMin
        private void trackBarCrMin_Scroll(object sender, EventArgs e)
        {
            this.crMin = trackBarCrMin.Value;
            labelCrMin.Text = crMin.ToString();
        }

        // изминения CrMax
        private void trackBarCrMax_Scroll(object sender, EventArgs e)
        {
            this.crMax = trackBarCrMax.Value;
            labelCrMax.Text = crMax.ToString();
        }

        // изминения MinObjectHeight
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.blobCounterMinHeight = (int)numericUpDown1.Value;
        }

        // изминения MinObjectWeight
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.blobCounterMinWidth = (int)numericUpDown2.Value;
        }

        // кнопка выхода
        private void btnExit_Click(object sender, EventArgs e)
        {
            char[] ch = new char[2];
            ch[0] = 'c';
            serialPort1.Write(ch, 0, 1);

            System.Diagnostics.Process.GetCurrentProcess().Kill();
            isStart = false;
            videoSources.Stop();
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isStart = !isStart;
            Button btn = sender as Button;
            if (isStart == true)
            {
                btn.BackColor = Color.Red;
                char[] ch = new char[2];
                ch[0] = 'o';
                serialPort1.Write(ch, 0, 1);
            }
            else
            {
                char[] ch = new char[2];
                ch[0] = 'c';
                serialPort1.Write(ch, 0, 1);
                btn.BackColor = Color.Green;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            frequencyResponse = trackBar1.Value;
            label1.Text = trackBar1.Value.ToString();
        }
    }
}