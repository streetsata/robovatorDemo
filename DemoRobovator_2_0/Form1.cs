using System;
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

namespace DemoRobovator_2_0
{
    public partial class Form1 : Form
    {
        private class FoundObj
        {
            public int beginObj;
            public int lengthObj;
        }

        private class NoFoundObj
        {
            public int beginObj;
            public int lengthObj;
        }


        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSources;
        private YCbCrFiltering filter;
        private Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
        private BlobCounter blobCounter = new BlobCounter();
        private SerialPort serialPort1 = null;
        private int countEncoderTicks = 0;
        private bool isConnectArduino = false;
        private bool isMechanizmOn = false;
        private int brightnessCorrection = 0;
        private int cbMin = 0;
        private int cbMax = 0;
        private int crMax = 0;
        private int crMin = 0;
        private int blobCounterMinWidth = 25;
        private int blobCounterMinHeight = 25;
        private int frequencyResponse = 150;
        private Rectangle[] rects;
        private byte[] arr = new byte[1080];
        private byte[] arrTemp = new byte[40];
        private int unionObject = 0;
        private int objectCount = 0;
        private int totalObjectCount = 0;
        private bool isIntersect = false;
        private bool isStart = false;
        private Queue<FoundObj> quFoundObject;
        private Queue<NoFoundObj> quNoFoundObject;
        FoundObj fObj;
        NoFoundObj noFObj;

        // инициализация
        public Form1()
        {
            InitializeComponent();

            filter = new YCbCrFiltering();
            quFoundObject = new Queue<FoundObj>();

            // перебираю все COM-порты в системе и добавляю в cmbBoxConnectArduino
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
                cmbBoxConnectArduino.Items.Add(portName);

            // если есть COM-порты, выбираю первый из них
            if (cmbBoxConnectArduino.Items.Count > 0)
                cmbBoxConnectArduino.SelectedIndex = 0;

            // pictureBox1.Image = null;

            FoundObj muObjs = new FoundObj();

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

        int currentObjTicks = 0;
        // Событие о полученных данных с Arduino
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String data = null;
            data = serialPort1.ReadLine();
            data = data.Trim('\r', '\n', '\t').ToLower();

            if (!String.IsNullOrEmpty(data) && data == "1")
            {
                countEncoderTicks++;

                //if (isIntersect)
                //{
                //    if (currentObjTicks < 0)
                //        currentObjTicks = 0;

                //    if (currentObjTicks >= frequencyResponse)
                //        commandMech('w');
                //    else
                //        currentObjTicks++;

                //}
                //else
                //{
                //    if (currentObjTicks <= 0)
                //        commandMech('q');
                //    else
                //        currentObjTicks--;
                //}

                lblCountEncoderTicks.Invoke((MethodInvoker)(() => lblCountEncoderTicks.Text = countEncoderTicks.ToString()));
            }
        }

        // команды для механизма
        long currentCount = 0;
        long previousCount = 0;
        private void commandMech(char command)
        {
            if (isConnectArduino)
            {
                //currentCount = countEncoderTicks;

                //if (currentCount >= previousCount + frequencyResponse)
                //{
                //    // сохраняем последнего переключения
                //    previousCount = currentCount;

                char[] ch = new char[2];
                ch[0] = command;
                serialPort1.Write(ch, 0, 1);
                //}

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

        // операции при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
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

        // покадравая обработка
        int temp = 0;
        private void VideoSources_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            temp++;
            if (temp == 4)
            {
                //if (countEncoderTicks >= frequencyResponse)
                //{
                temp = 0;

                //countEncoderTicks = 0;

                Bitmap image = (Bitmap)eventArgs.Frame.Clone();

                UnmanagedImage grayImage = workFilter(ref image);

                Rectangle[] rects = workBlobs(grayImage, ref image);

                workWithObjects(rects, ref image);

                pictureBox1.Image = image;

                //commandMech();
                //}
            }
        }

        private void workWithObjects(Rectangle[] rects, ref Bitmap image)
        {
            if (rects.Length > 0 && isStart)
            {
                foreach (Rectangle item in rects)
                {
                    if (item.IntersectsWith(new Rectangle(0, image.Height - (image.Height / 3), image.Width, 1)))
                    {
                        fObj = new FoundObj();
                        
                        quFoundObject.Enqueue(fObj);

                        isIntersect = true;
                        labelArr.ForeColor = Color.Green;
                    }
                    else
                    {
                        //noFObj = new NoFoundObj();
                        //quNoFoundObject = new Queue<NoFoundObj>();
                        //quNoFoundObject.Enqueue(noFObj);

                        isIntersect = false;
                        labelArr.ForeColor = Color.Black;
                    }
                }
            }
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
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            //videoSources.PlayingFinished += VideoSources_PlayingFinished;
            videoSources.Stop();
            serialPort1.Close();
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
            videoSources.Stop();
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isStart = !isStart;
        }
    }
}